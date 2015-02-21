using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.World;
using TestMode.Tests;

namespace TestMode
{
    public class GameMode : BaseMode
    {
        private readonly List<ITest> _tests = new List<ITest>
        {
            new StreamerTest(),
        };

        protected override void OnInitialized(EventArgs e)
        {
            SetGameModeText("sa-mp# testmode");
            UsePlayerPedAnimations();

            Debug.WriteLine("Loading player classes...");
            AddPlayerClass(65, new Vector(5), 0);

            foreach (ITest test in _tests)
            {
                Console.WriteLine("=========");
                Console.WriteLine("Starting test: {0}", test);
                test.Start(this);
                Console.WriteLine();
            }

            base.OnInitialized(e);
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);

            foreach (IControllerTest test in _tests.OfType<IControllerTest>())
                test.LoadControllers(controllers);
        }
    }
}