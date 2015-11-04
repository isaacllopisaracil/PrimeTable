using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.Lib.Contracts
{
    public interface IPrimeNumberGenerator
    {
        IEnumerable<int> Generate(int length);
    }
}
