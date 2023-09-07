using System;
using System.Net.Http;
using System.Threading.Tasks;
using API_.NetFramework_Project.Models;

namespace TaskManagerTerminal
{
    public class TaskManager
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7013/api/Task"; // My API's URL

        public TaskManager()
        {
            _httpClient = new HttpClient();
        }

        public async Task AddTask(string title)
        {
            var task = new TaskTp { Title = title, IsCompleted = false };
            await _httpClient.PostAsJsonAsync(ApiBaseUrl, task);
        }

        public async Task ListTasks()
        {
            var response = await _httpClient.GetStringAsync(ApiBaseUrl);
            // Deserialize the response and print the list of tasks
            Console.WriteLine(response);
        }

        // Implement methods for updating and deleting tasks


    }
}
