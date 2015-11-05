using PrimeTable.Lib.Contracts;
using System;
using System.Collections.Generic;

namespace PrimeTable.Lib
{
    public class PrimeNumberGenerator : IPrimeNumberGenerator
    {
        public IEnumerable<int> Generate(int length)
        {
            // Validate
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"Method {nameof(Generate)} only accepts {nameof(length)} values greater than 0.");

            int value = 2;
            var result = new int[length];
            result[0] = value;

            for(int i = 1; i< length; i++)
            {
                do
                {
                    value++;
                } while (!IsPrime(value));
                result[i] = value;
            }

            return result;
        }

        public bool IsPrime(int value)
        {
            // Validate
            if (value <= 1)
                throw new ArgumentOutOfRangeException(nameof(value), $"Method {nameof(IsPrime)} only accepts {nameof(value)} values greater than 1.");

            // Special case 2
            if (value == 2) return true;

            // General case
            var end = Math.Floor(Math.Sqrt(value));
            for (int i = 2; i <= end; i++)
                if (value % i == 0) return false;

            return true;
        }
    }
}