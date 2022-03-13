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

using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    /// <summary>
    /// Provides types of visible objects available in streamer and SampSharp.
    /// </summary>
    public enum StreamerObjectType
    {
        /// <summary>
        /// A <see cref="GlobalObject"/>.
        /// </summary>
        Global = 0,
        /// <summary>
        /// A <see cref="PlayerObject"/>.
        /// </summary>
        Player = 1,

        /// <summary>
        /// A <see cref="DynamicObject"/>.
        /// </summary>
        Dynamic = 2
    }
}