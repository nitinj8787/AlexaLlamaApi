namespace AlexaLlamaApi.Models
{
    public class AlexaRequestBody
    {
        public string Type { get; set; }
        public string RequestId { get; set; }
        public Intent? Intent { get; set; }
    }
}
