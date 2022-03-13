using System;
using System.Collections.Generic;
using System.Linq;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    /// <summary>
    /// Provides streamer methods for <see cref="Player"/> components.
    /// </summary>
    public static class PlayerExtensions
    {
        public static void EditDynamicObject(this Player player, EntityId dynamicObject)
        {
            player.GetComponent<NativeStreamerPlayer>().EditDynamicObject(dynamicObject);
        }

        public static EntityId GetCameraTargetDynamicObject(this Player player)
        {
            var id = player.GetComponent<NativeStreamerPlayer>().GetPlayerCameraTargetDynObject();
            return id == NativeDynamicObject.InvalidId ? EntityId.Empty : StreamerEntities.GetDynamicObjectId(id);
        }

        public static bool IsInDynamicCheckpoint(this Player player, EntityId dynamicCheckpointId)
        {
            return player.GetComponent<NativeStreamerPlayer>().IsPlayerInDynamicCP(dynamicCheckpointId);
        }

        public static EntityId GetVisibleDynamicCheckpoint(this Player player)
        {
            var id = player.GetComponent<NativeStreamerPlayer>().GetPlayerVisibleDynamicCP();
            return id == NativeDynamicCheckpoint.InvalidId ? EntityId.Empty : StreamerEntities.GetDynamicCheckpointId(id);
        }

        public static bool IsInDynamicRaceCheckpoint(this Player player, EntityId dynamicRaceCheckpointId)
        {
            return player.GetComponent<NativeStreamerPlayer>().IsPlayerInDynamicRaceCP(dynamicRaceCheckpointId);
        }

        public static EntityId GetVisibleDynamicRaceCheckpoint(this Player player)
        {
            var id = player.GetComponent<NativeStreamerPlayer>().GetPlayerVisibleDynamicRaceCP();
            return id == NativeDynamicRaceCheckpoint.InvalidId ? EntityId.Empty : StreamerEntities.GetDynamicRaceCheckpointId(id);
        }

        public static bool IsPlayerInDynamicArea(this Player player, EntityId dynamicAreaId, bool recheck = false)
        {
            return player.GetComponent<NativeStreamerPlayer>().IsPlayerInDynamicArea(dynamicAreaId, recheck);
        }

        public static bool IsPlayerInAnyDynamicArea(this Player player, bool recheck = false)
        {
            return player.GetComponent<NativeStreamerPlayer>().IsPlayerInAnyDynamicArea(recheck);
        }

        public static int GetAreaCountForPlayer(this Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return player.GetComponent<NativeStreamerPlayer>().GetPlayerNumberDynamicAreas();
        }

        public static IEnumerable<EntityId> GetAreasForPlayer(this Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            player.GetComponent<NativeStreamerPlayer>()
                .GetPlayerDynamicAreas(out var areas, GetAreaCountForPlayer(player));

            return areas.Select(StreamerEntities.GetDynamicAreaId);
        }
    }
}