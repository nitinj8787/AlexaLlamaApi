namespace AlexaLlamaApi.Models
{
    public class Intent
    {
        public string Name { get; set; }
        public Dictionary<string, Slot> Slots { get; set; }
    }

}
