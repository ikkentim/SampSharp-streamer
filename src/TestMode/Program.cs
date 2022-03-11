using SampSharp.Core;

namespace TestMode.GameMode
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
