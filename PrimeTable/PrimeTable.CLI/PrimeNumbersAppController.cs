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
            // Validate
            if (value <= 0 || value > 10)
                throw new ArgumentOutOfRangeException($"Method {nameof(Run)} only accepts {nameof(value)} values from 1 to 10.");

            // Calculate array
            var result = _primeTableGenerator.Generate(value);

            // Get values to render in console
            var side = result.GetUpperBound(0) + 1;
            var maxValue = result[side-1, side-1];
            var numberWidth = maxValue.ToString().Length;
            var sideCharacters = (numberWidth + 3) * side;

            // Render
            for (int x = 0; x < side; x++)
            {
                WriteLineOf(_outputWriter, "-", sideCharacters);
                for (int y = 0; y < side; y++)
                {
                    _outputWriter.Write("¦ ");

                    if (result[x, y].HasValue)
                        _outputWriter.Write(result[x, y].Value.ToString().PadLeft(numberWidth));
                    else
                        _outputWriter.Write("".PadLeft(numberWidth));

                    _outputWriter.Write(" ");
                }
                _outputWriter.Write("¦\n");
            }
            WriteLineOf(_outputWriter, "-", sideCharacters);
        }

        private static void WriteLineOf(IOutputWriter outputWriter, string value, int times)
        {
            for (int i = 0; i < times; i++)
                outputWriter.Write(value);
            outputWriter.Write("\n");
        }
    }
}
