using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using API_.NetFramework_Project.Models;

namespace TaskManagerTerminal
{
    public class TaskManager
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7013/api/Task"; // Change this URL to your API's URL

        public TaskManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddTask(string title)
        {
            var task = new TaskTp { Title = title, IsCompleted = false };
            await _httpClient.PostAsJsonAsync(ApiBaseUrl, task);
        }

        public async Task ListTasks()
        {
            var response = await _httpClient.GetStringAsync(ApiBaseUrl);
            Console.WriteLine(response);
        }

        public async Task UpdateTask(int taskId, TaskTp updatedTask)
        {
            var requestUri = $"{ApiBaseUrl}/{taskId}";
            var response = await _httpClient.PutAsJsonAsync(requestUri, updatedTask);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update task.");
            }
        }

        public async Task DeleteTask(int taskId)
        {
            var requestUri = $"{ApiBaseUrl}/{taskId}";
            var response = await _httpClient.DeleteAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete task.");
            }
        }

        public async Task ListCompletedTasks()
        {
            var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}/completed");
            Console.WriteLine(response);
        }

        public async Task ListIncompleteTasks()
        {
            var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}/incomplete");
            Console.WriteLine(response);
        }
    }
}




//using System;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;
//using API_.NetFramework_Project.Models;

//namespace TaskManagerTerminal
//{
//    public class TaskManager
//    {
//        private readonly HttpClient _httpClient;
//        private const string ApiBaseUrl = "https://localhost:7013/api/Task"; // My API's URL

//        public TaskManager(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task AddTask(string title)
//        {
//            var task = new TaskTp { Title = title, IsCompleted = false };
//            await _httpClient.PostAsJsonAsync(ApiBaseUrl, task);
//        }

//        public async Task ListTasks()
//        {
//            var response = await _httpClient.GetStringAsync(ApiBaseUrl);
//            Console.WriteLine(response);
//        }

//        public async Task UpdateTask(int taskId, TaskTp updatedTask)
//        {
//            var requestUri = $"{ApiBaseUrl}/{taskId}";
//            var response = await _httpClient.PutAsJsonAsync(requestUri, updatedTask);

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new Exception("Failed to update task.");
//            }
//        }

//        public async Task DeleteTask(int taskId)
//        {
//            var requestUri = $"{ApiBaseUrl}/{taskId}";
//            var response = await _httpClient.DeleteAsync(requestUri);

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new Exception("Failed to delete task.");
//            }
//        }
//    }
//}








//using System;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;
//using API_.NetFramework_Project.Models;

//namespace TaskManagerTerminal
//{
//    public class TaskManager
//    {
//        private readonly HttpClient _httpClient;
//        private const string ApiBaseUrl = "https://localhost:7013/api/Task"; // My API's URL

//        public TaskManager()
//        {
//            _httpClient = new HttpClient();
//        }

//        public async Task AddTask(string title)
//        {
//            var task = new TaskTp { Title = title, IsCompleted = false };
//            await _httpClient.PostAsJsonAsync(ApiBaseUrl, task);
//        }

//        public async Task ListTasks()
//        {
//            var response = await _httpClient.GetStringAsync(ApiBaseUrl);
//            // Deserialize the response and print the list of tasks
//            Console.WriteLine(response);
//        }

//        // Implement methods for updating and deleting tasks




//    }
//}
