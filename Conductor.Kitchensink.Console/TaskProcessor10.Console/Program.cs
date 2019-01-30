using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProcessor10.Console
{
    class Program
    {
        private const string BASE_ADDRESS_PARAMETER = "-baseAddress";

        static async Task Main(string[] args)
        {
            if (args.Count() % 2 != 0)
            {
                System.Console.WriteLine("Invalid arguments");
                return;
            }

            var param = new Dictionary<string, string>();
            param.Add(BASE_ADDRESS_PARAMETER, "");

            for (int i = 0; i < args.Count(); i = i + 2)
            {
                param[args[i]] = args[i + 1];
            }

            if (!param.ContainsKey(BASE_ADDRESS_PARAMETER))
            {
                System.Console.WriteLine("The base address parameter is required.");
                return;
            }

            var task10Processor = new Task10Processor();
            await task10Processor.ProcessAsync(param[BASE_ADDRESS_PARAMETER]);
        }
    }
}
