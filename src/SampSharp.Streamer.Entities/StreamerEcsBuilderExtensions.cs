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
                .EnableDynamicCheckpointEvents();

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

        #endregion
    }
}