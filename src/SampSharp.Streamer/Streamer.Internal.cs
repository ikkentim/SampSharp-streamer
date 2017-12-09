// SampSharp.Streamer
// Copyright 2017 Tim Potze
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

namespace SampSharp.Streamer
{
    public partial class Streamer
    {
        protected static StreamerInternal Internal;

        static Streamer()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<StreamerInternal>();
        }

        public class StreamerInternal
        {
            [NativeMethod(Function = "Streamer_ProcessActiveItems")]
            public virtual int ProcessActiveItems()
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_ToggleIdleUpdate")]
            public virtual int ToggleIdleUpdate(int playerid, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_IsToggleIdleUpdate")]
            public virtual bool IsToggleIdleUpdate(int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_ToggleCameraUpdate")]
            public virtual int ToggleCameraUpdate(int playerid, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_IsToggleCameraUpdate")]
            public virtual bool IsToggleCameraUpdate(int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_Update")]
            public virtual int Update(int playerid, int type)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_UpdateEx")]
            public virtual int UpdateEx(int playerid, float x, float y, float z, int worldid, int interiorid, int type, int compensatedtime,
                int freezeplayer)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetFloatData")]
            public virtual int GetFloatData(int type, int id, int data, out float result)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetFloatData")]
            public virtual int SetFloatData(int type, int id, int data, float value)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetIntData")]
            public virtual int GetIntData(int type, int id, int data)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetIntData")]
            public virtual int SetIntData(int type, int id, int data, int value)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetArrayData")]
            public virtual int GetArrayData(int type, int id, int data, out int[] dest, int maxlength)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetArrayData")]
            public virtual int SetArrayData(int type, int id, int data, int[] src, int maxlength)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_IsInArrayData")]
            public virtual bool IsInArrayData(int type, int id, int data, int value)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_AppendArrayData")]
            public virtual int AppendArrayData(int type, int id, int data, int value)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_RemoveArrayData")]
            public virtual int RemoveArrayData(int type, int id, int data, int value)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetUpperBound")]
            public virtual int GetUpperBound(int type)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetTickRate")]
            public virtual int GetTickRate()
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetPlayerTickRate")]
            public virtual int SetPlayerTickRate(int playerid, int rate)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetPlayerTickRate")]
            public virtual int GetPlayerTickRate(int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_ToggleChunkStream")]
            public virtual int ToggleChunkStream(bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_IsToggleChunkStream")]
            public virtual bool IsToggleChunkStream()
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetChunkTickRate")]
            public virtual int GetChunkTickRate(int type, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetChunkTickRate")]
            public virtual int SetChunkTickRate(int type, int rate, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetChunkSize")]
            public virtual int GetChunkSize(int type)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetChunkSize")]
            public virtual int SetChunkSize(int type, int size)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetTickRate")]
            public virtual int SetTickRate(int rate)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetMaxItems")]
            public virtual int GetMaxItems(int type)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetMaxItems")]
            public virtual int SetMaxItems(int type, int items)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetVisibleItems")]
            public virtual int GetVisibleItems(int type, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetVisibleItems")]
            public virtual int SetVisibleItems(int type, int items, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetRadiusMultiplier")]
            public virtual int GetRadiusMultiplier(int type, out float multiplier, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetRadiusMultiplier")]
            public virtual int SetRadiusMultiplier(int type, float multiplier, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_ToggleItemInvAreas")]
            public virtual int ToggleItemInvAreas(int type, int id, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_ToggleItemCallbacks")]
            public virtual int ToggleItemCallbacks(int type, int id, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_IsToggleItemCallbacks")]
            public virtual int IsToggleItemCallbacks(int type, int id)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetCellDistance")]
            public virtual int GetCellDistance(out float distance)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetCellDistance")]
            public virtual int SetCellDistance(float distance)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetCellSize")]
            public virtual int GetCellSize(out float size)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetCellSize")]
            public virtual int SetCellSize(float size)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_ToggleErrorCallback")]
            public virtual int ToggleErrorCallback(bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_IsToggleErrorCallback")]
            public virtual bool IsToggleErrorCallback()
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_ToggleItemUpdate")]
            public virtual int ToggleItemUpdate(int playerid, int type, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_SetTypePriority")]
            public virtual int SetTypePriority(int[] types, int maxtypes)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetTypePriority")]
            public virtual int GetTypePriority(int[] types, int maxtypes)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetLastUpdateTime")]
            public virtual int GetLastUpdateTime(out float time)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetNearbyItems")]
            public virtual int GetNearbyItems(float x, float y, float z, int type, out int[] items, int maxitems, float range)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(Function = "Streamer_GetAllVisibleItems")]
            public virtual int GetAllVisibleItems(int playerid, int type, out int[] items, int maxitems)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public int GetPlayerCameraTargetDynObject(int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetPlayerTargetDynamicActor(int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetPlayerCameraTargetDynActor(int playerid)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}