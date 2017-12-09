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
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public partial class DynamicPickup : DynamicWorldObject<DynamicPickup>
    {
        public DynamicPickup(int modelid, int type, Vector3 position, int worldid = -1, int interiorid = -1,
            BasePlayer player = null, float streamdistance = 100.0f, DynamicArea area = null, int priority = 0)
        {
            Id = Internal.CreateDynamicPickup(modelid, type, position.X, position.Y, position.Z, worldid,
                interiorid, player?.Id ?? -1, streamdistance, area?.Id ?? -1, priority);
        }

        public DynamicPickup(int modelid, int type, Vector3 position, float streamdistance, int[] worlds = null,
            int[] interiors = null, BasePlayer[] players = null, DynamicArea[] areas = null, int priority = 0)
        {
            if (worlds == null) worlds = new[] { -1 };
            if (interiors == null) interiors = new[] { -1 };
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] { -1 };
            var ar = areas?.Select(a => a.Id).ToArray() ?? new[] { -1 };

            Id = Internal.CreateDynamicPickupEx(modelid, type, position.X, position.Y, position.Z, streamdistance,
                worlds, interiors, pl, ar, priority, worlds.Length, interiors.Length, pl.Length, ar.Length);
        }

        public override StreamType StreamType => StreamType.Pickup;

        public virtual int Type
        {
            get { return GetInteger(StreamerDataType.Type); }
            set { SetInteger(StreamerDataType.Type, value); }
        }

        public virtual int ModelId
        {
            get { return GetInteger(StreamerDataType.ModelId); }
            set { SetInteger(StreamerDataType.ModelId, value); }
        }

        public virtual bool IsValid => Internal.IsValidDynamicPickup(Id);

        public event EventHandler<PlayerEventArgs> PickedUp;

        public static void ToggleAllItems(BasePlayer player, bool toggle, DynamicPickup[] exceptions)
        {
            var ids = exceptions?.Select(e => e.Id).ToArray() ?? new[] { -1 };
            WorldInternal.ToggleAllItems(player?.Id ?? -1, (int) StreamType.Pickup, toggle, ids,
                ids.Length);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Internal.DestroyDynamicPickup(Id);
        }

        public virtual void OnPickedUp(PlayerEventArgs e)
        {
            PickedUp?.Invoke(this, e);
        }
    }
}