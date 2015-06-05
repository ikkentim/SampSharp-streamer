// SampSharp.Streamer
// Copyright 2015 Tim Potze
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
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.Natives;

namespace SampSharp.Streamer.World
{
    public class DynamicPickup : DynamicWorldObject<DynamicPickup>
    {
        public DynamicPickup(int id)
        {
            Id = id;
        }

        public DynamicPickup(int modelid, int type, Vector position, int worldid = -1, int interiorid = -1,
            GtaPlayer player = null, float streamdistance = 100.0f)
        {
            Id = StreamerNative.CreateDynamicPickup(modelid, type, position.X, position.Y, position.Z, worldid,
                interiorid, player == null ? -1 : player.Id, streamdistance);
        }

        public DynamicPickup(int modelid, int type, Vector position, float streamdistance, int[] worlds = null,
            int[] interiors = null, GtaPlayer[] players = null)
        {
            Id = StreamerNative.CreateDynamicPickupEx(modelid, type, position.X, position.Y, position.Z, streamdistance,
                worlds, interiors, players == null ? null : players.Select(p => p.Id).ToArray());
        }

        public override StreamType StreamType
        {
            get { return StreamType.Pickup; }
        }

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

        public virtual bool IsValid
        {
            get { return StreamerNative.IsValidDynamicPickup(Id); }
        }

        public event EventHandler<PlayerEventArgs> PickedUp;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            StreamerNative.DestroyDynamicPickup(Id);
        }

        public virtual void OnPickedUp(PlayerEventArgs e)
        {
            if (PickedUp != null)
                PickedUp(this, e);
        }
    }
}