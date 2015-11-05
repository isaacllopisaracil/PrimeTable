using PrimeTable.CLI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.CLI
{
    class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
