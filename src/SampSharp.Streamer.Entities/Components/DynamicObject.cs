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
    /// Represents a component which provides the data and functionality of an dynamic object.
    /// </summary>
    public sealed class DynamicObject : Component
    {
        private DynamicObject()
        {

        }

        /// <summary>
        /// Gets whether this dynamic object is valid.
        /// </summary>
        public bool IsValid => GetComponent<NativeDynamicObject>().IsValidDynamicObject();

        /// <summary>
        /// Gets whether this dynamic object is moving.
        /// </summary>
        public bool IsMoving => GetComponent<NativeDynamicObject>().IsDynamicObjectMoving();

        /// <summary>
        /// Gets whether this dynamic object used material.
        /// </summary>
        public bool IsMaterialUsed(int materialindex) => GetComponent<NativeDynamicObject>().IsDynamicObjectMaterialUsed(materialindex);

        /// <summary>
        /// Gets whether this dynamic object used material text.
        /// </summary>
        public bool IsMaterialTextUsed(int materialindex) => GetComponent<NativeDynamicObject>().IsDynamicObjectMaterialTextUsed(materialindex);

        /// <summary>
        /// Gets the position of this dynamic object.
        /// </summary>
        public Vector3 Position
        {
            get
            {
                GetComponent<NativeDynamicObject>().GetDynamicObjectPos(out var x, out var y, out var z);
                return new Vector3(x, y, z);
            }
            set => GetComponent<NativeDynamicObject>().SetDynamicObjectPos(value.X, value.Y, value.Z);
        }

        /// <summary>
        /// Gets the rotation of this dynamic object.
        /// </summary>
        public Vector3 Rotation
        {
            get
            {
                GetComponent<NativeDynamicObject>().GetDynamicObjectRot(out var x, out var y, out var z);
                return new Vector3(x, y, z);
            }
            set => GetComponent<NativeDynamicObject>().SetDynamicObjectRot(value.X, value.Y, value.Z);
        }

        /// <summary>
        /// Moves this dynamic object to the given position and rotation with the given speed.
        /// </summary>
        /// <param name="position">The position to which to move this dynamic object.</param>
        /// <param name="speed">The speed at which to move this dynamic object.</param>
        /// <param name="rotation">The rotation to which to move this dynamic object.</param>
        /// <returns>
        /// The time it will take for the object to move in milliseconds.
        /// </returns>
        public int Move(Vector3 position, float speed, Vector3 rotation)
        {
            return GetComponent<NativeDynamicObject>().MoveDynamicObject(position.X, position.Y, position.Z, speed,
                rotation.X, rotation.Y, rotation.Z);
        }

        /// <summary>
        /// Moves this dynamic object to the given position with the given speed.
        /// </summary>
        /// <param name="position">The position to which to move this dynamic object.</param>
        /// <param name="speed">The speed at which to move this dynamic object.</param>
        /// <returns>
        /// The time it will take for the object to move in milliseconds.
        /// </returns>
        public int Move(Vector3 position, float speed)
        {
            return GetComponent<NativeDynamicObject>().MoveDynamicObject(position.X, position.Y, position.Z, speed, 
                -1000, -1000, -1000);
        }

        /// <summary>
        /// Stop this dynamic object from moving any further.
        /// </summary>
        public void Stop()
        {
            GetComponent<NativeDynamicObject>().StopDynamicObject();
        }

        /// <summary>
        /// Attaches camera to the specified dynamic object.
        /// </summary>
        /// <param name="player">The player.</param>
        public void AttachCameraTo(EntityId player)
        {
            if (!player.IsOfAnyType(SampEntities.PlayerType))
                throw new InvalidEntityArgumentException(nameof(player), SampEntities.PlayerType);

            GetComponent<NativeDynamicObject>().AttachCameraToDynamicObject(player);
        }

        /// <summary>
        /// Attaches this dynamic object to the specified dynamic object, player or vehicle.
        /// </summary>
        /// <param name="target">The dynamic object, player or vehicle.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="rotation">The rotation.</param>
        public void AttachTo(EntityId target, Vector3 offset, Vector3 rotation)
        {
            if (!target.IsOfAnyType(StreamerEntities.DynamicObjectType, SampEntities.PlayerType, SampEntities.VehicleType))
                throw new InvalidEntityArgumentException(nameof(target), StreamerEntities.DynamicObjectType, SampEntities.PlayerType, SampEntities.VehicleType);

            if (target.IsOfType(StreamerEntities.DynamicObjectType))
                GetComponent<NativeDynamicObject>().AttachDynamicObjectToObject(target, offset.X, offset.Y, offset.Z,
                    rotation.X, rotation.Y, rotation.Z);
            else if (target.IsOfType(SampEntities.PlayerType))
                GetComponent<NativeDynamicObject>().AttachDynamicObjectToPlayer(target, offset.X, offset.Y, offset.Z,
                    rotation.X, rotation.Y, rotation.Z);
            else if (target.IsOfType(SampEntities.VehicleType))
                GetComponent<NativeDynamicObject>().AttachDynamicObjectToVehicle(target, offset.X, offset.Y, offset.Z,
                    rotation.X, rotation.Y, rotation.Z);
        }

        /// <summary>
        /// Gets the material of this dynamic object.
        /// </summary>
        public void GetMaterial(int materialindex, out int modelid, out string txdname, out string texturename,
            out Color materialColor)
        {
            GetComponent<NativeDynamicObject>().GetDynamicObjectMaterial(materialindex, out modelid,
                out txdname, out texturename, out var holderMaterialColor, 64, 64);

            materialColor = Color.FromInteger(holderMaterialColor, ColorFormat.ARGB);
        }

        /// <summary>
        /// Sets the material of this dynamic object.
        /// </summary>
        /// <param name="materialindex">The material index.</param>
        /// <param name="modelid">The model id.</param>
        /// <param name="txdname">The txd name.</param>
        /// <param name="texturename">The texture name.</param>
        /// <param name="materialcolor">The material color.</param>
        public void SetMaterial(int materialindex, int modelid, string txdname, string texturename,
            Color materialcolor = new Color())
        {
            GetComponent<NativeDynamicObject>().SetDynamicObjectMaterial(materialindex, modelid, 
                txdname, texturename, materialcolor.ToInteger(ColorFormat.ARGB));
        }

        /// <summary>
        /// Gets the material text of this dynamic object.
        /// </summary>
        public void GetMaterialText(int materialindex, out string text,
            out ObjectMaterialSize materialSize, out string fontface, out int fontsize, out bool bold, 
            out Color fontcolor, out Color backcolor, out ObjectMaterialTextAlign textalignment)
        {
            GetComponent<NativeDynamicObject>().GetDynamicObjectMaterialText(materialindex, out text,
            out var holderMaterialSize, out fontface, out fontsize, out bold, 
            out var holderFontColor, out var holderBackColor, out var holderTextalignment, 1024, 64);

            fontcolor = Color.FromInteger(holderFontColor, ColorFormat.ARGB);
            backcolor = Color.FromInteger(holderBackColor, ColorFormat.ARGB);
            materialSize = (ObjectMaterialSize)holderMaterialSize;
            textalignment = (ObjectMaterialTextAlign)holderTextalignment;
        }

        /// <summary>
        /// Sets the material text of this dynamic object.
        /// </summary>
        /// <param name="materialindex">The material index.</param>
        /// <param name="text">The text.</param>
        /// <param name="materialsize">The material size.</param>
        /// <param name="fontface">The font face.</param>
        /// <param name="fontsize">The font size.</param>
        /// <param name="bold">The bold.</param>
        /// <param name="fontcolor">The font color.</param>
        /// <param name="backcolor">The back color.</param>
        /// <param name="textalignment">The text alignment.</param>
        public void SetMaterialText(int materialindex, string text,
            ObjectMaterialSize materialsize = ObjectMaterialSize.X256X128, string fontface = "Arial", int fontsize = 24,
            bool bold = true, Color fontcolor = new Color(), Color backcolor = new Color(),
            ObjectMaterialTextAlign textalignment = ObjectMaterialTextAlign.Center)
        {
            GetComponent<NativeDynamicObject>().SetDynamicObjectMaterialText(materialindex, text, (int)materialsize, fontface, fontsize, bold,
                fontcolor.ToInteger(ColorFormat.ARGB), backcolor.ToInteger(ColorFormat.ARGB), (int)textalignment);
        }

        /// <inheritdoc />
        protected override void OnDestroyComponent()
        {
            GetComponent<NativeDynamicObject>().DestroyDynamicObject();
        }
    }
}