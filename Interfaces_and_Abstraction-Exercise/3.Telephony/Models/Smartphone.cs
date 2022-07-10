namespace Telephony.Models
{

    using Telephony.Models.Interfaces;

    public class Smartphone : ICallable, IBrowseable
    {
        public string Browse(string url)
        {
            string result = $"Browsing: {url}!";
            return result;
        }

        public string Call(string number)
        {
            string result = $"Calling... {number}";
            return result;
        }


    }
}
