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
using SampSharp.GameMode.Events;
using SampSharp.Streamer.Events;
using SampSharp.Streamer.World;

namespace SampSharp.Streamer
{
    public partial class Streamer
    {
        public event EventHandler<EventArgs> DynamicObjectMoved;
        public event EventHandler<PlayerEditEventArgs> PlayerEditDynamicObject;
        public event EventHandler<PlayerSelectEventArgs> PlayerSelectDynamicObject;
        public event EventHandler<PlayerShootEventArgs> PlayerShootDynamicObject;
        public event EventHandler<PlayerEventArgs> PlayerPickUpDynamicPickup;
        public event EventHandler<PlayerEventArgs> PlayerEnterDynamicCheckpoint;
        public event EventHandler<PlayerEventArgs> PlayerLeaveDynamicCheckpoint;
        public event EventHandler<PlayerEventArgs> PlayerEnterDynamicRaceCheckpoint;
        public event EventHandler<PlayerEventArgs> PlayerLeaveDynamicRaceCheckpoint;
        public event EventHandler<PlayerEventArgs> PlayerEnterDynamicArea;
        public event EventHandler<PlayerEventArgs> PlayerLeaveDynamicArea;
        public event EventHandler<ErrorEventArgs> Error;

        protected virtual void OnDynamicObjectMoved(DynamicObject @object, EventArgs e)
        {
            if (DynamicObjectMoved != null)
                DynamicObjectMoved(@object, e);
        }

        protected virtual void OnPlayerEditDynamicObject(DynamicObject @object, PlayerEditEventArgs e)
        {
            if (PlayerEditDynamicObject != null)
                PlayerEditDynamicObject(@object, e);
        }

        protected virtual void OnPlayerSelectDynamicObject(DynamicObject @object, PlayerSelectEventArgs e)
        {
            if (PlayerSelectDynamicObject != null)
                PlayerSelectDynamicObject(@object, e);
        }

        protected virtual void OnPlayerShootDynamicObject(DynamicObject @object, PlayerShootEventArgs e)
        {
            if (PlayerShootDynamicObject != null)
                PlayerShootDynamicObject(@object, e);
        }

        protected virtual void OnPlayerPickUpDynamicPickup(DynamicPickup pickup, PlayerEventArgs e)
        {
            if (PlayerPickUpDynamicPickup != null)
                PlayerPickUpDynamicPickup(pickup, e);
        }

        protected virtual void OnPlayerEnterDynamicCheckpoint(DynamicCheckpoint checkpoint, PlayerEventArgs e)
        {
            if (PlayerEnterDynamicCheckpoint != null)
                PlayerEnterDynamicCheckpoint(checkpoint, e);
        }

        protected virtual void OnPlayerLeaveDynamicCheckpoint(DynamicCheckpoint checkpoint, PlayerEventArgs e)
        {
            if (PlayerLeaveDynamicCheckpoint != null)
                PlayerLeaveDynamicCheckpoint(checkpoint, e);
        }

        protected virtual void OnPlayerEnterDynamicRaceCheckpoint(DynamicRaceCheckpoint checkpoint, PlayerEventArgs e)
        {
            if (PlayerEnterDynamicRaceCheckpoint != null)
                PlayerEnterDynamicRaceCheckpoint(checkpoint, e);
        }

        protected virtual void OnPlayerLeaveDynamicRaceCheckpoint(DynamicRaceCheckpoint checkpoint, PlayerEventArgs e)
        {
            if (PlayerLeaveDynamicRaceCheckpoint != null)
                PlayerLeaveDynamicRaceCheckpoint(checkpoint, e);
        }

        protected virtual void OnPlayerEnterDynamicArea(DynamicArea area, PlayerEventArgs e)
        {
            if (PlayerEnterDynamicArea != null)
                PlayerEnterDynamicArea(area, e);
        }

        protected virtual void OnPlayerLeaveDynamicArea(DynamicArea area, PlayerEventArgs e)
        {
            if (PlayerLeaveDynamicArea != null)
                PlayerLeaveDynamicArea(area, e);
        }

        protected virtual void OnError(ErrorEventArgs e)
        {
            if (Error != null)
                Error(this, e);
        }
    }
}