namespace AlexaLlamaApi.Models
{
    public class Session
    {
        public string? SessionId { get; set; }
        public Application Application { get; set; }
        public User User { get; set; }
    }
}
