using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.KitchenSink.Console
{
    public class SubWorkFlowDynamicTask : DynamicTask
    {
        public override string TaskType => Constants.TaskTypes.SUB_WORKFLOW;
    }
}
