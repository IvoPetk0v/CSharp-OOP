namespace Telephony.IO
{
    using System;
    using Telephony.IO.Interfaces;

    public class ConsoleWriter : IWriter
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
