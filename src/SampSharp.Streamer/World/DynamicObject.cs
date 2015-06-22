// SampSharp.Streamer
// Copyright 2015 Tim Potze
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
using System.Linq;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Natives;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.Events;
using SampSharp.Streamer.Natives;
using SampSharp.GameMode;

namespace SampSharp.Streamer.World
{
    public class DynamicObject : DynamicWorldObject<DynamicObject>, IGameObject
    {
        public DynamicObject(int id)
        {
            Id = id;
        }

        public DynamicObject(int modelid, Vector3 position, Vector3 rotation = new Vector3(), int worldid = -1,
            int interiorid = -1, GtaPlayer player = null, float streamdistance = 200.0f, float drawdistance = 0.0f)
        {
            Id = StreamerNative.CreateDynamicObject(modelid, position.X, position.Y, position.Z, rotation.X, rotation.Y,
                rotation.Z, worldid, interiorid, player == null ? -1 : player.Id, streamdistance, drawdistance);
        }

        public DynamicObject(int modelid, Vector3 position, Vector3 rotation, float streamdistance, int[] worlds = null,
            int[] interiors = null, GtaPlayer[] players = null, float drawdistance = 0.0f)
        {
            Id = StreamerNative.CreateDynamicObjectEx(modelid, position.X, position.Y, position.Z, rotation.X,
                rotation.Y, rotation.Z, drawdistance, streamdistance, worlds, interiors,
                players.Select(p => p.Id).ToArray());
        }

        public override StreamType StreamType
        {
            get { return StreamType.Object; }
        }

        public bool IsMoving
        {
            get { return StreamerNative.IsDynamicObjectMoving(Id); }
        }

        public bool IsValid
        {
            get { return StreamerNative.IsValidDynamicObject(Id); }
        }

        public int ModelId
        {
            get { return GetInteger(StreamerDataType.ModelId); }
            set { SetInteger(StreamerDataType.ModelId, value); }
        }

        public float DrawDistance
        {
            get { return GetFloat(StreamerDataType.DrawDistance); }
            set { SetFloat(StreamerDataType.DrawDistance, value); }
        }

        public Vector3 Rotation
        {
            get
            {
                float x, y, z;
                StreamerNative.GetDynamicObjectRot(Id, out x, out y, out z);
                return new Vector3(x, y, z);
            }
            set { StreamerNative.SetDynamicObjectRot(Id, value.X, value.Y, value.Z); }
        }

        public int Move(Vector3 position, float speed, Vector3 rotation)
        {
            return StreamerNative.MoveDynamicObject(Id, position.X, position.Y, position.Z, speed, rotation.X,
                rotation.Y, rotation.Z);
        }

        public int Move(Vector3 position, float speed)
        {
            return StreamerNative.MoveDynamicObject(Id, position.X, position.Y, position.Z, speed);
        }

        public void Stop()
        {
            StreamerNative.StopDynamicObject(Id);
        }

        public void SetMaterial(int materialindex, int modelid, string txdname, string texturename,
            Color materialcolor = new Color())
        {
            StreamerNative.SetDynamicObjectMaterial(Id, materialindex, modelid, txdname, texturename,
                Color.FromInteger(materialcolor, ColorFormat.ARGB));
        }

        public void SetMaterialText(int materialindex, string text,
            ObjectMaterialSize materialsize = ObjectMaterialSize.X256X128, string fontface = "Arial", int fontsize = 24,
            bool bold = true, Color fontcolor = new Color(), Color backcolor = new Color(),
            ObjectMaterialTextAlign textalignment = ObjectMaterialTextAlign.Center)
        {
            StreamerNative.SetDynamicObjectMaterialText(Id, materialindex, text, materialsize, fontface, fontsize, bold,
                Color.FromInteger(fontcolor, ColorFormat.ARGB),
                Color.FromInteger(backcolor, ColorFormat.ARGB), textalignment);
        }

        public event EventHandler<EventArgs> Moved;
        public event EventHandler<PlayerSelectEventArgs> Selected;
        public event EventHandler<PlayerEditEventArgs> Edited;
        public event EventHandler<PlayerShootEventArgs> Shot;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            StreamerNative.DestroyDynamicObject(Id);
        }

        public void GetMaterial(int materialindex, out int modelid, out string txdname, out string texturename,
            out Color materialColor)
        {
            int holderMaterialColor;
            StreamerNative.GetDynamicObjectMaterial(Id, materialindex, out modelid, out txdname, out texturename,
                out holderMaterialColor, 64, 64);

            materialColor = Color.FromInteger(holderMaterialColor, ColorFormat.ARGB);
        }

        public void GetMaterialText(int materialindex, out string text, out ObjectMaterialSize materialSize,
            out string fontface, out int fontsize, out bool bold, out Color fontcolor, out Color backcolor,
            out ObjectMaterialTextAlign textalignment)
        {
            int holderFontColor, holderBackColor;
            StreamerNative.GetDynamicObjectMaterialText(Id, materialindex, out text, out materialSize, out fontface,
                out fontsize, out bold, out holderFontColor, out holderBackColor, out textalignment, 1024, 64);

            fontcolor = Color.FromInteger(holderFontColor, ColorFormat.ARGB);
            backcolor = Color.FromInteger(holderBackColor, ColorFormat.ARGB);
        }

        public bool IsMaterialUsed(int materialindex)
        {
            return StreamerNative.IsDynamicObjectMaterialUsed(Id, materialindex);
        }

        public bool IsMaterialTextUsed(int materialindex)
        {
            return StreamerNative.IsDynamicObjectMaterialTextUsed(Id, materialindex);
        }

        public virtual void Edit(GtaPlayer player)
        {
            AssertNotDisposed();

            Native.EditPlayerObject(player.Id, Id);
        }

        public static void Select(GtaPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            Native.SelectObject(player.Id);
        }

        public virtual void AttachTo(GtaVehicle vehicle, Vector3 offset, Vector3 rotation)
        {
            AssertNotDisposed();

            if (vehicle == null)
                throw new ArgumentNullException("vehicle");

            StreamerNative.AttachDynamicObjectToVehicle(Id, vehicle.Id, offset.X, offset.Y, offset.Z, rotation.X,
                rotation.Y, rotation.Z);
        }

        public virtual void SetNoCameraCollision()
        {
            AssertNotDisposed();

            StreamerNative.SetDynamicObjectNoCameraCol(Id);
        }

        public virtual void AttachCameraToObject(GtaPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            AssertNotDisposed();

            StreamerNative.AttachCameraToDynamicObject(player.Id, Id);
        }

        public virtual void OnMoved(EventArgs e)
        {
            if (Moved != null)
                Moved(this, e);
        }

        public virtual void OnSelected(PlayerSelectEventArgs e)
        {
            if (Selected != null)
                Selected(this, e);
        }

        public virtual void OnEdited(PlayerEditEventArgs e)
        {
            if (Edited != null)
                Edited(this, e);
        }

        public virtual void OnShot(PlayerShootEventArgs e)
        {
            if (Shot != null)
                Shot(this, e);
        }
    }
}