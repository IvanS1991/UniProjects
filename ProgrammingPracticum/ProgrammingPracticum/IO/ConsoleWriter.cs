using ProgrammingPracticum.IO.Contracts;
using System;

namespace ProgrammingPracticum.IO
{
    internal class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
