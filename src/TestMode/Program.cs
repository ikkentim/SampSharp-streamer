using System;
using System.Linq;
using SampSharp.Core;
using SampSharp.Core.Logging;

namespace TestMode
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            new GameModeBuilder()
                .Use<GameMode>()
                .Run();
        }
    }
}
