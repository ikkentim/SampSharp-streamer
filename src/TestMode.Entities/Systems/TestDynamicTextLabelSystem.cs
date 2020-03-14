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
    /// System to test Dynamic 3D Text Label.
    /// </summary>
    public class TestDynamicTextLabelSystem : ISystem
    {
        [PlayerCommand]
        public void CreateTextLabelCommand(Player player, string text, IStreamerService streamerService)
        {
            var dynamicTextLabel = streamerService.CreateDynamicTextLabel(
                text, 
                Color.Red, 
                player.Position + Vector3.Up, 10.0f,
                virtualWorld:player.VirtualWorld, interior:player.Interior);

            player.SendClientMessage($"DynamicTextLabel {dynamicTextLabel.Entity.Handle} created.");
            player.SendClientMessage($"DynamicTextLabel {dynamicTextLabel.Entity.Handle} is valid: {dynamicTextLabel.IsValid}");
        }

        [PlayerCommand]
        public void DestroyTextLabelCommand(Player player, int textLabelIdId, IEntityManager entityManager)
        {
            DynamicTextLabel dynamicTextLabel = entityManager.GetComponent<DynamicTextLabel>(StreamerEntities.GetDynamicTextLabelId(textLabelIdId));
            dynamicTextLabel.DestroyEntity();

            player.SendClientMessage($"DynamicTextLabel {dynamicTextLabel.Entity.Handle} destroyed.");
        }
    }
}