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
            var result = _primeTableGenerator.Generate(value);

            var side = result.GetUpperBound(0);
            var maxValue = result[side, side];
            var numberWidth = maxValue.ToString().Length;

            var sideCharacters = (numberWidth + 2) * side + 2;

            _outputWriter.Write("\n");
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
