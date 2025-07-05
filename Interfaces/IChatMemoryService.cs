namespace AlexaLlamaApi.Interfaces
{    
    public interface IChatMemoryService
    {
        Task AddToMemoryAsync(string sessionId, string message);
        Task<List<string>> GetChatHistoryAsync(string sessionId);
    }
}
