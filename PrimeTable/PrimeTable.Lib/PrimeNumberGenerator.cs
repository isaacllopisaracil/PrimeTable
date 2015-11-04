using System;
using System.Collections.Generic;

namespace PrimeTable.Lib
{
    public class PrimeNumberGenerator
    {
        public IEnumerable<int> Generate(int length)
        {
            // Validate
            if (length <= 0)
                throw new ArgumentOutOfRangeException($"Method {nameof(Generate)} only accepts {nameof(length)} values higher than 0.");

            throw new NotImplementedException("This is a method stub.");
        }
    }
}