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
        public static int GetTickRate()
        {
            return Native.CallNative("Streamer_GetTickRate");
        }

        public static int SetTickRate(int rate)
        {
            return Native.CallNative("Streamer_SetTickRate", __arglist(rate));
        }

        public static int GetMaxItems(StreamType type)
        {
            return Native.CallNative("Streamer_GetMaxItems", __arglist((int) type));
        }

        public static int SetMaxItems(StreamType type, int items)
        {
            return Native.CallNative("Streamer_SetMaxItems", __arglist((int) type, items));
        }

        public static int GetVisibleItems(StreamType type, int playerid = -1)
        {
            return Native.CallNative("Streamer_GetVisibleItems", __arglist((int) type, playerid));
        }

        public static int SetVisibleItems(StreamType type, int items, int playerid = -1)
        {
            return Native.CallNative("Streamer_SetVisibleItems", __arglist((int) type, items, playerid));
        }

        public static int GetRadiusMultiplier(StreamType type, out float multiplier, int playerid = -1)
        {
            return Native.CallNative("Streamer_GetRadiusMultiplier", __arglist((int) type, out multiplier, playerid));
        }

        public static int SetRadiusMultiplier(StreamType type, float multiplier, int playerid = -1)
        {
            return Native.CallNative("Streamer_SetRadiusMultiplier", __arglist((int) type, multiplier, playerid));
        }

        public static int GetCellDistance(out float distance)
        {
            return Native.CallNative("Streamer_GetCellDistance", __arglist(out distance));
        }

        public static int SetCellDistance(float distance)
        {
            return Native.CallNative("Streamer_SetCellDistance", __arglist(distance));
        }

        public static int GetCellSize(out float size)
        {
            return Native.CallNative("Streamer_GetCellSize", __arglist(out size));
        }

        public static int SetCellSize(float size)
        {
            return Native.CallNative("Streamer_SetCellSize", __arglist(size));
        }

        public static int ToggleErrorCallback(bool toggle)
        {
            return Native.CallNative("Streamer_ToggleErrorCallback", __arglist(toggle));
        }

        public static bool IsToggleErrorCallback()
        {
            return Native.CallNativeAsBool("Streamer_IsToggleErrorCallback");
        }
    }
}