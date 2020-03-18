// SampSharp.Streamer
// Copyright 2020 Tim Potze
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
using System.Collections.Generic;
using System.Linq;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    /// <summary>
    /// Provides methods for enabling Streamer systems in an <see cref="IEcsBuilder" /> instance.
    /// </summary>
    public static class SampEcsBuilderExtensions
    {
        /// <summary>
        /// Enables all dynamic object related Streamer events.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The builder.</returns>
        public static IEcsBuilder EnableStreamerEvents(this IEcsBuilder builder)
        {
            builder
                .UseMiddleware<StreamerPlayerConnectMiddleware>("OnPlayerConnect");

            builder
                .EnableDynamicObjectEvents()
                .EnableDynamicPickupEvents()
                .EnableDynamicCheckpointEvents()
                .EnableDynamicRaceCheckpointEvents()
                .EnableDynamicAreaEvents();

            return builder;
        }

        /// <summary>
        /// Enables all dynamic object related Streamer events.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The builder.</returns>
        public static IEcsBuilder EnableDynamicObjectEvents(this IEcsBuilder builder)
        {
            builder.EnableEvent<int>("OnDynamicObjectMoved");
            builder.EnableEvent<int, int, int, float, float, float, float, float, float>("OnPlayerEditDynamicObject");
            builder.EnableEvent<int, int, int, float, float, float>("OnPlayerSelectDynamicObject");
            builder.EnableEvent<int, int, int, float, float, float>("OnPlayerShootDynamicObject");

            builder.UseMiddleware<EntityMiddleware>("OnDynamicObjectMoved", 0, StreamerEntities.DynamicObjectType, false);
            builder.UseMiddleware<PlayerEditDynamicObjectMiddleware>("OnPlayerEditDynamicObject");
            builder.UseMiddleware<PlayerSelectDynamicObjectMiddleware>("OnPlayerSelectDynamicObject");
            builder.UseMiddleware<PlayerShootDynamicObjectMiddleware>("OnPlayerShootDynamicObject");

            return builder;
        }

        /// <summary>
        /// Enables all dynamic pickup related Streamer events.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The builder.</returns>
        public static IEcsBuilder EnableDynamicPickupEvents(this IEcsBuilder builder)
        {
            builder.EnableEvent<int, int>("OnPlayerPickUpDynamicPickup");

            builder.UseMiddleware<PlayerPickupDynamicPickupMiddleware>("OnPlayerPickUpDynamicPickup");

            return builder;
        }

        /// <summary>
        /// Enables all dynamic checkpoint related Streamer events.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The builder.</returns>
        public static IEcsBuilder EnableDynamicCheckpointEvents(this IEcsBuilder builder)
        {
            builder.EnableEvent<int, int>("OnPlayerEnterDynamicCP");
            builder.EnableEvent<int, int>("OnPlayerLeaveDynamicCP");

            builder.UseMiddleware<PlayerEnterDynamicCheckpointMiddleware>("OnPlayerEnterDynamicCP");
            builder.UseMiddleware<PlayerLeaveDynamicCheckpointMiddleware>("OnPlayerLeaveDynamicCP");

            return builder;
        }

        /// <summary>
        /// Enables all dynamic race checkpoint related Streamer events.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The builder.</returns>
        public static IEcsBuilder EnableDynamicRaceCheckpointEvents(this IEcsBuilder builder)
        {
            builder.EnableEvent<int, int>("OnPlayerEnterDynamicRaceCP");
            builder.EnableEvent<int, int>("OnPlayerLeaveDynamicRaceCP");

            builder.UseMiddleware<PlayerEnterDynamicRaceCheckpointMiddleware>("OnPlayerEnterDynamicRaceCP");
            builder.UseMiddleware<PlayerLeaveDynamicRaceCheckpointMiddleware>("OnPlayerLeaveDynamicRaceCP");

            return builder;
        }

        /// <summary>
        /// Enables all dynamic area related Streamer events.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The builder.</returns>
        public static IEcsBuilder EnableDynamicAreaEvents(this IEcsBuilder builder)
        {
            builder.EnableEvent<int, int>("OnPlayerEnterDynamicArea");
            builder.EnableEvent<int, int>("OnPlayerLeaveDynamicArea");

            builder.UseMiddleware<PlayerEnterDynamicAreaMiddleware>("OnPlayerEnterDynamicArea");
            builder.UseMiddleware<PlayerLeaveDynamicAreaMiddleware>("OnPlayerLeaveDynamicArea");

            return builder;
        }

        #region Player Extensions

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

        // ToDo
        /*public static IEnumerable<DynamicArea> GetAreasForPlayer(this Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            player.GetComponent<NativeStreamerPlayer>().GetPlayerDynamicAreas(out var areas, GetAreaCountForPlayer(player));

            return areas?.Select(FindOrCreate);
        }*/

        #endregion
    }
}