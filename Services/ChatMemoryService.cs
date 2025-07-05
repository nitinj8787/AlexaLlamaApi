using AlexaLlamaApi.Interfaces;
using System.Collections.Concurrent;

namespace AlexaLlamaApi.Services
{
    public class ChatMemoryService : IChatMemoryService
    {
        private readonly ConcurrentDictionary<string, List<string>> _chatMemory;

        public ChatMemoryService()
        {
            _chatMemory = new ConcurrentDictionary<string, List<string>>();
        }

        public async Task AddToMemoryAsync(string sessionId, string message)
        {
            if (!_chatMemory.ContainsKey(sessionId))
            {
                _chatMemory[sessionId] = new List<string>();
            }

            _chatMemory[sessionId].Add(message);
            await Task.CompletedTask;
        }

        public async Task<List<string>> GetChatHistoryAsync(string sessionId)
        {
            if (_chatMemory.TryGetValue(sessionId, out var chatHistory))
            {
                return await Task.FromResult(chatHistory);
            }

            return await Task.FromResult(new List<string>());
        }
    }
}
