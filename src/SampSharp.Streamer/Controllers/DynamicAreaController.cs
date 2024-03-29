﻿// SampSharp.Streamer
// Copyright 2018 Tim Potze
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

using SampSharp.GameMode.Controllers;
using SampSharp.Streamer.World;

namespace SampSharp.Streamer.Controllers
{
    public class DynamicAreaController : ITypeProvider, IStreamerController
    {
        #region Implementation of IStreamerController

        public virtual void RegisterStreamerEvents(IStreamer streamer)
        {
            streamer.PlayerEnterDynamicArea += (sender, args) =>
            {
                var area = sender as DynamicArea;
                area?.OnEnter(args);
            };
            streamer.PlayerLeaveDynamicArea += (sender, args) =>
            {
                var area = sender as DynamicArea;
                area?.OnLeave(args);
            };
        }

        #endregion

        #region Implementation of ITypeProvider

        public virtual void RegisterTypes()
        {
            DynamicArea.Register<DynamicArea>();
        }

        #endregion
    }

    public class DynamicActorController : ITypeProvider, IStreamerController
    {
        #region Implementation of IStreamerController

        public virtual void RegisterStreamerEvents(IStreamer streamer)
        {
            streamer.DynamicActorStreamIn += (sender, args) =>
            {
                var actor = sender as DynamicActor;
                actor?.OnStreamIn(args);
            };
            streamer.DynamicActorStreamOut += (sender, args) =>
            {
                var actor = sender as DynamicActor;
                actor?.OnStreamOut(args);
            };
            streamer.PlayerGiveDamageDynamicActor += (sender, args) =>
            {
                var actor = sender as DynamicActor;
                actor?.OnPlayerGiveDamage(args);
            };
        }

        #endregion

        #region Implementation of ITypeProvider

        public virtual void RegisterTypes()
        {
            DynamicActor.Register<DynamicActor>();
        }

        #endregion
    }
}