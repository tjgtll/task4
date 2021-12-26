using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task4
{
    class Core
    {
        private readonly string errorMessasge = "Invalid entry, can be from {0} to {1}";
        private readonly string menuMessage = "HMAC:{0}\nAvailable moves:{1}\n0 - exit\n? - help\nEnter your move: ";
        private readonly string gameMessage = "Your move: {0}\nComputer move: {1}";
        private readonly string hmacKeyMessage = "HMAC key:\n{0}";
        private readonly string win = "You win!";
        private readonly string lose = "You lose!";
        private readonly string draw = "You draw!";
        private readonly string[] arguments;
        private int programMoveNumber;
        private readonly Confirmation confirmation;

        public Core(string[] args)
        {
            arguments = args;
            programMoveNumber = 0;
            confirmation = new Confirmation();
        }

        public bool Loop()
        {
            if (programMoveNumber >= arguments.Length)
            {
                programMoveNumber = 0;
            }

            StringBuilder s = new StringBuilder();
            int i = 1;
            foreach (var a in arguments)
            {
                s.Append($"\n{i} - {a}");
                i++;
            }

            var hmacKey = confirmation.CreateRandomKey();

            Console.Write(menuMessage, confirmation.CreateHMAC(arguments[programMoveNumber], hmacKey), s);

            var input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return false;
                case "?":
                    var a = new TableOfHelp(arguments);
                    a.Info();
                    return true;
                default:
                    round(input, hmacKey);
                    return true;
            }
        }

        private void round(string input, string hmacKey)
        {
            if (!Int32.TryParse(input, out int inputNumber) || inputNumber > arguments.Length)
            {
                Console.WriteLine(errorMessasge, 0, arguments.Length);
                return;
            }

            inputNumber--;

            Console.WriteLine(gameMessage, arguments[inputNumber], arguments[programMoveNumber]);

            Console.WriteLine(deterWin(inputNumber));

            Console.WriteLine(hmacKeyMessage, hmacKey);
            programMoveNumber++;

        }

        private string deterWin(int inputNumber)
        {
            if (programMoveNumber == inputNumber)
            {
                return draw;
            }

            var winCondition = programMoveNumber + (arguments.Length / 2);
            
            if (inputNumber > programMoveNumber || winCondition - arguments.Length >= inputNumber)
            {
                return win;
            }
            else
            {
                return lose;
            }
            
        }
    }
}
