using AlexaLlamaApi.Interfaces;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace AlexaLlamaApi.Services
{
    public class LlamaService : ILlamaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _llamaApiUrl = "http://localhost:11434/api/generate";

        public LlamaService(IHttpClientFactory httpClientFactory) //, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            // _llamaApiUrl = configuration["LlamaApi:Url"] ?? throw new ArgumentNullException("LlamaApi:Url configuration is missing.");

            
        }

        public async Task<string> SendToLlamaModelAsync(string userMessage)
        {
            var response = await _httpClient.PostAsJsonAsync(_llamaApiUrl, new 
            { 
                model = "gemma2:2b",
                prompt = userMessage,
                stream = false
            });

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LlamaResponse>();
                return result?.Response ?? "Sorry, I couldn't process your request.";
            }

            return "Failed to communicate with the Llama model.";
        }

        private class LlamaResponse
        {
            public string? Response { get; set; }
        }
    }
}
