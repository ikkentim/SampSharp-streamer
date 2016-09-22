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

using System;
using System.Collections.Generic;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Pools;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public abstract partial class DynamicWorldObject<T> : IdentifiedPool<T>, IIdentifiable, IWorldObject
        where T : DynamicWorldObject<T>
    {
        public abstract StreamType StreamType { get; }

        public virtual int Interior
        {
            get { return GetInteger(StreamerDataType.InteriorId); }
            set { SetInteger(StreamerDataType.InteriorId, value); }
        }

        public virtual IEnumerable<int> Interiors
        {
            get { return GetArray(StreamerDataType.InteriorId, 1024).Where(v => v != int.MinValue); }
            set
            {
                if (value == null)
                {
                    SetArray(StreamerDataType.InteriorId, new[] {-1});
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
            get { return GetArray(StreamerDataType.WorldId, 1024).Where(v => v != int.MinValue); }
            set
            {
                if (value == null)
                {
                    SetArray(StreamerDataType.WorldId, new[] {-1});
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
                {
                    throw new ArgumentNullException(nameof(value));
                }
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
                    GetArray(StreamerDataType.PlayerId, 1024)
                        .Where(v => v != int.MinValue)
                        .Select(BasePlayer.FindOrCreate);
            }
            set
            {
                if (value == null)
                {
                    SetArray(StreamerDataType.PlayerId, new[] {-1});
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

        public virtual bool IsAntiAreas
        {
            get { return WorldInternal.IsToggleItemAntiAreas((int) StreamType, Id); }
            set { WorldInternal.ToggleItemAntiAreas((int) StreamType, Id, value); }
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

        public virtual bool IsVisibleForPlayer(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return IsInArray(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void ShowForPlayer(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            AppendToArray(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void HideForPlayer(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            RemoveArrayData(StreamerDataType.PlayerId, player.Id);
        }

        public virtual void ToggleItem(BasePlayer player, bool toggle)
        {
            WorldInternal.ToggleItem(player?.Id ?? -1, (int) StreamType, Id, toggle);
        }

        public virtual bool IsToggleItem(BasePlayer player)
        {
            return WorldInternal.IsToggleItem(player?.Id ?? -1, (int)StreamType, Id);
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
            Streamer.ItemType[StreamType].ToggleUpdate(player, toggle);
        }

        protected int GetInteger(StreamerDataType data)
        {
            return Streamer.ItemType[StreamType].GetInteger(Id, data);
        }

        protected float GetFloat(StreamerDataType data)
        {
            return Streamer.ItemType[StreamType].GetFloat(Id, data);
        }

        protected int[] GetArray(StreamerDataType data, int maxlength)
        {
            return Streamer.ItemType[StreamType].GetArray(Id, data, maxlength);
        }

        protected void AppendToArray(StreamerDataType data, int value)
        {
            Streamer.ItemType[StreamType].AppendToArray(Id, data, value);
        }

        protected void RemoveArrayData(StreamerDataType data, int value)
        {
            Streamer.ItemType[StreamType].RemoveArrayData(Id, data, value);
        }

        protected bool IsInArray(StreamerDataType data, int value)
        {
            return Streamer.ItemType[StreamType].IsInArray(Id, data, value);
        }

        protected void SetInteger(StreamerDataType data, int value)
        {
            Streamer.ItemType[StreamType].SetInteger(Id, data, value);
        }

        protected void SetFloat(StreamerDataType data, float value)
        {
            Streamer.ItemType[StreamType].SetFloat(Id, data, value);
        }

        protected void SetArray(StreamerDataType data, int[] value)
        {
            Streamer.ItemType[StreamType].SetArray(Id, data, value);
        }

        protected static T CreateWorldsInteriorsPlayers(int[] worlds, int[] interiors, BasePlayer[] players,
            Func<int[], int[], int[], int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            return FindOrCreate(func(worlds, interiors, pl, worlds.Length, interiors.Length, pl.Length));
        }

        protected static T CreateWorldsInteriorsPlayers<T1>(T1 arg1, int[] worlds, int[] interiors, BasePlayer[] players,
            Func<T1, int[], int[], int[], int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            return FindOrCreate(func(arg1, worlds, interiors, pl, worlds.Length, interiors.Length, pl.Length));
        }

        protected static T CreateWorldsInteriorsPlayers<T1, T2>(T1 arg1, T2 arg2, int[] worlds, int[] interiors,
            BasePlayer[] players, Func<T1, T2, int[], int[], int[], int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            return FindOrCreate(func(arg1, arg2, worlds, interiors, pl, worlds.Length, interiors.Length, pl.Length));
        }

        protected static T CreateWorldsInteriorsPlayers<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3, int[] worlds,
            int[] interiors, BasePlayer[] players, Func<T1, T2, T3, int[], int[], int[], int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            return
                FindOrCreate(func(arg1, arg2, arg3, worlds, interiors, pl, worlds.Length, interiors.Length, pl.Length));
        }

        protected static T CreateWorldsInteriorsPlayers<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, int[] worlds,
            int[] interiors, BasePlayer[] players, Func<T1, T2, T3, T4, int[], int[], int[], int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            return
                FindOrCreate(func(arg1, arg2, arg3, arg4, worlds, interiors, pl, worlds.Length, interiors.Length,
                    pl.Length));
        }

        protected static T CreateWorldsInteriorsPlayers<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
            int[] worlds, int[] interiors, BasePlayer[] players,
            Func<T1, T2, T3, T4, T5, int[], int[], int[], int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            return
                FindOrCreate(func(arg1, arg2, arg3, arg4, arg5, worlds, interiors, pl, worlds.Length, interiors.Length,
                    pl.Length));
        }

        protected static T CreateWorldsInteriorsPlayers<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4,
            T5 arg5, T6 arg6, int[] worlds, int[] interiors, BasePlayer[] players,
            Func<T1, T2, T3, T4, T5, T6, int[], int[], int[], int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            return
                FindOrCreate(func(arg1, arg2, arg3, arg4, arg5, arg6, worlds, interiors, pl, worlds.Length,
                    interiors.Length, pl.Length));
        }
    }
}