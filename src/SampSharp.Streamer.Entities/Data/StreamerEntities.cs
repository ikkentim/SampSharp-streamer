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
        ///     The Streamer dynamic checkpoint entity type identifier.
        /// </summary>
        [EntityType]
        public static readonly Guid DynamicCheckpointType = new Guid("1E80381E-44BE-4A06-8C79-6309E7DD9440");

        /// <summary>
        ///     The Streamer dynamic race checkpoint entity type identifier.
        /// </summary>
        [EntityType]
        public static readonly Guid DynamicRaceCheckpointType = new Guid("388F3E60-A176-473C-A4E2-D852F894DFDF");

        /// <summary>
        ///     The Streamer dynamic map icon entity type identifier.
        /// </summary>
        [EntityType]
        public static readonly Guid DynamicMapIconType = new Guid("595B2E88-FAC5-478F-9E60-191B63B352ED");
        
        /// <summary>
        ///     The Streamer dynamic text label entity type identifier.
        /// </summary>
        [EntityType]
        public static readonly Guid DynamicTextLabelType = new Guid("9A93A721-7B86-4D90-94A1-43CE918776A7");

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

        /// <summary>
        /// Gets a dynamic checkpoint entity identifier based on an integer dynamic checkpoint identifier.
        /// </summary>
        /// <param name="checkpointId">The dynamic checkpoint identifier.</param>
        /// <returns>The entity identifier.</returns>
        public static EntityId GetDynamicCheckpointId(int checkpointId)
        {
            return new EntityId(DynamicCheckpointType, checkpointId);
        }

        /// <summary>
        /// Gets a dynamic race checkpoint entity identifier based on an integer dynamic race checkpoint identifier.
        /// </summary>
        /// <param name="checkpointId">The dynamic race checkpoint identifier.</param>
        /// <returns>The entity identifier.</returns>
        public static EntityId GetDynamicRaceCheckpointId(int raceCheckpointId)
        {
            return new EntityId(DynamicRaceCheckpointType, raceCheckpointId);
        }

        /// <summary>
        /// Gets a dynamic map icon entity identifier based on an integer dynamic map icon identifier.
        /// </summary>
        /// <param name="mapIconId">The dynamic map icon identifier.</param>
        /// <returns>The entity identifier.</returns>
        public static EntityId GetDynamicMapIconId(int mapIconId)
        {
            return new EntityId(DynamicMapIconType, mapIconId);
        }

        /// <summary>
        /// Gets a dynamic text label entity identifier based on an integer dynamic text label identifier.
        /// </summary>
        /// <param name="mapIconId">The dynamic text label identifier.</param>
        /// <returns>The entity identifier.</returns>
        public static EntityId GetDynamicTextLabelId(int textLabelId)
        {
            return new EntityId(DynamicTextLabelType, textLabelId);
        }
    }
}