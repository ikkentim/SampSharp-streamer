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
    /// System to test Dynamic Race Checkpoint.
    /// </summary>
    public class TestDynamicRaceCheckpointSystem : ISystem
    {
        [Event]
        public void OnPlayerEnterDynamicRaceCP(Player player, DynamicRaceCheckpoint dynamicRaceCheckpoint)
        {
            player.SendClientMessage($"OnPlayerEnterDynamicRaceCP({player.Entity.Handle}, {dynamicRaceCheckpoint.Entity.Handle})");
        }

        [Event]
        public void OnPlayerLeaveDynamicRaceCP(Player player, DynamicRaceCheckpoint dynamicRaceCheckpoint)
        {
            player.SendClientMessage($"OnPlayerLeaveDynamicRaceCP({player.Entity.Handle}, {dynamicRaceCheckpoint.Entity.Handle})");
        }

        [PlayerCommand]
        public void CreateRaceCPCommand(Player player, CheckpointType type, float size, IStreamerService streamerService)
        {
            var nextPosition = new Vector3(player.Position.X + 5.0f, player.Position.Y, player.Position.Z);
            var dynamicRaceCheckpoint = streamerService.CreateDynamicRaceCheckpoint(type, player.Position, nextPosition, size);

            player.SendClientMessage($"DynamicRaceCheckpoint {dynamicRaceCheckpoint.Entity.Handle} created.");
            player.SendClientMessage($"DynamicRaceCheckpoint is valid ? {dynamicRaceCheckpoint.IsValid}");
            player.SendClientMessage($"DynamicRaceCheckpoint position = {dynamicRaceCheckpoint.Position}");
            player.SendClientMessage($"DynamicRaceCheckpoint next position = {dynamicRaceCheckpoint.Position}");
        }

        [PlayerCommand]
        public void DestroyRaceCPCommand(Player player, int dynamicRaceCheckpointId, IEntityManager entityManager)
        {
            DynamicRaceCheckpoint dynamicRaceCheckpoint = entityManager.GetComponent<DynamicRaceCheckpoint>(StreamerEntities.GetDynamicRaceCheckpointId(dynamicRaceCheckpointId));
            dynamicRaceCheckpoint.DestroyEntity();
        }

        [PlayerCommand]
        public void IsInRaceCPCommand(Player player, DynamicRaceCheckpoint dynamicRaceCheckpoint)
        {
            bool isIn = player.IsInDynamicRaceCheckpoint(dynamicRaceCheckpoint);
            player.SendClientMessage($"IsInDynamicRaceCheckpoint {dynamicRaceCheckpoint.Entity.Handle} = {isIn}");
        }

        [PlayerCommand]
        public void VisibleRaceCPCommand(Player player, IEntityManager entityManager)
        {
            var id = player.GetVisibleDynamicRaceCheckpoint();
            player.SendClientMessage($"GetVisibleDynamicRaceCheckpoint id {id}");

            var dynamicRaceCheckpoint = entityManager.GetComponent<DynamicRaceCheckpoint>(id);

            player.SendClientMessage($"GetVisibleDynamicRaceCheckpoint {dynamicRaceCheckpoint.Entity.Handle}");
        }
    }
}