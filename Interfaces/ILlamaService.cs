namespace AlexaLlamaApi.Interfaces
{
    public interface ILlamaService
    {
        Task<string> SendToLlamaModelAsync(string userMessage);
    }
}
