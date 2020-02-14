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
    /// System to test Dynamic Checkpoint.
    /// </summary>
    public class TestDynamicCheckpointSystem : ISystem
    {
        [Event]
        public void OnPlayerEnterDynamicCP(Player player, DynamicCheckpoint dynamicCheckpoint)
        {
            player.SendClientMessage($"OnPlayerEnterDynamicCP({player.Entity.Handle}, {dynamicCheckpoint.Entity.Handle})");
        }

        [Event]
        public void OnPlayerLeaveDynamicCP(Player player, DynamicCheckpoint dynamicCheckpoint)
        {
            player.SendClientMessage($"OnPlayerLeaveDynamicCP({player.Entity.Handle}, {dynamicCheckpoint.Entity.Handle})");
        }

        [PlayerCommand]
        public void CreateCPCommand(Player player, float size, IStreamerService streamerService)
        {
            var dynamicCheckpoint = streamerService.CreateDynamicCheckpoint(player.Position, size);

            player.SendClientMessage($"DynamicCheckpoint {dynamicCheckpoint.Entity.Handle} created.");
            player.SendClientMessage($"DynamicCheckpoint is valid ? {dynamicCheckpoint.IsValid}");
            player.SendClientMessage($"DynamicCheckpoint position = {dynamicCheckpoint.Position}");
        }

        [PlayerCommand]
        public void DestroyCPCommand(Player player, int dynamicCheckpointId, IEntityManager entityManager)
        {
            DynamicCheckpoint dynamicCheckpoint = entityManager.GetComponent<DynamicCheckpoint>(StreamerEntities.GetDynamicCheckpointId(dynamicCheckpointId));
            dynamicCheckpoint.DestroyEntity();
        }
    }
}