using Conductor.KitchenSink.Console;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4Processor.Console
{
    public class Task4Processor
    {
        internal async Task<string> ProcessAsync(string baseAddress)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseAddress);

                // TODO create a stop mechanism. Ugly but it will work for now. If you want to stop it just close the application.
                while (true)
                {
                    HttpResponseMessage pollResponseMessage;
                    do
                    {
                        pollResponseMessage = await httpClient.GetAsync("api/tasks/poll/task_4");
                        Thread.Sleep(1000);
                    } while (pollResponseMessage.StatusCode == System.Net.HttpStatusCode.NoContent);

                    if (!pollResponseMessage.IsSuccessStatusCode)
                    {
                        System.Console.WriteLine($"A problem has occurred during task 4 polling. Status code: {pollResponseMessage.StatusCode}");
                        continue;
                    }

                    string task1PollJsonResponse = await pollResponseMessage?.Content?.ReadAsStringAsync();

                    TaskPollResponse taskPollResponse = JsonConvert.DeserializeObject<TaskPollResponse>(task1PollJsonResponse);

                    int? oddEven = taskPollResponse.InputData.OddEven;
                    var taskUpdateRequest = new TaskUpdateRequest();

                    switch (oddEven)
                    {
                        case 0:
                            var dynamicForkOutputData = new DynamicForkOutputData();
                            dynamicForkOutputData.DynamicTasks = taskPollResponse.InputData.DynamicTasks;
                            dynamicForkOutputData.Inputs = taskPollResponse.InputData.Inputs;

                            taskUpdateRequest.OutputData = dynamicForkOutputData;
                            break;
                        case 1:
                            break;
                        default:
                            taskUpdateRequest.OutputData = new OutputData();
                            break;
                    }
                    taskUpdateRequest.TaskId = taskPollResponse.TaskId;
                    taskUpdateRequest.WorkflowInstanceId = taskPollResponse.WorkflowInstanceId;
                    taskUpdateRequest.Status = Constants.TaskStatuses.COMPLETED;
                    taskUpdateRequest.OutputData.OddEven = oddEven;

                    var stringContent = new StringContent(JsonConvert.SerializeObject(taskUpdateRequest), Encoding.UTF8, "application/json");

                    HttpResponseMessage responseMessage = await httpClient.PostAsync("api/tasks/", stringContent);

                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        System.Console.WriteLine($"A problem has occurred during task 4 update. Status code: {pollResponseMessage.StatusCode}");
                        continue;
                    }

                    System.Console.WriteLine($"Processed task: {await responseMessage.Content.ReadAsStringAsync()}");

                    Thread.Sleep(1000);
                }

                // TODO Send the received ID through an event
                return null;
            }
        }
    }
}
