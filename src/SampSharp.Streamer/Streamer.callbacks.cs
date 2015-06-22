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
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Events;
using SampSharp.Streamer.World;
using SampSharp.GameMode;

namespace SampSharp.Streamer
{
    public partial class Streamer
    {
        internal void OnDynamicObjectMoved(int objectid)
        {
            OnDynamicObjectMoved(DynamicObject.FindOrCreate(objectid), EventArgs.Empty);
        }

        internal void OnPlayerEditDynamicObject(int playerid, int objectid, int response, float x, float y, float z,
            float rx, float ry, float rz)
        {
            OnPlayerEditDynamicObject(DynamicObject.FindOrCreate(objectid),
                new PlayerEditEventArgs(GtaPlayer.FindOrCreate(playerid),
                    (EditObjectResponse) response, new Vector3(x, y, z), new Vector3(rx, ry, rz)));
        }

        internal void OnPlayerSelectDynamicObject(int playerid, int objectid, int modelid, float x, float y, float z)
        {
            OnPlayerSelectDynamicObject(DynamicObject.FindOrCreate(objectid),
                new PlayerSelectEventArgs(GtaPlayer.FindOrCreate(playerid), modelid,
                    new Vector3(x, y, z)));
        }

        internal void OnPlayerShootDynamicObject(int playerid, int weaponid, int objectid, float x, float y, float z)
        {
            OnPlayerShootDynamicObject(DynamicObject.FindOrCreate(objectid),
                new PlayerShootEventArgs(GtaPlayer.FindOrCreate(playerid), (Weapon) weaponid,
                    new Vector3(x, y, z)));
        }

        internal void OnPlayerPickUpDynamicPickup(int playerid, int pickupid)
        {
            OnPlayerPickUpDynamicPickup(DynamicPickup.FindOrCreate(pickupid),
                new PlayerEventArgs(GtaPlayer.FindOrCreate(playerid)));
        }

        internal void OnPlayerEnterDynamicCP(int playerid, int checkpointid)
        {
            OnPlayerEnterDynamicCheckpoint(DynamicCheckpoint.FindOrCreate(checkpointid),
                new PlayerEventArgs(GtaPlayer.FindOrCreate(playerid)));
        }

        internal void OnPlayerLeaveDynamicCP(int playerid, int checkpointid)
        {
            OnPlayerLeaveDynamicCheckpoint(DynamicCheckpoint.FindOrCreate(checkpointid),
                new PlayerEventArgs(GtaPlayer.FindOrCreate(playerid)));
        }

        internal void OnPlayerEnterDynamicRaceCP(int playerid, int checkpointid)
        {
            OnPlayerEnterDynamicRaceCheckpoint(DynamicRaceCheckpoint.FindOrCreate(checkpointid),
                new PlayerEventArgs(GtaPlayer.FindOrCreate(playerid)));
        }

        internal void OnPlayerLeaveDynamicRaceCP(int playerid, int checkpointid)
        {
            OnPlayerLeaveDynamicRaceCheckpoint(DynamicRaceCheckpoint.FindOrCreate(checkpointid),
                new PlayerEventArgs(GtaPlayer.FindOrCreate(playerid)));
        }

        internal void OnPlayerEnterDynamicArea(int playerid, int areaid)
        {
            OnPlayerEnterDynamicArea(DynamicArea.FindOrCreate(areaid),
                new PlayerEventArgs(GtaPlayer.FindOrCreate(playerid)));
        }

        internal void OnPlayerLeaveDynamicArea(int playerid, int areaid)
        {
            OnPlayerLeaveDynamicArea(DynamicArea.FindOrCreate(areaid),
                new PlayerEventArgs(GtaPlayer.FindOrCreate(playerid)));
        }

        internal void Streamer_OnPluginError(string error)
        {
            OnError(new ErrorEventArgs(error));
        }
    }
}