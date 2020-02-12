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
    ///     Provides functionality for adding entities to and controlling the Streamer.
    /// </summary>
    public interface IStreamerService
    {
        /// <summary>
        ///     Creates a new Dynamic Object in the world.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="virtualWorld">The virtual world.</param>
        /// <param name="interior">The interior.</param>
        /// <param name="player">The attached player.</param>
        /// <param name="streamDistance">The stream distance.</param>
        /// <param name="drawDistance">The draw distance.</param>
        /// <param name="areaid">The attached area id.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="parent">The EntityId parent.</param>
        /// <returns>
        ///     <see cref="DynamicObject"/>
        /// </returns>
        DynamicObject CreateDynamicObject(int modelId, Vector3 position, Vector3 rotation,
            int virtualWorld = -1, int interior = -1, EntityId player = default, float streamDistance = 200.0f,
            float drawDistance = 0.0f, int areaid = -1, int priority = 0, EntityId parent = default);
    }
}
