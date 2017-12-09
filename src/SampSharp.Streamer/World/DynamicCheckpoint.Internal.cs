// SampSharp.Streamer
// Copyright 2017 Tim Potze
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
    public partial class DynamicCheckpoint
    {
        protected static readonly DynamicCheckpointInternal Internal;

        static DynamicCheckpoint()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<DynamicCheckpointInternal>();
        }

        public class DynamicCheckpointInternal
        {
            [NativeMethod]
            public virtual int CreateDynamicCP(float x, float y, float z, float size, int worldid, int interiorid,
                int playerid, float streamdistance, int areaid, int priority)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(10, 11, 12, 13)]
            public virtual int CreateDynamicCPEx(float x, float y, float z, float size, float streamdistance,
                int[] worlds, int[] interiors, int[] players, int[] areas, int priority, int maxworlds, int maxinteriors,
                int maxplayers, int maxareas)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int DestroyDynamicCP(int checkpointid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsValidDynamicCP(int checkpointid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int TogglePlayerDynamicCP(int playerid, int checkpointid, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int TogglePlayerAllDynamicCPs(int playerid, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsPlayerInDynamicCP(int playerid, int checkpointid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetPlayerVisibleDynamicCP(int playerid)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}