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
            return builder
                .EnableDynamicObjectEvents();
        }

        /// <summary>
        /// Enables all dynamic object related Streamer events.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The builder.</returns>
        public static IEcsBuilder EnableDynamicObjectEvents(this IEcsBuilder builder)
        {
            builder.EnableEvent<int>("OnDynamicObjectMoved");

            builder.UseMiddleware<EntityMiddleware>("OnDynamicObjectMoved", 0, StreamerEntities.DynamicObjectType, false);
            builder.UseMiddleware<StreamerPlayerConnectMiddleware>("OnPlayerConnect"); // TODO: Move elsewhere

            return builder;
        }

        public static void EditDynamicObject(this Player player, EntityId dynamicObject)
        {
            player.GetComponent<NativeStreamerPlayer>().EditDynamicObject(dynamicObject);
        }
    }
}