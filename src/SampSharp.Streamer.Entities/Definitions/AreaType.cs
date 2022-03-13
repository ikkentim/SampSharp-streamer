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
    /// Contains types of areas a see <see cref="DynamicArea"/> can cover.
    /// </summary>
    public enum AreaType
    {
        /// <summary>
        /// A circular area
        /// </summary>
        Circle = 0,

        /// <summary>
        /// A cylindrical area.
        /// </summary>
        Cylinder = 1,

        /// <summary>
        /// A spherical area
        /// </summary>
        Sphere = 2,

        /// <summary>
        /// A rectangular area.
        /// </summary>
        Rectangle = 3,

        /// <summary>
        /// A cuboidal area.
        /// </summary>
        Cuboid = 4,

        /// <summary>
        /// A polygonal area.
        /// </summary>
        Polygon = 5
    }
}