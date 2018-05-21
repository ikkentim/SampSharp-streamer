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
using SampSharp.Core.Callbacks;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Events;
using SampSharp.Streamer.World;

namespace SampSharp.Streamer
{
    public partial class Streamer
    {
        [Callback]
        internal void OnDynamicObjectMoved(int objectid)
        {
            var @object = DynamicObject.Find(objectid);

            if (@object == null)
                return;

            OnDynamicObjectMoved(@object, EventArgs.Empty);
        }

        [Callback]
        internal void OnPlayerEditDynamicObject(int playerid, int objectid, int response, float x, float y, float z,
            float rx, float ry, float rz)
        {
            var @object = DynamicObject.Find(objectid);

            if (@object == null)
                return;

            OnPlayerEditDynamicObject(DynamicObject.Find(objectid),
                new PlayerEditEventArgs(BasePlayer.FindOrCreate(playerid),
                    (EditObjectResponse) response, new Vector3(x, y, z), new Vector3(rx, ry, rz)));
        }

        [Callback]
        internal void OnPlayerSelectDynamicObject(int playerid, int objectid, int modelid, float x, float y, float z)
        {
            var @object = DynamicObject.Find(objectid);

            if (@object == null)
                return;

            OnPlayerSelectDynamicObject(@object,
                new PlayerSelectEventArgs(BasePlayer.FindOrCreate(playerid), modelid, new Vector3(x, y, z)));
        }

        [Callback]
        internal bool OnPlayerShootDynamicObject(int playerid, int weaponid, int objectid, float x, float y, float z)
        {
            var @object = DynamicObject.Find(objectid);

            if (@object == null)
                return false;

            var args = new PlayerShootEventArgs(BasePlayer.FindOrCreate(playerid), (Weapon) weaponid, new Vector3(x, y, z));
            OnPlayerShootDynamicObject(@object, args);

            return !args.PreventDamage;
        }

        [Callback]
        internal void OnPlayerPickUpDynamicPickup(int playerid, int pickupid)
        {
            var pickup = DynamicPickup.Find(pickupid);

            if (pickup == null)
                return;

            OnPlayerPickUpDynamicPickup(pickup, new PlayerEventArgs(BasePlayer.FindOrCreate(playerid)));
        }

        [Callback]
        internal void OnPlayerEnterDynamicCP(int playerid, int checkpointid)
        {
            var checkpoint = DynamicCheckpoint.Find(checkpointid);

            if (checkpoint == null)
                return;

            OnPlayerEnterDynamicCheckpoint(checkpoint, new PlayerEventArgs(BasePlayer.FindOrCreate(playerid)));
        }

        [Callback]
        internal void OnPlayerLeaveDynamicCP(int playerid, int checkpointid)
        {
            var checkpoint = DynamicCheckpoint.Find(checkpointid);

            if (checkpoint == null)
                return;

            OnPlayerLeaveDynamicCheckpoint(checkpoint, new PlayerEventArgs(BasePlayer.FindOrCreate(playerid)));
        }

        [Callback]
        internal void OnPlayerEnterDynamicRaceCP(int playerid, int checkpointid)
        {
            var checkpoint = DynamicRaceCheckpoint.Find(checkpointid);

            if (checkpoint == null)
                return;

            OnPlayerEnterDynamicRaceCheckpoint(checkpoint, new PlayerEventArgs(BasePlayer.FindOrCreate(playerid)));
        }

        [Callback]
        internal void OnPlayerLeaveDynamicRaceCP(int playerid, int checkpointid)
        {
            var checkpoint = DynamicRaceCheckpoint.Find(checkpointid);

            if (checkpoint == null)
                return;

            OnPlayerLeaveDynamicRaceCheckpoint(checkpoint, new PlayerEventArgs(BasePlayer.FindOrCreate(playerid)));
        }

        [Callback]
        internal void OnPlayerEnterDynamicArea(int playerid, int areaid)
        {
            var area = DynamicArea.Find(areaid);

            if (area == null)
                return;

            OnPlayerEnterDynamicArea(area, new PlayerEventArgs(BasePlayer.FindOrCreate(playerid)));
        }

        [Callback]
        internal void OnPlayerLeaveDynamicArea(int playerid, int areaid)
        {
            var area = DynamicArea.Find(areaid);

            if (area == null)
                return;

            OnPlayerLeaveDynamicArea(area, new PlayerEventArgs(BasePlayer.FindOrCreate(playerid)));
        }

        [Callback]
        internal void Streamer_OnPluginError(string error)
        {
            OnError(new ErrorEventArgs(error));
        }

        [Callback]
        internal int OnPlayerGiveDamageDynamicActor(int playerid, int actorid, float amount, int weaponid, int bodypart)
        {
            var args =
                new PlayerShotActorEventArgs(BasePlayer.FindOrCreate(playerid), (Weapon) weaponid, amount, (BodyPart) bodypart);
            var actor = DynamicActor.Find(actorid);

            if (actor != null)
            {
                // evt
            }

            return 0;
        }

        [Callback]
        internal void OnDynamicActorStreamIn(int actorid, int playerid)
        {
            var actor = DynamicActor.Find(actorid);

            if (actor == null)
                return;
        }

        [Callback]
        internal void OnDynamicActorStreamOut(int actorid, int playerid)
        {
            var actor = DynamicActor.Find(actorid);

            if (actor == null)
                return;
        }

        [Callback]
        internal void Streamer_OnItemStreamIn(int type, int id)
        {
        }

        [Callback]
        internal void Streamer_OnItemStreamOut(int type, int id)
        {
        }
    }
}