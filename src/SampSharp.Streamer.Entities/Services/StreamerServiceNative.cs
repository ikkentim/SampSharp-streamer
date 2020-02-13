// SampSharp.Streamer
// Copyright 2020 Tim Potze
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

#pragma warning disable 1591

namespace SampSharp.Streamer.Entities
{
    public class StreamerServiceNative
    {
        #region Updates

        [NativeMethod]
        public virtual bool Streamer_Update(int playerid, int type)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual bool Streamer_UpdateEx(int playerid, float x, float y, float z, int worldid = -1, int interiorid = -1, int type = -1, int compensatedtime = -1, int freezeplayer = 1)
        {
            throw new NativeNotImplementedException();
        }

        #endregion

        #region Objects

        [NativeMethod]
        public virtual int CreateDynamicObject(int modelid, float x, float y, float z, float rx, float ry, float rz,
            int worldid, int interiorid, int playerid, float streamdistance, float drawdistance, int areaid,
            int priority)
        {
            throw new NativeNotImplementedException();
        }

        #endregion

        #region Pickups

        [NativeMethod]
        public virtual int CreateDynamicPickup(int modelid, int type, float x, float y, float z, int worldid,
            int interiorid, int playerid, float streamdistance, int areaid, int priority)
        {
            throw new NativeNotImplementedException();
        }

        #endregion

        #region Checkpoint

        [NativeMethod]
        public virtual int CreateDynamicCP(float x, float y, float z, float size, int worldid, int interiorid,
            int playerid, float streamdistance, int areaid, int priority)
        {
            throw new NativeNotImplementedException();
        }

        #endregion
    }
}