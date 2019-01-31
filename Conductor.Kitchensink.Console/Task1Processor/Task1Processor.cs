using Conductor.KitchenSink.Console;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1Processor.Console
{
    public class Task1Processor : ITask1Processor
    {
        public async Task ProcessAsync(string baseAddress)
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
                        pollResponseMessage = await httpClient.GetAsync("api/tasks/poll/task_1");
                        Thread.Sleep(1000);
                    } while (pollResponseMessage.StatusCode == System.Net.HttpStatusCode.NoContent);

                    if (!pollResponseMessage.IsSuccessStatusCode)
                    {
                        System.Console.WriteLine($"A problem has occurred during task 1 polling. Status code: {pollResponseMessage.StatusCode}");
                        continue;
                    }

                    string task1PollJsonResponse = await pollResponseMessage?.Content?.ReadAsStringAsync();

                    TaskPollResponse taskPollResponse = JsonConvert.DeserializeObject<TaskPollResponse>(task1PollJsonResponse);

                    int? oddEven = taskPollResponse?.InputData?.OddEven;
                    var taskUpdateRequest = new TaskUpdateRequest();

                    switch (oddEven)
                    {
                        case 0:
                            const string TASK_1 = "task_1";
                            const string TASK_1_1 = "task_1_1";
                            const string WF_DYN = "wf_dyn";

                            var dynamicForkOutputData = new DynamicForkOutputData();
                            dynamicForkOutputData.TaskToExecute = TASK_1;
                            dynamicForkOutputData.DynamicTasks = new List<DynamicTask>();
                            dynamicForkOutputData.DynamicTasks.Add(new SimpleDynamicTask
                            {
                                Name = TASK_1,
                                TaskReferenceName = TASK_1_1,
                            });
                            dynamicForkOutputData.DynamicTasks.Add(new SubWorkFlowDynamicTask
                            {
                                Name = "sub_workflow_4",
                                TaskReferenceName = WF_DYN,
                                SubWorkflowParam = new SubWorkFlowParameter
                                {
                                    Name = "sub_flow_1"
                                }
                            });
                            dynamicForkOutputData.Inputs = new JRaw($"{{\"{TASK_1_1}\": {{}}, \"{WF_DYN}\": {{}}}}");
                            taskUpdateRequest.OutputData = dynamicForkOutputData;
                            break;
                        case 1:
                            taskUpdateRequest.OutputData = new OutputData();
                            taskUpdateRequest.OutputData.Mod = taskPollResponse?.InputData?.Mod;
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
                        System.Console.WriteLine($"A problem has occurred during task 1 update. Status code: {pollResponseMessage.StatusCode}");
                        continue;
                    }

                    System.Console.WriteLine($"Task1 Worker Processed task: {await responseMessage.Content.ReadAsStringAsync()}");

                    Thread.Sleep(1000);
                }
            }
        }
    }
}
