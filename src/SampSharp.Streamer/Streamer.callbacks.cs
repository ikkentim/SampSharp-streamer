using System;
using System.Diagnostics;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Events;
using SampSharp.Streamer.World;

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
                    (EditObjectResponse) response, new Vector(x, y, z), new Vector(rx, ry, rz)));
        }

        internal void OnPlayerSelectDynamicObject(int playerid, int objectid, int modelid, float x, float y, float z)
        {
            OnPlayerSelectDynamicObject(DynamicObject.FindOrCreate(objectid),
                new PlayerSelectEventArgs(GtaPlayer.FindOrCreate(playerid), modelid,
                    new Vector(x, y, z)));
        }

        internal void OnPlayerShootDynamicObject(int playerid, int weaponid, int objectid, float x, float y, float z)
        {
            OnPlayerShootDynamicObject(DynamicObject.FindOrCreate(objectid),
                new PlayerShootEventArgs(GtaPlayer.FindOrCreate(playerid), (Weapon) weaponid,
                    new Vector(x, y, z)));
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