namespace Telephony.Core
{

    using Telephony.IO.Interfaces;
    using Telephony.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private Smartphone smartPhone;
        private StationaryPhone stationaryPhone;

        public Engine()
        {
            this.smartPhone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
           

        }
        public void Run()
        {
            string[] numbers = reader.ReadLine().Split(" ",System.StringSplitOptions.RemoveEmptyEntries);
            string[] urls = reader.ReadLine().Split();
            foreach (var num in numbers)
            {
                if (!this.ValidateNumber(num))
                {
                   this.writer.WriteLine("Invalid number!");
                }
                else if (num.Length==10)
                {
                    this.writer.WriteLine(this.smartPhone.Call(num));
                }
                else if (num.Length==7)
                {
                    this.writer.WriteLine(this.stationaryPhone.Call(num));
                }
            }
            foreach (var url in urls)
            {
                if (!this.ValidateURL(url))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(this.smartPhone.Browse(url));
                }
            }

        }
        private bool ValidateNumber(string number)
        {
            foreach (var ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateURL(string url)
        {
            foreach (var ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
