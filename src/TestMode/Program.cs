using System;
using System.Linq;
using SampSharp.Core;
using SampSharp.Core.Logging;

namespace TestMode
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameModeBuilder()
                .Use<GameMode>()
                .UseLogLevel(CoreLogLevel.Info)
                .UseStartBehaviour(GameModeStartBehaviour.FakeGmx)
                .Run();
        }
    }
}
