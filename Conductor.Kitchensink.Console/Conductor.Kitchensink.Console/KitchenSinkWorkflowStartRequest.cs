using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class KitchenSinkWorkflowStartRequest
    {
        [JsonProperty("task2Name")]
        public string Task2Name { get; set; }

        [JsonProperty("mod")]
        public int Mod { get; set; }

        [JsonProperty("oddEven")]
        public int OddEven { get; set; }
    }
}
