using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace task4
{
    class TableOfHelp
    {
        private readonly string[] arguments;

        public TableOfHelp(string[] arguments)
        {
            this.arguments = arguments;
        }

        public void Info()
        {
            var table = new ConsoleTable("");
            table.AddColumn(arguments);
            int i = 1;
            foreach (var b in arguments)
            {
                object[] args = new object[arguments.Length + 1];
                args[0] = b;
                for (int j = 1; j < arguments.Length + 1; j++)
                {
                    args[j] = $"Lose";
                }
                table.AddRow(args);
                args[i] = $"Draw";
                i++;
                for (int j = i; j < i + arguments.Length / 2; j++)
                {
                    if (j <= arguments.Length)
                    {
                        args[j] = $"Win";
                    }
                    else
                    {
                        args[j - arguments.Length] = $"Win";
                    }
                }

            }
            table.Write(Format.Minimal);
        }
    }
}
