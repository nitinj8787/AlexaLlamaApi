using System.Text.Json.Serialization;

namespace AlexaLlamaApi.Models
{
    public class AlexaResponseBody
    {
        [JsonPropertyName("outputSpeech")]
        public OutputSpeech? OutputSpeech { get; set; } = new OutputSpeech();

        [JsonPropertyName("shouldEndSession")]
        public bool ShouldEndSession { get; set; } = false;             
        
    }
}
