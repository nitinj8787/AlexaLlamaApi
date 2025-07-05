using System.Text.Json.Serialization;

namespace AlexaLlamaApi.Models
{
    public class AlexaResponseBody
    {
        [JsonPropertyName("outputSpeech")]
        public OutputSpeech? OutputSpeech { get; set; } = new OutputSpeech();

        [JsonPropertyName("reprompt")]
        public Reprompt? Reprompt { get; set; }

        [JsonPropertyName("shouldEndSession")]
        public bool ShouldEndSession { get; set; } = false;             
        
    }
}
