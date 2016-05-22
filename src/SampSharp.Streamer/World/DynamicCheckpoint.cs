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
            BasePlayer player = null, float streamdistance = 100.0f)
        {
            Id = Internal.CreateDynamicCP(position.X, position.Y, position.Z, size, worldid, interiorid,
                player?.Id ?? -1, streamdistance);
        }

        public DynamicCheckpoint(Vector3 position, float size, float streamdistance, int[] worlds = null,
            int[] interiors = null,
            BasePlayer[] players = null)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            Id = Internal.CreateDynamicCPEx(position.X, position.Y, position.Z, size, streamdistance, worlds, interiors,
                pl, worlds.Length, interiors.Length, pl.Length);
        }

        public bool IsValid => Internal.IsValidDynamicCP(Id);

        public override StreamType StreamType => StreamType.Checkpoint;

        public float Size
        {
            get { return GetFloat(StreamerDataType.Size); }
            set { SetFloat(StreamerDataType.Size, value); }
        }

        public event EventHandler<PlayerEventArgs> Enter;

        public event EventHandler<PlayerEventArgs> Leave;

        public void ToggleForPlayer(BasePlayer player, bool toggle)
        {
            AssertNotDisposed();

            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.TogglePlayerDynamicCP(player.Id, Id, toggle);
        }

        public bool IsPlayerInCheckpoint(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return Internal.IsPlayerInDynamicCP(player.Id, Id);
        }

        public static void ToggleAllForPlayer(BasePlayer player, bool toggle)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.TogglePlayerAllDynamicCPs(player.Id, toggle);
        }

        public static DynamicCheckpoint GetPlayerVisibleDynamicCheckpoint(BasePlayer player)
        {
            int id = Internal.GetPlayerVisibleDynamicCP(player.Id);

            return id < 0 ? null : FindOrCreate(id);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Internal.DestroyDynamicCP(Id);
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