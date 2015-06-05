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

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int CreateDynamicPickup(int modelid, int type, float x, float y, float z, int worldid = -1,
            int interiorid = -1, int playerid = -1, float streamdistance = 100.0f)
        {
            return Native.CallNative("CreateDynamicPickup",
                __arglist(modelid, type, x, y, z, worldid, interiorid, playerid, streamdistance));
        }

        public static int DestroyDynamicPickup(int pickupid)
        {
            return Native.CallNative("DestroyDynamicPickup", __arglist(pickupid));
        }

        public static bool IsValidDynamicPickup(int pickupid)
        {
            return Native.CallNativeAsBool("IsValidDynamicPickup", __arglist(pickupid));
        }
    }
}