// SampSharp.Streamer
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

using SampSharp.Core.Natives.NativeObjects;

namespace SampSharp.Streamer.World
{
    public partial class DynamicPickup
    {
        protected static readonly DynamicPickupInternal Internal = NativeObjectProxyFactory.CreateInstance<DynamicPickupInternal>();
        
        public class DynamicPickupInternal
        {
            [NativeMethod]
            public virtual int CreateDynamicPickup(int modelid, int type, float x, float y, float z, int worldid,
                int interiorid, int playerid, float streamdistance, int areaid, int priority)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(11, 12, 13, 14)]
            public virtual int CreateDynamicPickupEx(int modelid, int type, float x, float y, float z,
                float streamdistance, int[] worlds, int[] interiors, int[] players, int[] areas, int priority,
                int maxworlds, int maxinteriors, int maxplayers, int maxareas)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int DestroyDynamicPickup(int pickupid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsValidDynamicPickup(int pickupid)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}