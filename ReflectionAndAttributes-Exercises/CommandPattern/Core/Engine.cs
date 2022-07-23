using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;
using CommandPattern.IO;
using CommandPattern.IO.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(ICommandInterpreter commandInterptrer, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterptrer;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            try
            {
                while (true)
                {
                    string input = this.reader.ReadLine();

                    string result = this.commandInterpreter.Read(input);
                    this.writer.WriteLine(result);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
