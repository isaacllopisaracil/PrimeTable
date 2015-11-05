using PrimeTable.CLI.Contracts;
using PrimeTable.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.CLI
{
    public class PrimeNumbersAppController
    {
        IPrimeTableGenerator _primeTableGenerator;
        IOutputWriter _outputWriter;

        public PrimeNumbersAppController(
            IPrimeTableGenerator primeTableGenerator,
            IOutputWriter outputWriter)
        {
            if (primeTableGenerator == null) throw new ArgumentNullException($"Argument {nameof(primeTableGenerator)} cannot be null.", nameof(primeTableGenerator));
            if (outputWriter == null) throw new ArgumentNullException($"Argument {nameof(outputWriter)} cannot be null.", nameof(outputWriter));

            _primeTableGenerator = primeTableGenerator;
            _outputWriter = outputWriter;
        }

        public void Run(int value)
        {
            throw new NotImplementedException();
        }
    }
}
