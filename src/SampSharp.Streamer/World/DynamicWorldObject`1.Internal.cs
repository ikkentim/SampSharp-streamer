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
    public partial class DynamicWorldObject<T>
    {
        protected static readonly DynamicWorldObjectInternal WorldInternal;

        static DynamicWorldObject()
        {
           WorldInternal = NativeObjectProxyFactory.CreateInstance<DynamicWorldObjectInternal>();
        }

    }

    public class DynamicWorldObjectInternal
    {
        [NativeMethod(Function = "Streamer_IsToggleItemStatic")]
        public virtual bool IsToggleItemStatic(int type, int id)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "Streamer_ToggleItemStatic")]
        public virtual bool ToggleItemStatic(int type, int id, bool toggle)
        {
            throw new NativeNotImplementedException();
        }
        [NativeMethod(Function = "Streamer_IsToggleItem")]
        public virtual bool IsToggleItem(int playerid, int type, int id)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "Streamer_ToggleItem")]
        public virtual bool ToggleItem(int playerid, int type, int id, bool toggle)
        {
            throw new NativeNotImplementedException();
        }


        [NativeMethod(Function = "Streamer_ToggleAllItems")]
        public virtual bool ToggleAllItems(int playerid, int type, bool toggle, int[] exceptions, int maxexceptions)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "Streamer_ToggleItemAntiAreas")]
        public virtual bool ToggleItemAntiAreas(int type, int id, bool toggle)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "Streamer_IsToggleItemAntiAreas")]
        public virtual bool IsToggleItemAntiAreas(int type, int id)
        {
            throw new NativeNotImplementedException();
        }
    }
}