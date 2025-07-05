using Microsoft.AspNetCore.Mvc;
using AlexaLlamaApi.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AlexaLlamaApi.Models;

namespace AlexaLlamaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatMemoryService _chatMemoryService;
        private readonly ILlamaService _llamaService;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IChatMemoryService chatMemoryService, ILlamaService llamaService, ILogger<ChatController> logger)
        {
            _chatMemoryService = chatMemoryService;
            _llamaService = llamaService;
            _logger = logger;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessAlexaRequest([FromBody] AlexaRequest alexaRequest)
        {
            try
            {
                if (alexaRequest.Session == null || alexaRequest.Request == null)
                {
                    return BadRequest("Invalid Alexa request.");
                }

                var sessionId = alexaRequest.Session.SessionId ?? Guid.NewGuid().ToString();
                var requestType = alexaRequest.Request.Type;

                if (requestType == "LaunchRequest")
                {
                    // Handle launch request
                    var welcomeResponse = new AlexaResponse
                    {
                        Response = new AlexaResponseBody
                        {
                            OutputSpeech = new OutputSpeech
                            {
                                Text = "Hey, my name is Tani, Welcome to the chat service! You can ask me a question and I will try to answer it hehehe."
                            },
                            ShouldEndSession = false
                        }
                    };

                    return Ok(welcomeResponse);
                }

                if (requestType == "IntentRequest")
                {

                    // handle normal intent
                    var userMessage = alexaRequest.Request.Intent?.Slots?["question"]?.Value;

                    if (string.IsNullOrEmpty(userMessage))
                    {
                        return Ok(new AlexaResponse
                        {
                            Response = new AlexaResponseBody
                            {
                                OutputSpeech = new OutputSpeech
                                {
                                    Text = "I'm listening. Please ask your question again."
                                },
                                ShouldEndSession = false
                            }
                        });
                    }

                    await _chatMemoryService.AddToMemoryAsync(sessionId, $"User: {userMessage}");

                    var llamaResponse = await _llamaService.SendToLlamaModelAsync(userMessage);

                    await _chatMemoryService.AddToMemoryAsync(sessionId, $"Llama: {llamaResponse}");

                    var alexaResponse = new AlexaResponse
                    {
                        Response = new AlexaResponseBody
                        {
                            OutputSpeech = new OutputSpeech
                            {
                                Text = llamaResponse
                            },
                            ShouldEndSession = false
                        }
                    };

                    return Ok(alexaResponse);
                }

                if (requestType == "SessionEndedRequest")
                {
                    // Handle session end request
                    return Ok(new AlexaResponse
                    {
                        Response = new AlexaResponseBody
                        {
                            OutputSpeech = new OutputSpeech
                            {
                                Text = "Thank you for using the chat service. Goodbye!"
                            },
                            ShouldEndSession = true
                        }
                    });
                }

                return BadRequest(new AlexaResponse
                {
                    Response = new AlexaResponseBody
                    {
                        OutputSpeech = new OutputSpeech
                        {
                            Text = "I don't know what to do, I don't know what to do.. bye bye.. plz try again"
                        },
                        ShouldEndSession = true
                    }
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the Alexa request.");
                return StatusCode(500, "An unexpected error occurred while processing the request.");
            }
        }
    }
}
