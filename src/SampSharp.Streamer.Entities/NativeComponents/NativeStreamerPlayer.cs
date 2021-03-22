// SampSharp.Streamer
// Copyright 2020 Tim Potze
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

using SampSharp.Core.Natives.NativeObjects;
using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    public class NativeStreamerPlayer : BaseNativeComponent
    {
        #region Objects

        [NativeMethod]
        public virtual void EditDynamicObject(int dynamicObjectId)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetPlayerCameraTargetDynObject()
        {
            throw new NativeNotImplementedException();
        }

        #endregion

        #region Checkpoints

        [NativeMethod]
        public virtual bool IsPlayerInDynamicCP(int dynamicCheckpointId)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetPlayerVisibleDynamicCP()
        {
            throw new NativeNotImplementedException();
        }

        #endregion

        #region Race Checkpoints

        [NativeMethod]
        public virtual bool IsPlayerInDynamicRaceCP(int dynamicRaceCheckpointId)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetPlayerVisibleDynamicRaceCP()
        {
            throw new NativeNotImplementedException();
        }

        #endregion

        #region Area

        [NativeMethod]
        public virtual bool IsPlayerInDynamicArea(int dynamicAreaId, bool recheck = false)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual bool IsPlayerInAnyDynamicArea(bool recheck = false)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetPlayerNumberDynamicAreas()
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetPlayerDynamicAreas(out int[] areas, int maxlength)
        {
            throw new NativeNotImplementedException();
        }

        #endregion
    }
}