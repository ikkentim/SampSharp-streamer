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

using SampSharp.Core.Natives.NativeObjects;
using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    public class NativeDynamicObject : BaseNativeComponent
    {
        /// <summary>
        /// Identifier indicating the handle is invalid.
        /// </summary>
        public const int InvalidId = 0xFFFF;

        [NativeMethod]
        public virtual bool IsValidDynamicObject()
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual bool DestroyDynamicObject()
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int SetDynamicObjectPos(float x, float y, float z)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetDynamicObjectPos(out float x, out float y, out float z)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int SetDynamicObjectRot(float rx, float ry, float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetDynamicObjectRot(out float rx, out float ry, out float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int MoveDynamicObject(float x, float y, float z, float speed, float rx, float ry, float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int StopDynamicObject()
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual bool IsDynamicObjectMoving()
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int AttachCameraToDynamicObject(int playerid)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int AttachDynamicObjectToObject(int attachtoid, float offsetx, float offsety, float offsetz, 
            float rx, float ry, float rz, int syncrotation = 1)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int AttachDynamicObjectToPlayer(int playerid, float offsetx, float offsety,
            float offsetz, float rx, float ry, float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int AttachDynamicObjectToVehicle(int vehicleid, float offsetx, float offsety,
            float offsetz, float rx, float ry, float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual bool IsDynamicObjectMaterialUsed(int materialindex)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetDynamicObjectMaterial(int materialindex, out int modelid,
            out string txdname, out string texturename, out int materialcolor, int maxtxdname, int maxtexturename)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int SetDynamicObjectMaterial(int materialindex, int modelid, string txdname,
            string texturename, int materialcolor)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual bool IsDynamicObjectMaterialTextUsed(int materialindex)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int GetDynamicObjectMaterialText(int materialindex, out string text,
            out int materialsize, out string fontface, out int fontsize, out bool bold, out int fontcolor,
            out int backcolor, out int textalignment, int maxtext, int maxfontface)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int SetDynamicObjectMaterialText(int materialindex, string text,
            int materialsize, string fontface, int fontsize, bool bold, int fontcolor, int backcolor,
            int textalignment)
        {
            throw new NativeNotImplementedException();
        }
    }
}
