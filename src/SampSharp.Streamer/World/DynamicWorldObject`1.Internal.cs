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
        [NativeMethod(Function = "Streamer_IsToggleStaticItem")]
        public virtual bool IsToggleStaticItem(int type, int id)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "Streamer_ToggleStaticItem")]
        public virtual bool ToggleStaticItem(int type, int id, bool toggle)
        {
            throw new NativeNotImplementedException();
        }
    }
}