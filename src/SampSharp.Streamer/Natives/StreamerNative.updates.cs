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
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int ProcessActiveItems()
        {
            return Native.CallNative("Streamer_ProcessActiveItems");
        }

        public static int ToggleIdleUpdate(int playerid, bool toggle)
        {
            return Native.CallNative("Streamer_ToggleIdleUpdate", __arglist(playerid, toggle));
        }

        public static bool IsToggleIdleUpdate(int playerid)
        {
            return Native.CallNativeAsBool("Streamer_IsToggleIdleUpdate", __arglist(playerid));
        }

        public static int ToggleCameraUpdate(int playerid, bool toggle)
        {
            return Native.CallNative("Streamer_ToggleCameraUpdate", __arglist(playerid, toggle));
        }

        public static bool IsToggleCameraUpdate(int playerid)
        {
            return Native.CallNativeAsBool("Streamer_IsToggleCameraUpdate", __arglist(playerid));
        }

        public static int ToggleItemUpdate(int playerid, StreamType type, bool toggle)
        {
            return Native.CallNative("Streamer_ToggleItemUpdate", __arglist(playerid, (int) type, toggle));
        }

        public static int IsToggleItemUpdate(int playerid, StreamType type)
        {
            return Native.CallNative("Streamer_IsToggleItemUpdate", __arglist(playerid, (int) type));
        }

        public static int Update(int playerid)
        {
            return Native.CallNative("Streamer_Update", __arglist(playerid));
        }

        public static int Update(int playerid, StreamType type)
        {
            return Native.CallNative("Streamer_Update", __arglist(playerid, (int) type));
        }

        public static int UpdateEx(int playerid, float x, float y, float z, int worldid = -1, int interiorid = -1,
            StreamType type = StreamType.All)
        {
            return Native.CallNative("Streamer_UpdateEx", __arglist(playerid, x, y, z, worldid, interiorid, (int) type));
        }
    }
}