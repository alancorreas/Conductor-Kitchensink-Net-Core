using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conductor.KitchenSink.Console
{
    class Program
    {
        private const string TASK_2_NAME_PARAMETER = "-task2Name";
        private const string BASE_ADDRESS_PARAMETER = "-baseAddress";
        private const string WORKFLOW_NAME_PARAMETER = "-workFlowName";
        private const string ODD_EVEN_PARAMETER = "-oddEven";
        private const string MOD_PARAMETER = "-mod";

        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Starting Kitchensink workflow");

            if (args.Count() % 2 != 0)
            {
                System.Console.WriteLine("Invalid arguments");
                return;
            }

            var param = new Dictionary<string, string>();
            param.Add(TASK_2_NAME_PARAMETER, "");
            param.Add(BASE_ADDRESS_PARAMETER, "");
            param.Add(WORKFLOW_NAME_PARAMETER, "");
            param.Add(MOD_PARAMETER, "");
            param.Add(ODD_EVEN_PARAMETER, "");

            for (int i = 0; i < args.Count(); i = i + 2)
            {
                param[args[i]] = args[i + 1];
            }

            if (!param.ContainsKey(TASK_2_NAME_PARAMETER))
            {
                System.Console.WriteLine("The task 2 name parameter is required.");
                return;
            }
            
            if (!param.ContainsKey(BASE_ADDRESS_PARAMETER))
            {
                System.Console.WriteLine("The base address parameter is required.");
                return;
            }

            if (!param.ContainsKey(WORKFLOW_NAME_PARAMETER))
            {
                System.Console.WriteLine("The workflow name parameter is required.");
                return;
            }

            if (!param.ContainsKey(ODD_EVEN_PARAMETER))
            {
                System.Console.WriteLine("The odd/even parameter is required.");
                return;
            }

            if (!param.ContainsKey(MOD_PARAMETER))
            {
                System.Console.WriteLine("The mod parameter is required.");
                return;
            }

            var workflowRunner = new KitchenSinkRunner();
            await workflowRunner.RunAsync(param[BASE_ADDRESS_PARAMETER], param[WORKFLOW_NAME_PARAMETER], param[TASK_2_NAME_PARAMETER], int.Parse(param[ODD_EVEN_PARAMETER]), int.Parse(param[MOD_PARAMETER]));

            System.Console.WriteLine("Press any button to exit...");
            System.Console.ReadKey();
        }
    }
}
