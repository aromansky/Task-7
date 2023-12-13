using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Security.Cryptography;
using System.Net.Http.Json;

namespace SoftwareEngineering
{
    static class HttpResponseMessageExtensions
    {
        internal static void WriteRequestToConsole(this HttpResponseMessage response)
        {
            if (response is null)
            {
                return;
            }

            var request = response.RequestMessage;
            Console.Write($"{request?.Method} ");
            Console.Write($"{request?.RequestUri} ");
            Console.WriteLine($"HTTP/{request?.Version}");
        }
    }
    public static class TaskController
    {
        public static readonly HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com"), };

        public static async void PostTask(HttpClient client)
        {         
            string host = "https://api.tracker.yandex.net";
            client.BaseAddress = new Uri(host);
            string direct = "/v2/issues/";

            string OAuthToken = "y0_AgAAAAAvs1WUAAr7WwAAAAD0n61zlJFYquEeQPCfiXF7n6wD0hB6H9Q";
            client.DefaultRequestHeaders.Add("Authorization", $"OAuth {OAuthToken}");

            string OrgID = "bpfgeea2s5cq4gb42jsk";
            client.DefaultRequestHeaders.Add("X-Cloud-Org-ID", OrgID);

            string[] flwrs = { "dkoplik", "mozdorov" };
            StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    queue = "TCBFFKMR",
                    summary = "Поднять билд",
                    description = "Билд упал! Нужно срочно починить!",
                    type = "task",
                    priority = "critical",
                    followers = flwrs,
                    author = "pihpuph",
                    assignee = "pihpuph",
                }),
                Encoding.UTF8,
                "application/json");
            var response = client.PostAsync(host + direct, jsonContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Успешный ответ: {responseBody}");
            }
            else
            {
                Console.WriteLine($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }

        
    }
}
