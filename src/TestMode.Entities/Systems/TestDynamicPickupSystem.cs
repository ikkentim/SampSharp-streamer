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
using SampSharp.Entities.SAMP.Commands;

using SampSharp.Streamer.Entities;

namespace TestMode.Entities.Systems
{
    /// <summary>
    /// System to test Dynamic Pickup.
    /// </summary>
    public class TestDynamicPickupSystem : ISystem
    {
        [Event]
        public void OnPlayerPickUpDynamicPickup(Player player, DynamicPickup dynamicPickup)
        {
            player.SendClientMessage($"OnPlayerPickUpDynamicPickup({player.Entity}, {dynamicPickup.Entity})");
        }

        [PlayerCommand]
        public void CreatePickupCommand(Player player, int modelId, int pickupType, IStreamerService streamerService)
        {
            var dynamicPickup = streamerService.CreateDynamicPickup(modelId, (PickupType)pickupType, player.Position);

            player.SendClientMessage($"DynamicPickup {dynamicPickup.Entity.Handle} created.");
            player.SendClientMessage($"DynamicPickup is valid ? {dynamicPickup.IsValid}");
        }

        [PlayerCommand]
        public void DestroyPickupCommand(Player player, DynamicPickup dynamicPickup)
        {
            dynamicPickup.DestroyEntity();
        }
    }
}