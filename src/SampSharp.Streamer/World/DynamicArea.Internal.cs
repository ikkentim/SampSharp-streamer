// SampSharp.Streamer
// Copyright 2016 Tim Potze
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

using SampSharp.GameMode.API;
using SampSharp.GameMode.API.NativeObjects;

namespace SampSharp.Streamer.World
{
    public partial class DynamicArea
    {
        protected static readonly DynamicAreaInternal Internal;

        static DynamicArea()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<DynamicAreaInternal>();
        }

        public class DynamicAreaInternal
        {
            [NativeMethod(3)]
            public virtual int CreateDynamicPolygon(float[] points, float minz, float maxz, int maxpoints, int worldid,
                int interiorid, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int CreateDynamicCircle(float x, float y, float size, int worldid, int interiorid,
                int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int CreateDynamicRectangle(float minx, float miny, float maxx, float maxy, int worldid,
                int interiorid, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int CreateDynamicSphere(float x, float y, float z, float size, int worldid,
                int interiorid, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int CreateDynamicCube(float minx, float miny, float minz, float maxx, float maxy, float maxz,
                int worldid, int interiorid, int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int DestroyDynamicArea(int areaid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsValidDynamicArea(int areaid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicPolygonPoints(int areaid, out float[] points, int maxlength)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicPolygonNumberPoints(int areaid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int TogglePlayerDynamicArea(int playerid, int areaid, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int TogglePlayerAllDynamicAreas(int playerid, bool toggle)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsPlayerInDynamicArea(int playerid, int areaid, bool recheck = false)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsPlayerInAnyDynamicArea(int playerid, bool recheck = false)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsAnyPlayerInDynamicArea(int areaid, bool recheck = false)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsAnyPlayerInAnyDynamicArea(bool recheck = false)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetPlayerDynamicAreas(int playerid, out int[] areas, int maxlength)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetPlayerNumberDynamicAreas(int playerid)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsPointInDynamicArea(int areaid, float x, float y, float z)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsPointInAnyDynamicArea(float x, float y, float z)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsLineInDynamicArea(int id, float x1, float y1, float z1, float x2, float y2, float z2)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual bool IsLineInAnyDynamicArea(float x1, float y1, float z1, float x2, float y2, float z2)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicAreasForLine(float x1, float y1, float z1, float x2, float y2, float z2, out int[] areas, int maxareas)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetNumberDynamicAreasForLine(float x1, float y1, float z1, float x2, float y2, float z2)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetDynamicAreasForPoint(float x, float y, float z, out int[] areas, int maxareas)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int GetNumberDynamicAreasForPoint(float x, float y, float z)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int AttachDynamicAreaToObject(int areaid, int objectid, int type, int playerid, float offsetX, float offsetY, float offsetZ)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int AttachDynamicAreaToPlayer(int areaid, int playerid, float offsetX, float offsetY, float offsetZ)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int AttachDynamicAreaToVehicle(int areaid, int vehicleid, float offsetX, float offsetY, float offsetZ)
            {
                throw new NativeNotImplementedException();
            }


            [NativeMethod]
            public virtual int CreateDynamicCircleEx(float x, float y, float size, int[] worlds, int[] interiors,
                int[] players, int maxworlds, int maxinteriors, int maxplayers)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int CreateDynamicRectangleEx(float minx, float miny, float maxx, float maxy, int[] worlds,
                int[] interiors, int[] players, int maxworlds, int maxinteriors, int maxplayers)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int CreateDynamicSphereEx(float x, float y, float z, float size, int[] worlds,
                int[] interiors, int[] players, int maxworlds, int maxinteriors, int maxplayers)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int CreateDynamicCubeEx(float minx, float miny, float minz, float maxx, float maxy,
                float maxz, int[] worlds, int[] interiors, int[] players, int maxworlds, int maxinteriors,
                int maxplayers)
            {
                throw new NativeNotImplementedException();
            }

            [NativeMethod]
            public virtual int CreateDynamicPolygonEx(float[] points, float minz, float maxz, int maxpoints,
                int[] worlds, int[] interiors, int[] players, int maxworlds, int maxinteriors, int maxplayers)
            {
                throw new NativeNotImplementedException();
            }
        }
    }
}