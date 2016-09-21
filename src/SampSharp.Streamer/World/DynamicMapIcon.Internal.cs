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
    public partial class DynamicMapIcon
    {
        protected static readonly DynamicMapIconInternal Internal;

        static DynamicMapIcon()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<DynamicMapIconInternal>();
        }

        protected class DynamicMapIconInternal
        {
            [NativeMethod]
            public virtual int CreateDynamicMapIcon(float x, float y, float z, int type, int color, int worldid,
                int interiorid, int playerid, float streamdistance, int style, int areaid, int priority)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int DestroyDynamicMapIcon(int iconid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsValidDynamicMapIcon(int iconid)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}