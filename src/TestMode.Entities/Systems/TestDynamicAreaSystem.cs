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
            DynamicArea dynamicCircle = streamerService.CreateCircle(player.Position.XY, size, player.VirtualWorld, player.Interior);

            player.SendClientMessage($"DynamicArea (Circle) {dynamicCircle.Entity.Handle} created.");
            player.SendClientMessage($"DynamicArea (Circle) {dynamicCircle.Entity.Handle} is valid: {dynamicCircle.IsValid}");
        }

        [PlayerCommand]
        public void CreateCylinderCommand(Player player, IStreamerService streamerService)
        {
            DynamicArea dynamicCircle = streamerService.CreateCylinder(
                player.Position.XY, 5.0f, 5.0f, 10.0f, player.VirtualWorld, player.Interior);

            player.SendClientMessage($"DynamicArea (Cylinder) {dynamicCircle.Entity.Handle} created.");
            player.SendClientMessage($"DynamicArea (Cylinder) {dynamicCircle.Entity.Handle} is valid: {dynamicCircle.IsValid}");
        }

        [PlayerCommand]
        public void CreateSphereCommand(Player player, IStreamerService streamerService)
        {
            DynamicArea dynamicCircle = streamerService.CreateSphere(
                player.Position, 10.0f, player.VirtualWorld, player.Interior);

            player.SendClientMessage($"DynamicArea (Sphere) {dynamicCircle.Entity.Handle} created.");
            player.SendClientMessage($"DynamicArea (Sphere) {dynamicCircle.Entity.Handle} is valid: {dynamicCircle.IsValid}");
        }

        [PlayerCommand]
        public void CreateRectangleCommand(Player player, float minx, float miny, float maxx, float maxy, IStreamerService streamerService)
        {
            DynamicArea dynamicCircle = streamerService.CreateRectangle(
                new Vector2(minx, miny), new Vector2(maxx, maxy), player.VirtualWorld, player.Interior);

            player.SendClientMessage($"DynamicArea (Rectangle) {dynamicCircle.Entity.Handle} created.");
            player.SendClientMessage($"DynamicArea (Rectangle) {dynamicCircle.Entity.Handle} is valid: {dynamicCircle.IsValid}");
        }

        [PlayerCommand]
        public void CreateCuboidCommand(Player player, float minx, float miny, float minz, 
            float maxx, float maxy, float maxz, IStreamerService streamerService)
        {
            DynamicArea dynamicCircle = streamerService.CreateCuboid(
                new Vector3(minx, miny, minz), new Vector3(maxx, maxy, maxz), player.VirtualWorld, player.Interior);

            player.SendClientMessage($"DynamicArea (Cuboid) {dynamicCircle.Entity.Handle} created.");
            player.SendClientMessage($"DynamicArea (Cuboid) {dynamicCircle.Entity.Handle} is valid: {dynamicCircle.IsValid}");
        }

        [PlayerCommand]
        public void CreateCubeCommand(Player player, float minx, float miny, float minz,
            float maxx, float maxy, float maxz, IStreamerService streamerService)
        {
            DynamicArea dynamicCircle = streamerService.CreateCube(
                new Vector3(minx, miny, minz), new Vector3(maxx, maxy, maxz), player.VirtualWorld, player.Interior);

            player.SendClientMessage($"DynamicArea (Cube) {dynamicCircle.Entity.Handle} created.");
            player.SendClientMessage($"DynamicArea (Cube) {dynamicCircle.Entity.Handle} is valid: {dynamicCircle.IsValid}");
        }

        [PlayerCommand]
        public void CreatePolygonCommand(Player player, IStreamerService streamerService)
        {
            // ToDo
        }

        [PlayerCommand]
        public void GetTypeCommand(Player player, int areaId, IStreamerService streamerService, IEntityManager entityManager)
        {
            DynamicArea dynamicArea = entityManager.GetComponent<DynamicArea>(StreamerEntities.GetDynamicAreaId(areaId));

            player.SendClientMessage($"DynamicArea Type: {dynamicArea.AreaType}");
        }

        [PlayerCommand]
        public void IsInAreaCommand(Player player, DynamicArea dynamicArea)
        {
            bool isIn = player.IsPlayerInDynamicArea(dynamicArea);
            player.SendClientMessage($"IsPlayerInDynamicArea {dynamicArea.Entity.Handle} = {isIn}");
        }

        [PlayerCommand]
        public void IsInAnyAreaCommand(Player player, bool recheck = false)
        {
            bool isInAny = player.IsPlayerInAnyDynamicArea(recheck);
            player.SendClientMessage($"IsPlayerInAnyDynamicArea = {isInAny}");
        }
    }
}