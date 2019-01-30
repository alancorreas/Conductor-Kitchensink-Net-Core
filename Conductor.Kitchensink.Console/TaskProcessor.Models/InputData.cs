using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class InputData
    {
        [JsonProperty("mod")]
        public int? Mod { get; set; }

        [JsonProperty("oddEven")]
        public int? OddEven { get; internal set; }

        [JsonProperty("taskToExecute")]
        public string TaskToExecute { get; internal set; }

        [JsonProperty("dynamicTasks")]
        public List<DynamicTask> DynamicTasks { get; set; }

        [JsonProperty("inputs")]
        public JRaw Inputs { get; set; }
    }
}
