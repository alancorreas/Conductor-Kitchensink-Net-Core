using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class DynamicForkOutputData : OutputData
    {
        [JsonProperty("taskToExecute")]
        public string TaskToExecute { get; set; }

        [JsonProperty("dynamicTasks")]
        public List<DynamicTask> DynamicTasks { get; set; }

        [JsonProperty("inputs")]
        public JRaw Inputs { get; set; }
    }
}
