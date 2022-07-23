namespace CommandPattern.IO
{
    using System;
    using Contracts;

    class ConsoleWriter : IWriter
    {
        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
