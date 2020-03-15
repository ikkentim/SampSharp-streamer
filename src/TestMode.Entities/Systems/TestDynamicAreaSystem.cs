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
    /// System to test Dynamic area.
    /// </summary>
    public class TestDynamicAreaSystem : ISystem
    {
        [Event]
        public void OnPlayerEnterDynamicArea(Player player, DynamicArea dynamicArea)
        {
            player.SendClientMessage($"OnPlayerEnterDynamicArea({player.Entity.Handle}, {dynamicArea.Entity.Handle})");
        }

        [Event]
        public void OnPlayerLeaveDynamicArea(Player player, DynamicArea dynamicArea)
        {
            player.SendClientMessage($"OnPlayerLeaveDynamicArea({player.Entity.Handle}, {dynamicArea.Entity.Handle})");
        }

        [PlayerCommand]
        public void CreateCircleCommand(Player player, float size, IStreamerService streamerService)
        {
            DynamicArea dynamicCircle = streamerService.CreateDynamicCircle(player.Position.XY, size, player.VirtualWorld, player.Interior);

            player.SendClientMessage($"DynamicArea (Circle) {dynamicCircle.Entity.Handle} created.");
            player.SendClientMessage($"DynamicArea (Circle) {dynamicCircle.Entity.Handle} is valid: {dynamicCircle.IsValid}");
        }

        [PlayerCommand]
        public void GetTypeCommand(Player player, int areaId, IStreamerService streamerService, IEntityManager entityManager)
        {
            DynamicArea dynamicArea = entityManager.GetComponent<DynamicArea>(StreamerEntities.GetDynamicAreaId(areaId));

            player.SendClientMessage($"DynamicArea Type: {dynamicArea.AreaType}");
        }
    }
}