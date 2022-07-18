namespace Raiding
{
    using System;
    using Factories;
    using Core;

    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            IFactory heroFactory = new HeroFactory();
            IEngine engine = new Engine();
            engine.Start(n, heroFactory);

        }
    }
}
