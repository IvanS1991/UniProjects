using ProgrammingPracticum.IO.Contracts;
using System;

namespace ProgrammingPracticum.IO
{
    internal class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
