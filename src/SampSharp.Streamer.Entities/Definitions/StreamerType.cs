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

namespace SampSharp.Streamer.Entities
{
    /// <summary>
    /// Contains types of entities available in streamer.
    /// </summary>
    public enum StreamerType
    {
        /// <summary>
        /// All types provided by streamer.
        /// </summary>
        All = -1,
        /// <summary>
        /// A <see cref="DynamicObject"/>.
        /// </summary>
        Object = 0,
        /// <summary>
        /// A <see cref="DynamicPickup"/>.
        /// </summary>
        Pickup = 1,
        /// <summary>
        /// A <see cref="DynamicCheckpoint"/>.
        /// </summary>
        Checkpoint = 2,
        /// <summary>
        /// A <see cref="DynamicRaceCheckpoint"/>.
        /// </summary>
        RaceCheckpoint = 3,
        /// <summary>
        /// A <see cref="DynamicMapIcon"/>.
        /// </summary>
        MapIcon = 4,
        /// <summary>
        /// A <see cref="DynamicTextLabel"/>.
        /// </summary>
        TextLabel = 5,
        /// <summary>
        /// A <see cref="DynamicArea"/>.
        /// </summary>
        Area = 6,
        /// <summary>
        /// A dynamic actor.
        /// </summary>
        // TODO: Implement actor in SampSharp.Streamer.Entities.
        Actor = 7
    }
}