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
                throw new ArgumentOutOfRangeException($"Method {nameof(Generate)} only accepts {nameof(length)} values greater than 0.");

            throw new NotImplementedException("This is a method stub.");
        }

        public bool IsPrime(int value)
        {
            if (value <= 1)
                throw new ArgumentOutOfRangeException($"Method {nameof(IsPrime)} only accepts {nameof(value)} values greater than 1.");

            // Special case 2
            if (value == 2) return true;

            // General case
            var end = Math.Floor(Math.Sqrt(value));
            for(int i = 2; i <= end; i++)
                if (value % i == 0) return false;

            return true;
        }
    }
}