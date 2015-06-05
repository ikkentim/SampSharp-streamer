// SampSharp.Streamer
// Copyright 2015 Tim Potze
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
    public class DynamicObjectController : ITypeProvider, IStreamerController
    {
        #region Implementation of IStreamerController

        public void RegisterStreamerEvents(Streamer streamer)
        {
            streamer.DynamicObjectMoved += (sender, args) =>
            {
                var @object = sender as DynamicObject;
                if (@object != null)
                    @object.OnMoved(args);
            };
            streamer.PlayerEditDynamicObject += (sender, args) =>
            {
                var @object = sender as DynamicObject;
                if (@object != null)
                    @object.OnEdited(args);
            };
            streamer.PlayerSelectDynamicObject += (sender, args) =>
            {
                var @object = sender as DynamicObject;
                if (@object != null)
                    @object.OnSelected(args);
            };
            streamer.PlayerShootDynamicObject += (sender, args) =>
            {
                var @object = sender as DynamicObject;
                if (@object != null)
                    @object.OnShot(args);
            };
        }

        #endregion

        #region Implementation of ITypeProvider

        /// <summary>
        ///     Registers types this <see cref="T:SampSharp.GameMode.Controllers.ITypeProvider" /> requires the system to use.
        /// </summary>
        public void RegisterTypes()
        {
            DynamicObject.Register<DynamicObject>();
        }

        #endregion
    }
}