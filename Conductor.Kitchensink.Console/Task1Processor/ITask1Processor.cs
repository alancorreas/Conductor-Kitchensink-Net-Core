using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Task1Processor.Console
{
    public interface ITask1Processor
    {
        Task ProcessAsync(string baseAddress);
    }
}
