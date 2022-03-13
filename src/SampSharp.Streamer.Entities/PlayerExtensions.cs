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
        /// <summary>
        /// Starts the object editor for the specified <paramref name="dynamicObject"/>.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="dynamicObject">The object for which to open the editor.</param>
        public static void EditDynamicObject(this Player player, EntityId dynamicObject)
        {
            player.GetComponent<NativeStreamerPlayer>().EditDynamicObject(dynamicObject);
        }

        /// <summary>
        /// Gets the dynamic object the player is currently targeting.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>The dynamic object the player is currently targeting.</returns>
        public static EntityId GetCameraTargetDynamicObject(this Player player)
        {
            var id = player.GetComponent<NativeStreamerPlayer>().GetPlayerCameraTargetDynObject();
            return id == NativeDynamicObject.InvalidId ? EntityId.Empty : StreamerEntities.GetDynamicObjectId(id);
        }

        /// <summary>
        /// Gets a value indicating whether the player is in the specified <paramref name="dynamicCheckpoint"/>.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="dynamicCheckpoint">The checkpoint.</param>
        /// <returns><c>true</c> if the player is currently in the checkpoint; otherwise <c>false</c>.</returns>
        public static bool IsInDynamicCheckpoint(this Player player, EntityId dynamicCheckpoint)
        {
            return player.GetComponent<NativeStreamerPlayer>().IsPlayerInDynamicCP(dynamicCheckpoint);
        }

        /// <summary>
        /// Gets the currently visible checkpoint for the player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>The currently visible checkpoint.</returns>
        public static EntityId GetVisibleDynamicCheckpoint(this Player player)
        {
            var id = player.GetComponent<NativeStreamerPlayer>().GetPlayerVisibleDynamicCP();
            return id == NativeDynamicCheckpoint.InvalidId ? EntityId.Empty : StreamerEntities.GetDynamicCheckpointId(id);
        }

        
        /// <summary>
        /// Gets a value indicating whether the player is in the specified <paramref name="dynamicRaceCheckpoint"/>.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="dynamicRaceCheckpoint">The race checkpoint.</param>
        /// <returns><c>true</c> if the player is currently in the checkpoint; otherwise <c>false</c>.</returns>
        public static bool IsInDynamicRaceCheckpoint(this Player player, EntityId dynamicRaceCheckpoint)
        {
            return player.GetComponent<NativeStreamerPlayer>().IsPlayerInDynamicRaceCP(dynamicRaceCheckpoint);
        }
        
        /// <summary>
        /// Gets the currently visible race checkpoint for the player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>The currently visible race checkpoint.</returns>
        public static EntityId GetVisibleDynamicRaceCheckpoint(this Player player)
        {
            var id = player.GetComponent<NativeStreamerPlayer>().GetPlayerVisibleDynamicRaceCP();
            return id == NativeDynamicRaceCheckpoint.InvalidId ? EntityId.Empty : StreamerEntities.GetDynamicRaceCheckpointId(id);
        }

        /// <summary>
        /// Gets a value indicating whether the player is in the specified <paramref name="dynamicArea"/>.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="dynamicArea">The area.</param>
        /// <param name="recheck"><c>false</c> when a cached value may be used.</param>
        /// <returns><c>true</c> if the player is currently in the area; otherwise <c>false</c>.</returns>
        public static bool IsPlayerInDynamicArea(this Player player, EntityId dynamicArea, bool recheck = false)
        {
            return player.GetComponent<NativeStreamerPlayer>().IsPlayerInDynamicArea(dynamicArea, recheck);
        }

        /// <summary>
        /// Gets a value indicating whether the player is currently in any dynamic area.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="recheck"><c>false</c> when a cached value may be used.</param>
        /// <returns>A value indicating whether the player is currently in any dynamic area.</returns>
        public static bool IsPlayerInAnyDynamicArea(this Player player, bool recheck = false)
        {
            return player.GetComponent<NativeStreamerPlayer>().IsPlayerInAnyDynamicArea(recheck);
        }

        /// <summary>
        /// Gets the number of areas the player is currently in.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>The number of areas the player is currently in.</returns>
        public static int GetAreaCountForPlayer(this Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return player.GetComponent<NativeStreamerPlayer>().GetPlayerNumberDynamicAreas();
        }

        /// <summary>
        /// Gets the areas the player is currently in. 
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>The areas the player is currently in.</returns>
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