// SampSharp.Streamer
// Copyright 2018 Tim Potze
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

        protected int[] GetArray(StreamerDataType data, int maxlength = -1)
        {
            return BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].GetArray(Id, data, maxlength);
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
            get
            {
                AssertNotDisposed();
                return GetInteger(StreamerDataType.InteriorId);
            }
            set
            {
                AssertNotDisposed();
                SetInteger(StreamerDataType.InteriorId, value);
            }
        }

        public virtual IEnumerable<int> Interiors
        {
            get
            {
                AssertNotDisposed();
                return GetArray(StreamerDataType.InteriorId).Where(v => v != int.MinValue);
            }
            set
            {
                AssertNotDisposed();
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
            get
            {
                AssertNotDisposed();
                return GetInteger(StreamerDataType.WorldId);
            }
            set
            {
                AssertNotDisposed();
                SetInteger(StreamerDataType.WorldId, value);
            }
        }

        public virtual int Priority
        {
            get
            {
                AssertNotDisposed();
                return GetInteger(StreamerDataType.Priority);
            }
            set
            {
                AssertNotDisposed();
                SetInteger(StreamerDataType.Priority, value);
            }
        }

        public virtual IEnumerable<int> Worlds
        {
            get
            {
                AssertNotDisposed();
                return GetArray(StreamerDataType.WorldId)?.Where(v => v != int.MinValue);
            }
            set
            {
                AssertNotDisposed();
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
            get
            {
                AssertNotDisposed();
                return BasePlayer.FindOrCreate(GetInteger(StreamerDataType.PlayerId));
            }
            set
            {
                AssertNotDisposed();
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                SetInteger(StreamerDataType.PlayerId, value.Id);
            }
        }

        public virtual DynamicArea Area
        {
            get
            {
                AssertNotDisposed();
                return DynamicArea.Find(GetInteger(StreamerDataType.AreaId));
            }
            set
            {
                AssertNotDisposed();
                SetInteger(StreamerDataType.AreaId, value?.Id ?? -1);
            }
        }

        public virtual IEnumerable<BasePlayer> Players
        {
            get
            {
                AssertNotDisposed();
                return
                    GetArray(StreamerDataType.PlayerId)
                        .Where(v => v != int.MinValue)
                        .Select(BasePlayer.FindOrCreate);
            }
            set
            {
                AssertNotDisposed();
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
            get
            {
                AssertNotDisposed();
                return GetFloat(StreamerDataType.StreamDistance);
            }
            set
            {
                AssertNotDisposed();
                SetFloat(StreamerDataType.StreamDistance, value);
            }
        }

        public virtual bool IsStatic
        {
            get
            {
                AssertNotDisposed();
                return WorldInternal.IsToggleItemStatic((int) StreamType, Id);
            }
            set
            {
                AssertNotDisposed();
                WorldInternal.ToggleItemStatic((int) StreamType, Id, value);
            }
        }

        public virtual bool IsCheckAreaInversed
        {
            get
            {
                AssertNotDisposed();
                return WorldInternal.IsToggleItemInvAreas((int) StreamType, Id);
            }
            set
            {
                AssertNotDisposed();
                WorldInternal.ToggleItemInvAreas((int) StreamType, Id, value);
            }
        }

        public virtual bool IsCallbacksEnabled
        {
            get
            {
                AssertNotDisposed();
                return WorldInternal.IsToggleItemCallbacks((int) StreamType, Id);
            }
            set
            {
                AssertNotDisposed();
                WorldInternal.ToggleItemCallbacks((int) StreamType, Id, value);
            }
        }

        public virtual Vector3 Position
        {
            get
            {
                AssertNotDisposed();
                return BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType]
                    .GetPosition(Id);

            }
            set
            {
                AssertNotDisposed();
                BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType]
                    .SetPosition(Id, value);
            }
        }

        public virtual Vector3 Offset
        {
            get
            {
                AssertNotDisposed();
                WorldInternal.GetItemOffset((int) StreamType, Id, out var x, out var y, out var z);
                return new Vector3(x, y, z);
            }
            set
            {
                AssertNotDisposed();
                WorldInternal.SetItemOffset((int) StreamType, Id, value.X, value.Y, value.Z);
            }
        }

        public virtual bool IsVisibleForPlayer(BasePlayer player)
        {
            AssertNotDisposed();
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return IsInArray(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void ShowForPlayer(BasePlayer player)
        {
            AssertNotDisposed();
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            AppendToArray(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void HideForPlayer(BasePlayer player)
        {
            AssertNotDisposed();
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            RemoveArrayData(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void ToggleItem(BasePlayer player, bool toggle)
        {
            AssertNotDisposed();
            WorldInternal.ToggleItem(player?.Id ?? -1, (int) StreamType, Id, toggle);
        }

        public virtual bool IsToggleItem(BasePlayer player)
        {
            AssertNotDisposed();
            return WorldInternal.IsToggleItem(player?.Id ?? -1, (int) StreamType, Id);
        }

        public virtual bool IsVisibleInWorld(int worldid)
        {
            AssertNotDisposed();
            return IsInArray(StreamerDataType.WorldId, worldid);
        }

        public virtual void ShowInWorld(int worlid)
        {
            AssertNotDisposed();
            AppendToArray(StreamerDataType.WorldId, worlid);
        }

        public virtual void HideInWorld(int worlid)
        {
            AssertNotDisposed();
            RemoveArrayData(StreamerDataType.WorldId, worlid);
        }

        public virtual bool IsVisibleInInterior(int interiorid)
        {
            AssertNotDisposed();
            return IsInArray(StreamerDataType.InteriorId, interiorid);
        }

        public virtual void ShowInInterior(int interiorid)
        {
            AssertNotDisposed();
            AppendToArray(StreamerDataType.InteriorId, interiorid);
        }

        public void HideInInterior(int interiorid)
        {
            AssertNotDisposed();
            RemoveArrayData(StreamerDataType.InteriorId, interiorid);
        }

        public void ToggleUpdate(BasePlayer player, bool toggle)
        {
            AssertNotDisposed();
            BaseMode.Instance.Services.GetService<IStreamer>().ItemType[StreamType].ToggleUpdate(player, toggle);
        }
    }
}