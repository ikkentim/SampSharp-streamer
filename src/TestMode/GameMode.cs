// SampSharp.Streamer
// Copyright 2016 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.API;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using TestMode.Tests;

namespace TestMode
{
    public class TestTest
    {
        [NativeMethod]
        public virtual int CreateDynamicPickupEx(int modelid, int type, float x, float y, float z, float streamdistance,
            int[] worlds, int[] interiors, int[] players, int maxworlds, int maxinteriors, int maxplayers)
        {
            throw new NativeNotImplementedException();
        }
    }

    public class GameMode : BaseMode
    {
        private readonly List<ITest> _tests = new List<ITest>
        {
            new StreamerTest()
        };

        protected override void OnInitialized(EventArgs e)
        {
            var tt = NativeObjectProxyFactory.CreateInstance<TestTest>();
            var id = tt.CreateDynamicPickupEx(42, 1, 5, 5, 5, 100, new[] {-1}, new[] {-1}, new[] {-1}, 1, 1, 1);
            Console.WriteLine("ID ::: " + id);

            Console.WriteLine("Test initializing...");

            SetGameModeText("sa-mp# testmode");
            UsePlayerPedAnimations();

            AddPlayerClass(65, new Vector3(5), 0, Weapon.AK47, 500);

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
                test.LoadControllers(this, controllers);
        }
    }
}