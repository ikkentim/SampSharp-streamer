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
using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    /// <summary>
    /// Represents a component which provides the data and functionality of an dynamic map icon.
    /// </summary>
    public sealed class DynamicMapIcon : Component
    {
        private DynamicMapIcon(Vector3 position, MapIcon type, MapIconType style)
        {
            Position = position;
            Type = type;
            Style = style;
        }

        /// <summary>
        /// Gets whether this dynamic map icon is valid.
        /// </summary>
        public bool IsValid => GetComponent<NativeDynamicMapIcon>().IsValidDynamicMapIcon();

        /// <summary>
        /// Gets the position of this map icon.
        /// </summary>
        public Vector3 Position { get; }

        /// <summary>
        /// Gets the type of this map icon.
        /// </summary>
        public MapIcon Type { get; }

        /// <summary>
        /// Gets the style of this map icon.
        /// </summary>
        public MapIconType Style { get; }

        /// <summary>
        ///     The toggle map icon for specific player.
        /// </summary>
        /// <param name="player">The player to toggle (or not) the map icon.</param>
        /// <param name="toggle">TRUE to toggle.</param>
        /// <returns>
        ///     <see cref="bool"/>
        /// </returns>
        public bool ToggleForPlayer(Player player, bool toggle)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return GetComponent<NativeDynamicWorldObject>().ToggleItem(
                player.Entity.Handle, (int)StreamerType.MapIcon, this.Entity.Handle, toggle);
        }

        /// <inheritdoc />
        protected override void OnDestroyComponent()
        {
            GetComponent<NativeDynamicMapIcon>().DestroyDynamicMapIcon();
        }
    }
}