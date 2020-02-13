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
using SampSharp.Entities;

namespace SampSharp.Streamer.Entities
{
    /// <summary>
    /// Contains functions for constructing <see cref="EntityId" /> values for Streamer native entities.
    /// </summary>
    public static class StreamerEntities
    {
        /// <summary>
        ///     The Streamer dynamic object entity type identifier.
        /// </summary>
        [EntityType]
        public static readonly Guid DynamicObjectType = new Guid("DFDD0E7F-7351-4D13-AF60-665837B09DAC");

        /// <summary>
        ///     The Streamer dynamic pickup entity type identifier.
        /// </summary>
        [EntityType]
        public static readonly Guid DynamicPickupType = new Guid("5930AA01-BEB3-4ABA-9107-B63C84F7F4B8");

        /// <summary>
        /// Gets a dynamic object entity identifier based on an integer dynamic object identifier.
        /// </summary>
        /// <param name="objectId">The dynamic object identifier.</param>
        /// <returns>The entity identifier.</returns>
        public static EntityId GetDynamicObjectId(int objectId)
        {
            return new EntityId(DynamicObjectType, objectId);
        }

        /// <summary>
        /// Gets a dynamic pickup entity identifier based on an integer dynamic pickup identifier.
        /// </summary>
        /// <param name="pickupId">The dynamic pickup identifier.</param>
        /// <returns>The entity identifier.</returns>
        public static EntityId GetDynamicPickupId(int pickupId)
        {
            return new EntityId(DynamicPickupType, pickupId);
        }
    }
}