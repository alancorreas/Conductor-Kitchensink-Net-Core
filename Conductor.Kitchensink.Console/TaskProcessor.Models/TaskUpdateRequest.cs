using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class TaskUpdateRequest
    {
        [JsonProperty("taskId")]
        public string TaskId { get; set; }

        [JsonProperty("workflowInstanceId")]
        public string WorkflowInstanceId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("outputData")]
        public OutputData OutputData { get; set; }
    }
}
