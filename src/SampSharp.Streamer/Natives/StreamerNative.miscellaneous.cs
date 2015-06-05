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
        public static int GetDistanceToItem(float x, float y, float z, StreamType type, int id, out float distance,
            int dimensions = 3)
        {
            return Native.CallNative("Streamer_GetDistanceToItem",
                __arglist(x, y, z, (int) type, id, out distance, dimensions));
        }

        public static int ToggleStaticItem(StreamType type, int id, bool toggle)
        {
            return Native.CallNative("Streamer_ToggleStaticItem", __arglist((int) type, id, toggle));
        }

        public static bool IsToggleStaticItem(StreamType type, int id)
        {
            return Native.CallNativeAsBool("Streamer_IsToggleStaticItem", __arglist((int) type, id));
        }

        public static int GetItemInternalID(int playerid, StreamType type, int streamerid)
        {
            return Native.CallNative("Streamer_GetItemInternalID", __arglist(playerid, (int) type, streamerid));
        }

        public static int GetItemStreamerID(int playerid, StreamType type, int internalid)
        {
            return Native.CallNative("Streamer_GetItemStreamerID", __arglist(playerid, (int) type, internalid));
        }

        public static bool IsItemVisible(int playerid, StreamType type, int id)
        {
            return Native.CallNativeAsBool("Streamer_IsItemVisible", __arglist(playerid, (int) type, id));
        }

        public static int DestroyAllVisibleItems(int playerid, StreamType type, bool serverwide = true)
        {
            return Native.CallNative("Streamer_DestroyAllVisibleItems", __arglist(playerid, (int) type, serverwide));
        }

        public static int CountVisibleItems(int playerid, StreamType type, bool serverwide = true)
        {
            return Native.CallNative("Streamer_CountVisibleItems", __arglist(playerid, (int) type, serverwide));
        }

        public static int DestroyAllItems(StreamType type, bool serverwide = true)
        {
            return Native.CallNative("Streamer_DestroyAllItems", __arglist((int) type, serverwide));
        }

        public static int CountItems(StreamType type, bool serverwide = true)
        {
            return Native.CallNative("Streamer_CountItems", __arglist((int) type, serverwide));
        }
    }
}