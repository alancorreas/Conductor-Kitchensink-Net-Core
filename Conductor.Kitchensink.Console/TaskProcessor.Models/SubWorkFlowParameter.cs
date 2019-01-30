using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class SubWorkFlowParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
