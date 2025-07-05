namespace AlexaLlamaApi.Interfaces
{    
    public interface IChatMemoryService
    {
        void AddToGoingResponse(string userId, Task<string> llmTask);
        Task<string?> GetOnGoingResponse(string userId);
    }
}
