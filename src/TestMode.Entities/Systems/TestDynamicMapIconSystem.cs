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
using SampSharp.Entities.SAMP.Commands;

using SampSharp.Streamer.Entities;

namespace TestMode.Entities.Systems
{
    /// <summary>
    /// System to test Dynamic Map Icon.
    /// </summary>
    public class TestDynamicMapIconSystem : ISystem
    {
        [PlayerCommand]
        public void CreateMapIconCommand(Player player, MapIcon mapIcon, IStreamerService streamerService)
        {
            var dynamicMapIcon = streamerService.CreateDynamicMapIcon(player.Position, mapIcon, Color.AliceBlue);

            player.SendClientMessage($"DynamicMapIcon {dynamicMapIcon.Entity.Handle} created.");
        }

        [PlayerCommand]
        public void DestroyMapIconCommand(Player player, int mapIconId, IEntityManager entityManager)
        {
            DynamicMapIcon dynamicMapIcon = entityManager.GetComponent<DynamicMapIcon>(StreamerEntities.GetDynamicMapIconId(mapIconId));
            dynamicMapIcon.DestroyEntity();

            player.SendClientMessage($"DynamicMapIcon {dynamicMapIcon.Entity.Handle} destroyed.");
        }
    }
}