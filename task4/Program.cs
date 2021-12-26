using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine($"The number of arguments cannot be even less 3\nExample: rock paper scissors");
                return;
            }

            if (args.Length % 2 == 0)
            {
                Console.WriteLine($"The number of arguments cannot be even({args.Length})\nExample: rock paper scissors lizard Spock");
                return;
            }

            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Contains duplicates");
                return;
            }

            Core gc = new Core(args);

            bool isGame = true;
            while (isGame)
            {
                isGame = gc.Loop();
            }
        }
    }
}
