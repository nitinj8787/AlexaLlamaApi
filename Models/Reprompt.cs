using System.Text.Json.Serialization;

namespace AlexaLlamaApi.Models
{
    public class Reprompt
    {
        [JsonPropertyName("outputSpeech")]
        public OutputSpeech? OutputSpeech { get; set; }
    }
}
