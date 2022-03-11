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
    public partial class DynamicActor
    {
        protected static readonly DynamicActorInternal Internal = NativeObjectProxyFactory.CreateInstance<DynamicActorInternal>();

        public class DynamicActorInternal
        {
            [NativeMethod]
            public virtual int CreateDynamicActor(int modelid, float x, float y, float z, float r, bool invulnerable, float health, int worldid,
                int interiorid, int playerid, float streamdistance, int areaid, int priority)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int DestroyDynamicActor(int actorid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsValidDynamicActor(int actorid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsDynamicActorStreamedIn(int actorid, int forplayerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicActorVirtualWorld(int actorid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicActorVirtualWorld(int actorid, int virtualworld)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(9, 10)]
            public virtual int GetDynamicActorAnimation(int actorid, out string animlib, out string animname, out float delta, out bool loop,
                out bool lockx, out bool locky, out bool freeze, out int time, int maxanimlib, int maxanimname)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int ApplyDynamicActorAnimation(int actorid, string animlib, string animname, float delta, bool loop, bool lockx,
                bool locky, bool freeze, int time)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int ClearDynamicActorAnimations(int actorid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicActorFacingAngle(int actorid, out float angle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicActorFacingAngle(int actorid, float angle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicActorPos(int actorid, out float x, out float y, out float z)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicActorPos(int actorid, float x, float y, float z)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicActorHealth(int actorid, out float health)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicActorHealth(int actorid, float health)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicActorInvulnerable(int actorid, bool invulnerable)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsDynamicActorInvulnerable(int actorid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(13, 14, 15, 16)]
            public virtual int CreateDynamicActorEx(int modelid, float x, float y, float z, float r, bool invulnerable, float health,
                float streamdistance, int[] worlds, int[] interiors, int[] players, int[] areas, int priority, int maxworlds, int maxinteriors,
                int maxplayers, int maxareas)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}