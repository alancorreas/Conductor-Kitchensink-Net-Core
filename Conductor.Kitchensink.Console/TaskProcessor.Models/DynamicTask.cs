using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class DynamicTask
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("taskReferenceName")]
        public string TaskReferenceName { get; set; }

        [JsonProperty("type")]
        public virtual string TaskType { get; set; }

        [JsonProperty("subWorkflowParam")]
        public SubWorkFlowParameter SubWorkflowParam { get; set; }
    }
}
