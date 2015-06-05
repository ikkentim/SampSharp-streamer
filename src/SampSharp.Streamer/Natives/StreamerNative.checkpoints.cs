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
        public static int CreateDynamicCP(float x, float y, float z, float size, int worldid = -1, int interiorid = -1,
            int playerid = -1, float streamdistance = 100.0f)
        {
            return Native.CallNative("CreateDynamicCP",
                __arglist(x, y, z, size, worldid, interiorid, playerid, streamdistance));
        }

        public static int DestroyDynamicCP(int checkpointid)
        {
            return Native.CallNative("DestroyDynamicCP", __arglist(checkpointid));
        }

        public static bool IsValidDynamicCP(int checkpointid)
        {
            return Native.CallNativeAsBool("IsValidDynamicCP", __arglist(checkpointid));
        }

        public static int TogglePlayerDynamicCP(int playerid, int checkpointid, bool toggle)
        {
            return Native.CallNative("TogglePlayerDynamicCP", __arglist(playerid, checkpointid, toggle));
        }

        public static int TogglePlayerAllDynamicCPs(int playerid, bool toggle)
        {
            return Native.CallNative("TogglePlayerAllDynamicCPs", __arglist(playerid, toggle));
        }

        public static bool IsPlayerInDynamicCP(int playerid, int checkpointid)
        {
            return Native.CallNativeAsBool("IsPlayerInDynamicCP", __arglist(playerid, checkpointid));
        }

        public static int GetPlayerVisibleDynamicCP(int playerid)
        {
            return Native.CallNative("GetPlayerVisibleDynamicCP", __arglist(playerid));
        }
    }
}