namespace AlexaLlamaApi.Models
{
    public class AlexaRequest
    {
        public Session? Session { get; set; }
        public AlexaRequestBody? Request { get; set; }
        public string Version { get; set; }        
        public Context Context { get; set; }
    }
}
