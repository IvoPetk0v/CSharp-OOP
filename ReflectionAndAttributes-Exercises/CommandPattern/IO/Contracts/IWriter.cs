namespace CommandPattern.IO.Contracts
{
    public interface IWriter
    {
        public void Write(string input);
        public void WriteLine(string input);
    }
}
