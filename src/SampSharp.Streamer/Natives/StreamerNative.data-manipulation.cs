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

using System;
using SampSharp.GameMode.Natives;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int GetFloatData(StreamType type, int id, StreamerDataType data, out float result)
        {
            return Native.CallNative("Streamer_GetFloatData", __arglist((int) type, id, (int) data, out result));
        }

        public static int SetFloatData(StreamType type, int id, StreamerDataType data, float value)
        {
            return Native.CallNative("Streamer_SetFloatData", __arglist((int) type, id, (int) data, value));
        }

        public static int GetIntData(StreamType type, int id, StreamerDataType data)
        {
            return Native.CallNative("Streamer_GetIntData", __arglist((int) type, id, (int) data));
        }

        public static int SetIntData(StreamType type, int id, StreamerDataType data, int value)
        {
            return Native.CallNative("Streamer_SetIntData", __arglist((int) type, id, (int) data, value));
        }

        public static int GetArrayData(StreamType type, int id, StreamerDataType data, out int[] dest, int maxlength)
        {
            return Native.CallNative("Streamer_GetArrayData", __arglist((int) type, id, (int) data, out dest, maxlength));
        }

        public static int SetArrayData(StreamType type, int id, StreamerDataType data, int[] src, int maxlength = -1)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }

            if (maxlength == -1)
            {
                maxlength = src.Length;
            }

            return Native.CallNative("Streamer_SetArrayData", __arglist((int) type, id, (int) data, src, maxlength));
        }

        public static bool IsInArrayData(StreamType type, int id, StreamerDataType data, int value)
        {
            return Native.CallNativeAsBool("Streamer_IsInArrayData", __arglist((int) type, id, (int) data, value));
        }

        public static int AppendArrayData(StreamType type, int id, StreamerDataType data, int value)
        {
            return Native.CallNative("Streamer_AppendArrayData", __arglist((int) type, id, (int) data, value));
        }

        public static int RemoveArrayData(StreamType type, int id, StreamerDataType data, int value)
        {
            return Native.CallNative("Streamer_RemoveArrayData", __arglist((int) type, id, (int) data, value));
        }

        public static int GetUpperBound(StreamType type)
        {
            return Native.CallNative("Streamer_GetUpperBound", __arglist((int) type));
        }
    }
}