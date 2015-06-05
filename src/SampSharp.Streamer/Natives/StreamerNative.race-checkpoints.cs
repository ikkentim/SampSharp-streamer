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

using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Natives;

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int CreateDynamicRaceCP(CheckpointType type, float x, float y, float z, float nextx, float nexty,
            float nextz,
            float size, int worldid = -1, int interiorid = -1, int playerid = -1, float streamdistance = 100.0f)
        {
            return Native.CallNative("CreateDynamicRaceCP",
                __arglist((int) type, x, y, z, nextx, nexty, nextz, size, worldid, interiorid, playerid, streamdistance));
        }

        public static int DestroyDynamicRaceCP(int checkpointid)
        {
            return Native.CallNative("DestroyDynamicRaceCP", __arglist(checkpointid));
        }

        public static bool IsValidDynamicRaceCP(int checkpointid)
        {
            return Native.CallNativeAsBool("IsValidDynamicRaceCP", __arglist(checkpointid));
        }

        public static int TogglePlayerDynamicRaceCP(int playerid, int checkpointid, bool toggle)
        {
            return Native.CallNative("TogglePlayerDynamicRaceCP", __arglist(playerid, checkpointid, toggle));
        }

        public static int TogglePlayerAllDynamicRaceCPs(int playerid, bool toggle)
        {
            return Native.CallNative("TogglePlayerAllDynamicRaceCPs", __arglist(playerid, toggle));
        }

        public static bool IsPlayerInDynamicRaceCP(int playerid, int checkpointid)
        {
            return Native.CallNativeAsBool("IsPlayerInDynamicRaceCP", __arglist(playerid, checkpointid));
        }

        public static int GetPlayerVisibleDynamicRaceCP(int playerid)
        {
            return Native.CallNative("GetPlayerVisibleDynamicRaceCP", __arglist(playerid));
        }
    }
}