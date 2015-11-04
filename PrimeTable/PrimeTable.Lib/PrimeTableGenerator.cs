using PrimeTable.Lib.Contracts;
using System;
using System.Linq;

namespace PrimeTable.Lib
{
    public class PrimeTableGenerator : IPrimeTableGenerator
    {
        private readonly IPrimeNumberGenerator _primeNumberGenerator;

        public PrimeTableGenerator(
            IPrimeNumberGenerator primeNumberGenerator)
        {
            _primeNumberGenerator = primeNumberGenerator;
        }

        public int?[,] Generate(int length)
        {
            // Validate
            if (length <= 0)
                throw new ArgumentOutOfRangeException($"Method {nameof(Generate)} only accepts {nameof(length)} values greater than 0.");

            var primeList = _primeNumberGenerator.Generate(length).ToArray();
            var result = new int?[length + 1, length + 1];
            
            for(int i = 1; i <= length; i++)
            {
                result[0, i] = result[i, 0] = primeList[i - 1];
                for (int j = 1; j <= i; j++)
                    result[j, i] = result[i, j] = primeList[i - 1] * primeList[j - 1];
            }

            return result;
        }
    }
}