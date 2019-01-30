using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conductor.KitchenSink.Console
{
    internal class KitchenSinkRunner
    {
        public async Task<string> RunAsync(string baseAddress, string workflowName, string task2Name, int oddEven, int mod)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseAddress);
                var content = new StringContent(JsonConvert.SerializeObject(new KitchenSinkWorkflowStartRequest { Task2Name = task2Name, OddEven = oddEven, Mod = mod }), Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await httpClient.PostAsync($"api/workflow/{workflowName}", content);

                if (!responseMessage.IsSuccessStatusCode)
                    return $"A problem has occurred during workflow start. Status code: {responseMessage.StatusCode}";

                // TODO Return response
                return null;
            }
        }
    }
}
