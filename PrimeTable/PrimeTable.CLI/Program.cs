using PrimeTable.Lib;
using PrimeTable.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                int value = -1;
                if (args.Length == 1 && int.TryParse(args[0], out value))
                {
                    // This is a single AppController
                    // For applications with multiple commands this can be extracted
                    // to an interface and select depending on the commands
                    // A Dependency Injection strategy can be applied
                    var appController = new PrimeNumbersAppController(
                        new PrimeTableGenerator(new PrimeNumberGenerator()),
                        new ConsoleOutputWriter());

                    appController.Run(value);
                }
                else
                {
                    Error("Please use an integer, between 1 and 10, as parameter to run this application.");
                }
            }
            catch(Exception ex)
            {
                Error($"The application found an error:\n{ex.Message}");
            }

            Console.Read();
        }

        static void Error(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }
}
