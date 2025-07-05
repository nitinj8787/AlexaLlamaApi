using AlexaLlamaApi.Interfaces;
using AlexaLlamaApi.Models;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace AlexaLlamaApi.Services
{
    public class ChatMemoryService : IChatMemoryService
    {
        private readonly ConcurrentDictionary<string, AlexaSessionState> _chatMemory = new();
                      
        public void AddToGoingResponse(string userId, Task<string> llmTask)
        {
            Console.WriteLine($"adding userId: {userId}");
            _chatMemory[userId] = new AlexaSessionState
            {
                UserId = userId,
                LlamaTask = llmTask, 
                CreatedAt = DateTime.UtcNow
            };
        }

        public async Task<string?> GetOnGoingResponse(string userId)
        {
            Console.WriteLine($"retrieving userId: {userId}");
            if (_chatMemory.TryGetValue(userId,out var task))
            {
                if(!task.LlamaTask.IsCompleted)
                {
                    Console.WriteLine($"Task status when checking - GetOnGoingResponse: {task.LlamaTask.Status}");
                    var result =  await task.LlamaTask;
                    Console.WriteLine($"after : Task status when checking - GetOnGoingResponse: {task.LlamaTask.Status} : {result}");
                    return result;
                }
            }

            return null;
        }
    }
}
