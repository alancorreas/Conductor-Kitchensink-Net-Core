using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class SimpleDynamicTask : DynamicTask
    {
        public override string TaskType => Constants.TaskTypes.SIMPLE;
    }
}
