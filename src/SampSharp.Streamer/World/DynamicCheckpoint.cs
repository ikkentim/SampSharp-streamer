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
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public partial class DynamicCheckpoint : DynamicWorldObject<DynamicCheckpoint>
    {
        public DynamicCheckpoint(Vector3 position, float size = 1.0f, int worldid = -1, int interiorid = -1,
            BasePlayer player = null, float streamdistance = 100.0f, DynamicArea area = null, int priority = 0)
        {
            Id = Internal.CreateDynamicCP(position.X, position.Y, position.Z, size, worldid, interiorid,
                player?.Id ?? -1, streamdistance, area?.Id ?? -1, priority);
        }

        public DynamicCheckpoint(Vector3 position, float size, float streamdistance, int[] worlds = null,
            int[] interiors = null, BasePlayer[] players = null, DynamicArea[] areas = null, int priority = 0)
        {
            if (worlds == null) worlds = new[] { -1 };
            if (interiors == null) interiors = new[] { -1 };
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] { -1 };
            var ar = areas?.Select(a => a.Id).ToArray() ?? new[] { -1 };

            Id = Internal.CreateDynamicCPEx(position.X, position.Y, position.Z, size, streamdistance, worlds, interiors,
                pl, ar, priority, worlds.Length, interiors.Length, pl.Length, ar.Length);
        }

        public bool IsValid
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsValidDynamicCP(Id);
            }
        }

        public override StreamType StreamType
        {
            get
            {
                AssertNotDisposed();
                return StreamType.Checkpoint;
            }
        }

        public float Size
        {
            get
            {
                AssertNotDisposed();
                return GetFloat(StreamerDataType.Size);
            }
            set
            {
                AssertNotDisposed();
                SetFloat(StreamerDataType.Size, value);
            }
        }

        public event EventHandler<PlayerEventArgs> Enter;

        public event EventHandler<PlayerEventArgs> Leave;

        public void ToggleForPlayer(BasePlayer player, bool toggle)
        {
            AssertNotDisposed();

            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.TogglePlayerDynamicCP(player.Id, Id, toggle);
        }

        public bool IsPlayerInCheckpoint(BasePlayer player)
        {
            AssertNotDisposed();

            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return Internal.IsPlayerInDynamicCP(player.Id, Id);
        }

        public static void ToggleAllForPlayer(BasePlayer player, bool toggle)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.TogglePlayerAllDynamicCPs(player.Id, toggle);
        }

        public static DynamicCheckpoint GetPlayerVisibleDynamicCheckpoint(BasePlayer player)
        {
            var id = Internal.GetPlayerVisibleDynamicCP(player.Id);

            return id < 0 ? null : FindOrCreate(id);
        }

        public static void ToggleAllItems(BasePlayer player, bool toggle, DynamicCheckpoint[] exceptions)
        {
            var ids = exceptions?.Select(e => e.Id).ToArray() ?? new[] { -1 };
            WorldInternal.ToggleAllItems(player?.Id ?? -1, (int) StreamType.Checkpoint, toggle, ids,
                ids.Length);
        }

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            base.Dispose(disposing);

            Internal.DestroyDynamicCP(Id);
        }

        public virtual void OnEnter(PlayerEventArgs e)
        {
            AssertNotDisposed();
            Enter?.Invoke(this, e);
        }

        public virtual void OnLeave(PlayerEventArgs e)
        {
            AssertNotDisposed();
            Leave?.Invoke(this, e);
        }
    }
}