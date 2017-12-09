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
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public partial class DynamicRaceCheckpoint : DynamicWorldObject<DynamicRaceCheckpoint>
    {
        public DynamicRaceCheckpoint(CheckpointType type, Vector3 position, Vector3 nextPosition,
            float size = 3.0f, int worldid = -1, int interiorid = -1, BasePlayer player = null,
            float streamdistance = 100.0f, DynamicArea area = null, int priority = 0)
        {
            Id = Internal.CreateDynamicRaceCP((int) type, position.X, position.Y, position.Z, nextPosition.X,
                nextPosition.Y, nextPosition.Z, size, worldid, interiorid, player?.Id ?? -1,
                streamdistance, area?.Id ?? -1, priority);
        }

        public DynamicRaceCheckpoint(CheckpointType type, Vector3 position, Vector3 nextPosition,
            float size, float streamdistance, int[] worlds = null, int[] interiors = null,
            BasePlayer[] players = null, DynamicArea[] areas = null, int priority = 0)
        {
            if (worlds == null) worlds = new[] { -1 };
            if (interiors == null) interiors = new[] { -1 };
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] { -1 };
            var ar = areas?.Select(a => a.Id).ToArray() ?? new[] { -1 };

            Id = Internal.CreateDynamicRaceCPEx((int) type, position.X, position.Y, position.Z, nextPosition.X,
                nextPosition.Y, nextPosition.Z, size, streamdistance, worlds, interiors, pl, ar, priority, worlds.Length,
                interiors.Length, pl.Length, ar.Length);
        }

        public bool IsValid => Internal.IsValidDynamicRaceCP(Id);

        public override StreamType StreamType => StreamType.RaceCheckpoint;

        public float Size
        {
            get { return GetFloat(StreamerDataType.Size); }
            set { SetFloat(StreamerDataType.Size, value); }
        }

        public virtual Vector3 NextPosition
        {
            get
            {
                var x = GetFloat(StreamerDataType.NextX);
                var y = GetFloat(StreamerDataType.NextY);
                var z = GetFloat(StreamerDataType.NextZ);

                return new Vector3(x, y, z);
            }
            set
            {
                SetFloat(StreamerDataType.NextX, value.X);
                SetFloat(StreamerDataType.NextY, value.Y);
                SetFloat(StreamerDataType.NextZ, value.Z);
            }
        }

        public event EventHandler<PlayerEventArgs> Enter;

        public event EventHandler<PlayerEventArgs> Leave;

        public void ToggleForPlayer(BasePlayer player, bool toggle)
        {
            AssertNotDisposed();

            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.TogglePlayerDynamicRaceCP(player.Id, Id, toggle);
        }

        public bool IsPlayerInCheckpoint(BasePlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return Internal.IsPlayerInDynamicRaceCP(player.Id, Id);
        }

        public static void ToggleAllForPlayer(BasePlayer player, bool toggle)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.TogglePlayerAllDynamicRaceCPs(player.Id, toggle);
        }

        public static DynamicRaceCheckpoint GetPlayerVisibleDynamicCheckpoint(BasePlayer player)
        {
            var id = Internal.GetPlayerVisibleDynamicRaceCP(player.Id);

            return id < 0 ? null : FindOrCreate(id);
        }

        public static void ToggleAllItems(BasePlayer player, bool toggle, DynamicRaceCheckpoint[] exceptions)
        {
            var ids = exceptions?.Select(e => e.Id).ToArray() ?? new[] { -1 };
            WorldInternal.ToggleAllItems(player?.Id ?? -1, (int) StreamType.RaceCheckpoint, toggle, ids,
                ids.Length);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Internal.DestroyDynamicRaceCP(Id);
        }

        public virtual void OnEnter(PlayerEventArgs e)
        {
            Enter?.Invoke(this, e);
        }

        public virtual void OnLeave(PlayerEventArgs e)
        {
            Leave?.Invoke(this, e);
        }
    }
}