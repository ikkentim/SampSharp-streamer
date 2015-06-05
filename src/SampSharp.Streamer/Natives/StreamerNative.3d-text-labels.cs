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

using SampSharp.GameMode.Natives;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int CreateDynamic3DTextLabel(string text, int color, float x, float y, float z,
            float drawdistance, int attachedplayer = GtaPlayer.InvalidId, int attachedvehicle = GtaVehicle.InvalidId,
            bool testlos = false, int worldid = -1, int interiorid = -1, int playerid = -1,
            float streamdistance = 100.0f)
        {
            return Native.CallNative("CreateDynamic3DTextLabel",
                __arglist(
                    text, color, x, y, z, drawdistance, attachedplayer, attachedvehicle, testlos, worldid,
                    interiorid, playerid, streamdistance));
        }

        public static int DestroyDynamic3DTextLabel(int id)
        {
            return Native.CallNative("DestroyDynamic3DTextLabel", __arglist(id));
        }

        public static bool IsValidDynamic3DTextLabel(int id)
        {
            return Native.CallNativeAsBool("IsValidDynamic3DTextLabel", __arglist(id));
        }

        public static int GetDynamic3DTextLabelText(int id, out string text, int maxlength)
        {
            return Native.CallNative("GetDynamic3DTextLabelText", __arglist(id, out text, maxlength));
        }

        public static int UpdateDynamic3DTextLabelText(int id, Color color, string text)
        {
            return Native.CallNative("UpdateDynamic3DTextLabelText", __arglist(id, (int) color, text));
        }
    }
}