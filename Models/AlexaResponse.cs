using System.Text.Json.Serialization;

namespace AlexaLlamaApi.Models
{
    public class AlexaResponse
    {        
        [JsonPropertyName("version")]
        public string? Version { get; set; } = "1.0";

        [JsonPropertyName("response")]
        public AlexaResponseBody Response { get; set; } 

    }
}
