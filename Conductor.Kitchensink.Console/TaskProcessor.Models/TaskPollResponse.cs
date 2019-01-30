using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class TaskPollResponse
    {
        [JsonProperty("inputData")]
        public InputData InputData { get; set; }

        [JsonProperty("taskId")]
        public string TaskId { get; set; }

        [JsonProperty("workflowInstanceId")]
        public string WorkflowInstanceId { get; set; }
    }
}
