using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.CLI.Contracts
{
    public interface IOutputWriter
    {
        void Write(string value);

        void WriteLine(string line);
    }
}
