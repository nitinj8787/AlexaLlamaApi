namespace AlexaLlamaApi.Models
{
    public class AlexaSessionState
    {
        public string UserId { get; set; }
        public Task<string> LlamaTask { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
