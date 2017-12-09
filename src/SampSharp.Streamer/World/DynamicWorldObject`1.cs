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

using System;
using System.Collections.Generic;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Pools;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public abstract partial class DynamicWorldObject<T> : IdentifiedPool<T>, IDynamicWorldObject where T : DynamicWorldObject<T>
    {
        protected int GetInteger(StreamerDataType data)
        {
            return BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].GetInteger(Id, data);
        }

        protected float GetFloat(StreamerDataType data)
        {
            return BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].GetFloat(Id, data);
        }

        protected int[] GetArray(StreamerDataType data, int maxlength)
        {
            return BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].GetArray(Id, data, maxlength);
        }

        protected IEnumerable<int> GetArrayClean(StreamerDataType data, int maxlength)
        {
            // NOTE: This will return unexpected results if the array contains multiple zeroes.
            var array = GetArray(data, maxlength);

            if (array == null)
                return null;

            // Find length of array (up to zeroes filling the end of the array)
            int length;
            for (length = array.Length; array[length - 1] == 0; length--)
            {
                ;
            }

            // Increase size by 1 if the array 0 up to length does not contain a zero, but the plugin reports it should contain a zero (so the last value in the array probably is a zero)
            var first0 = Array.IndexOf(array, 0);
            if (length < maxlength && first0 == length && IsInArray(data, 0))
                length++;

            return array.Take(length);
        }

        protected void AppendToArray(StreamerDataType data, int value)
        {
            BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].AppendToArray(Id, data, value);
        }

        protected void RemoveArrayData(StreamerDataType data, int value)
        {
            BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].RemoveArrayData(Id, data, value);
        }

        protected bool IsInArray(StreamerDataType data, int value)
        {
            return BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].IsInArray(Id, data, value);
        }

        protected void SetInteger(StreamerDataType data, int value)
        {
            BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].SetInteger(Id, data, value);
        }

        protected void SetFloat(StreamerDataType data, float value)
        {
            BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].SetFloat(Id, data, value);
        }

        protected void SetArray(StreamerDataType data, int[] value)
        {
            BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].SetArray(Id, data, value);
        }

        public abstract StreamType StreamType { get; }

        public virtual int Interior
        {
            get { return GetInteger(StreamerDataType.InteriorId); }
            set { SetInteger(StreamerDataType.InteriorId, value); }
        }

        public virtual IEnumerable<int> Interiors
        {
            get { return GetArrayClean(StreamerDataType.InteriorId, 1024).Where(v => v != int.MinValue); }
            set
            {
                if (value == null)
                {
                    SetArray(StreamerDataType.InteriorId, new[] { -1 });
                    return;
                }
                SetArray(StreamerDataType.InteriorId, value.ToArray());
            }
        }

        public virtual int World
        {
            get { return GetInteger(StreamerDataType.WorldId); }
            set { SetInteger(StreamerDataType.WorldId, value); }
        }

        public virtual int Priority
        {
            get { return GetInteger(StreamerDataType.Priority); }
            set { SetInteger(StreamerDataType.Priority, value); }
        }

        public virtual IEnumerable<int> Worlds
        {
            get { return GetArrayClean(StreamerDataType.WorldId, 1024)?.Where(v => v != int.MinValue); }
            set
            {
                if (value == null)
                {
                    SetArray(StreamerDataType.WorldId, new[] { -1 });
                    return;
                }
                SetArray(StreamerDataType.WorldId, value.ToArray());
            }
        }

        public virtual BasePlayer Player
        {
            get { return BasePlayer.FindOrCreate(GetInteger(StreamerDataType.PlayerId)); }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                SetInteger(StreamerDataType.PlayerId, value.Id);
            }
        }

        public virtual DynamicArea Area
        {
            get { return DynamicArea.Find(GetInteger(StreamerDataType.AreaId)); }
            set { SetInteger(StreamerDataType.AreaId, value?.Id ?? -1); }
        }

        public virtual IEnumerable<BasePlayer> Players
        {
            get
            {
                return
                    GetArrayClean(StreamerDataType.PlayerId, 1024)
                        .Where(v => v != int.MinValue)
                        .Select(BasePlayer.FindOrCreate);
            }
            set
            {
                if (value == null)
                {
                    SetArray(StreamerDataType.PlayerId, new[] { -1 });
                    return;
                }
                SetArray(StreamerDataType.PlayerId, value.Select(p => p?.Id ?? -1).ToArray());
            }
        }

        public virtual float StreamDistance
        {
            get { return GetFloat(StreamerDataType.StreamDistance); }
            set { SetFloat(StreamerDataType.StreamDistance, value); }
        }

        public virtual bool IsStatic
        {
            get { return WorldInternal.IsToggleItemStatic((int) StreamType, Id); }
            set { WorldInternal.ToggleItemStatic((int) StreamType, Id, value); }
        }

        public virtual bool IsCheckAreaInversed
        {
            get { return WorldInternal.IsToggleItemInvAreas((int) StreamType, Id); }
            set { WorldInternal.ToggleItemInvAreas((int) StreamType, Id, value); }
        }

        public virtual bool IsCallbacksEnabled
        {
            get { return WorldInternal.IsToggleItemCallbacks((int) StreamType, Id); }
            set { WorldInternal.ToggleItemCallbacks((int) StreamType, Id, value); }
        }

        public virtual Vector3 Position
        {
            get
            {
                return new Vector3(GetFloat(StreamerDataType.X),
                    GetFloat(StreamerDataType.Y),
                    GetFloat(StreamerDataType.Z));
            }
            set
            {
                SetFloat(StreamerDataType.X, value.X);
                SetFloat(StreamerDataType.Y, value.Y);
                SetFloat(StreamerDataType.Z, value.Z);
            }
        }

        public virtual Vector3 Offset
        {
            get
            {
                WorldInternal.GetItemOffset((int) StreamType, Id, out var x, out var y, out var z);
                return new Vector3(x, y, z);
            }
            set { WorldInternal.SetItemOffset((int) StreamType, Id, value.X, value.Y, value.Z); }
        }

        public virtual bool IsVisibleForPlayer(BasePlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return IsInArray(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void ShowForPlayer(BasePlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            AppendToArray(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void HideForPlayer(BasePlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            RemoveArrayData(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void ToggleItem(BasePlayer player, bool toggle)
        {
            WorldInternal.ToggleItem(player?.Id ?? -1, (int) StreamType, Id, toggle);
        }

        public virtual bool IsToggleItem(BasePlayer player)
        {
            return WorldInternal.IsToggleItem(player?.Id ?? -1, (int) StreamType, Id);
        }

        public virtual bool IsVisibleInWorld(int worldid)
        {
            return IsInArray(StreamerDataType.WorldId, worldid);
        }

        public void ShowInWorld(int worlid)
        {
            AppendToArray(StreamerDataType.WorldId, worlid);
        }

        public void HideInWorld(int worlid)
        {
            RemoveArrayData(StreamerDataType.WorldId, worlid);
        }

        public virtual bool IsVisibleInInterior(int interiorid)
        {
            return IsInArray(StreamerDataType.InteriorId, interiorid);
        }

        public void ShowInInterior(int interiorid)
        {
            AppendToArray(StreamerDataType.InteriorId, interiorid);
        }

        public void HideInInterior(int interiorid)
        {
            RemoveArrayData(StreamerDataType.InteriorId, interiorid);
        }

        public void ToggleUpdate(BasePlayer player, bool toggle)
        {
            BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].ToggleUpdate(player, toggle);
        }
    }
}