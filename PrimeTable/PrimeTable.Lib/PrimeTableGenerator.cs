using PrimeTable.Lib.Contracts;
using System;

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

            throw new NotImplementedException();
        }
    }
}