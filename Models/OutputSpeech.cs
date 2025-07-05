using System.Text.Json.Serialization;

namespace AlexaLlamaApi.Models
{
    public class OutputSpeech
    {
        [JsonPropertyName("type")]
        public string Type => "PlainText";

        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
