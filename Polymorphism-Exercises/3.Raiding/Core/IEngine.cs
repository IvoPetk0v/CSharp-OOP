namespace Raiding.Core
{
    using Factories;
    public interface IEngine
    {
        public void Start(int n, IFactory heroFactory);
    }
}
