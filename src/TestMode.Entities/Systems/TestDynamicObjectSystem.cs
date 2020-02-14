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
    /// System to test Dynamic Object.
    /// </summary>
    public class TestDynamicObjectSystem : ISystem
    {
        private DynamicObject _dynamicObject;

        [Event]
        public void OnDynamicObjectMoved(DynamicObject dynamicObject)
        {
            Console.WriteLine($"DynamicObject {dynamicObject.Entity.Handle} is moved.");
        }

        [Event]
        public void OnPlayerEditDynamicObject(Player player, DynamicObject dynamicObject, int response, Vector3 position, Vector3 rotation)
        {
            player.SendClientMessage($"OnPlayerEditDynamicObject ({dynamicObject.Entity.Handle}, {response}, {position.ToString()}, {rotation.ToString()})");
        }

        [Event]
        public void OnPlayerSelectDynamicObject(Player player, DynamicObject dynamicObject, int modelId, Vector3 position)
        {
            player.SendClientMessage($"OnPlayerSelectDynamicObject ({dynamicObject.Entity.Handle}, {modelId}, {position.ToString()})");
        }

        [Event]
        public bool OnPlayerShootDynamicObject(Player player, Weapon weapon, DynamicObject dynamicObject, Vector3 position)
        {
            player.SendClientMessage($"OnPlayerShootDynamicObject ({dynamicObject.Entity.Handle}, {position.ToString()})");

            // TODO: PreventDamage ? (From doc : If a return value of 0 is specified, the weapon shot will not be registered)

            return true;
        }

        [PlayerCommand]
        public void CreateObjectCommand(Player player, int modelId, IStreamerService streamerService)
        {
            _dynamicObject = streamerService.CreateDynamicObject(modelId, player.Position, player.Rotation);

            player.SendClientMessage($"DynamicObject {_dynamicObject.Entity.Handle} created.");
        }

        [PlayerCommand]
        public void DestroyObjectCommand(Player player)
        {
            _dynamicObject.DestroyEntity();
        }

        [PlayerCommand]
        public void MoveObjectCommand(Player player, float speed = 0.03f)
        {
            _dynamicObject.Move((_dynamicObject.Position + Vector3.Left), speed, _dynamicObject.Rotation);
        }

        [PlayerCommand]
        public void StopMoveObjectCommand(Player player, float speed = 0.03f)
        {
            _dynamicObject.Stop();
        }

        [PlayerCommand]
        public void EditObjectCommand(Player player)
        {
            player.EditDynamicObject(_dynamicObject);
        }

        [PlayerCommand]
        public void SelectObjectCommand(Player player)
        {
            player.Select();
        }

        [PlayerCommand]
        public void ShootObjectCommand(Player player)
        {
            player.GiveWeapon(Weapon.AK47, 100);
        }
    }
}