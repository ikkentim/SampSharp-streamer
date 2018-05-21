// SampSharp.Streamer
// Copyright 2018 Tim Potze
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

namespace SampSharp.Streamer.World
{
    public partial class DynamicObject
    {
        protected static readonly DynamicObjectInternal Internal;

        static DynamicObject()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<DynamicObjectInternal>();
        }

        public class DynamicObjectInternal
        {
            [NativeMethod]
            public virtual int CreateDynamicObject(int modelid, float x, float y, float z, float rx, float ry, float rz,
                int worldid, int interiorid, int playerid, float streamdistance, float drawdistance, int areaid,
                int priority)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod(14, 15, 16, 17)]
            public virtual int CreateDynamicObjectEx(int modelid, float x, float y, float z, float rx, float ry,
                float rz, float drawdistance, float streamdistance, int[] worlds, int[] interiors, int[] players,
                int[] areas, int priority, int maxworlds, int maxinteriors, int maxplayers, int maxareas)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int MoveDynamicObject(int objectid, float x, float y, float z, float speed, float rx,
                float ry, float rz)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int DestroyDynamicObject(int objectid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsValidDynamicObject(int objectid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicObjectPos(int objectid, float x, float y, float z)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicObjectPos(int objectid, out float x, out float y, out float z)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicObjectRot(int objectid, float rx, float ry, float rz)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicObjectRot(int objectid, out float rx, out float ry, out float rz)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicObjectNoCameraCol(int objectid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int StopDynamicObject(int objectid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsDynamicObjectMoving(int objectid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int AttachCameraToDynamicObject(int playerid, int objectid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int AttachDynamicObjectToPlayer(int objectid, int playerid, float offsetx, float offsety,
                float offsetz, float rx, float ry, float rz)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int AttachDynamicObjectToVehicle(int objectid, int vehicleid, float offsetx, float offsety,
                float offsetz, float rx, float ry, float rz)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int EditDynamicObject(int playerid, int objectid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsDynamicObjectMaterialUsed(int objectid, int materialindex)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsDynamicObjectMaterialTextUsed(int objectid, int materialindex)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicObjectMaterialText(int objectid, int materialindex, out string text,
                out int materialsize, out string fontface, out int fontsize, out bool bold, out int fontcolor,
                out int backcolor, out int textalignment, int maxtext, int maxfontface)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicObjectMaterial(int objectid, int materialindex, out int modelid,
                out string txdname, out string texturename, out int materialcolor, int maxtxdname, int maxtexturename)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicObjectMaterialText(int objectid, int materialindex, string text,
                int materialsize, string fontface, int fontsize, bool bold, int fontcolor, int backcolor,
                int textalignment)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int SetDynamicObjectMaterial(int objectid, int materialindex, int modelid, string txdname,
                string texturename, int materialcolor)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool SelectObject(int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public bool GetDynamicObjectNoCameraCol(int id)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}