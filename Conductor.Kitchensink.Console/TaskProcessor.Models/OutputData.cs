using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class OutputData
    {
        [JsonProperty("oddEven")]
        public int? OddEven { get; set; }

        [JsonProperty("mod")]
        public int? Mod { get; set; }

        [JsonProperty("elasticSearchHost")]
        public string ElasticSearchHost { get; set; }
    }
}
