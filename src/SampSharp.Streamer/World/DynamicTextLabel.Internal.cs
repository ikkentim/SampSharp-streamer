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
using SampSharp.GameMode.API.NativeObjects;

namespace SampSharp.Streamer.World
{
    public partial class DynamicTextLabel
    {
        protected static readonly DynamicTextLabelInternal Internal;

        static DynamicTextLabel()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<DynamicTextLabelInternal>();
        }

        protected class DynamicTextLabelInternal
        {
            [NativeMethod]
            public virtual int CreateDynamic3DTextLabel(string text, int color, float x, float y, float z,
                float drawdistance, int attachedplayer, int attachedvehicle, bool testlos, int worldid, int interiorid,
                int playerid, float streamdistance, int areaid, int priority)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(15, 16, 17, 18)]
            public virtual int CreateDynamic3DTextLabelEx(string text, int color, float x, float y, float z,
                float drawdistance, int attachedplayer, int attachedvehicle, bool testlos, float streamdistance,
                int[] worlds, int[] interiors, int[] players, int[] areas, int priority, int maxworlds, int maxinteriors,
                int maxplayers, int maxareas)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int DestroyDynamic3DTextLabel(int id)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsValidDynamic3DTextLabel(int id)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamic3DTextLabelText(int id, out string text, int maxlength)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int UpdateDynamic3DTextLabelText(int id, int color, string text)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}