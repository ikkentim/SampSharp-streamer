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

using SampSharp.GameMode.API;

namespace SampSharp.Streamer.World
{
    public partial class DynamicRaceCheckpoint
    {
        protected static readonly DynamicRaceCheckpointInternal Internal;

        static DynamicRaceCheckpoint()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<DynamicRaceCheckpointInternal>();
        }

        protected class DynamicRaceCheckpointInternal
        {
            [NativeMethod]
            public virtual int CreateDynamicRaceCP(int type, float x, float y, float z, float nextx, float nexty,
                float nextz, float size, int worldid, int interiorid, int playerid, float streamdistance, int areaid,
                int priority)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(14, 15, 16, 17)]
            public virtual int CreateDynamicRaceCPEx(int type, float x, float y, float z, float nextx, float nexty,
                float nextz, float size, float streamdistance, int[] worlds, int[] interiors, int[] players, int[] areas,
                int priority, int maxworlds, int maxinteriors, int maxplayers, int maxareas)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int DestroyDynamicRaceCP(int checkpointid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsValidDynamicRaceCP(int checkpointid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int TogglePlayerDynamicRaceCP(int playerid, int checkpointid, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int TogglePlayerAllDynamicRaceCPs(int playerid, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsPlayerInDynamicRaceCP(int playerid, int checkpointid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetPlayerVisibleDynamicRaceCP(int playerid)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}