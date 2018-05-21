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

using System;
using System.Collections.Generic;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public partial class DynamicArea : DynamicWorldObject<DynamicArea>
    {
        public bool IsValid
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsValidDynamicArea(Id);
            }
        }

        public override StreamType StreamType
        {
            get
            {
                AssertNotDisposed();
                return StreamType.Area;
            }
        }

        public bool IsSpectateModeEnabled
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsToggleDynAreaSpectateMode(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.ToggleDynAreaSpectateMode(Id, value);
            }
        }

        public AreaType AreaType
        {
            get
            {
                AssertNotDisposed();
                return (AreaType) Internal.GetDynamicAreaType(Id);
            }
        }

        public event EventHandler<PlayerEventArgs> Enter;

        public event EventHandler<PlayerEventArgs> Leave;

        public void AttachTo(IGameObject obj, Vector3 offset = default(Vector3))
        {
            AssertNotDisposed();

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (!(obj is IIdentifiable))
                throw new ArgumentException("obj must be IIdentifiable");

            var playerid = BasePlayer.InvalidId;
            var objectid = ((IIdentifiable) obj).Id;
            var type = StreamerObjectType.Global;

            if (obj is IOwnable<BasePlayer>)
                playerid = (obj as IOwnable<BasePlayer>).Owner.Id;
            if (obj is PlayerObject)
                type = StreamerObjectType.Player;
            if (obj is DynamicObject)
                type = StreamerObjectType.Dynamic;

            Internal.AttachDynamicAreaToObject(Id, objectid, (int) type, playerid, offset.X, offset.Y, offset.Z);
        }

        public void AttachTo(BasePlayer player, Vector3 offset = default(Vector3))
        {
            AssertNotDisposed();

            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.AttachDynamicAreaToPlayer(Id, player.Id, offset.X, offset.Y, offset.Z);
        }

        public void AttachTo(BaseVehicle vehicle, Vector3 offset = default(Vector3))
        {
            AssertNotDisposed();

            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            Internal.AttachDynamicAreaToVehicle(Id, vehicle.Id, offset.X, offset.Y, offset.Z);
        }

        public bool IsInArea(BasePlayer player, bool recheck = false)
        {
            AssertNotDisposed();

            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return Internal.IsPlayerInDynamicArea(player.Id, Id, recheck);
        }

        public bool IsInArea(IWorldObject obj)
        {
            AssertNotDisposed();

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return Internal.IsPointInDynamicArea(Id, obj.Position.X, obj.Position.Y, obj.Position.Z);
        }

        public bool IsLineInArea(Vector3 from, Vector3 to)
        {
            AssertNotDisposed();

            return Internal.IsLineInDynamicArea(Id, from.X, from.Y, from.Z, to.X, to.Y, to.Z);
        }

        public static bool IsLineInAnyArea(Vector3 from, Vector3 to)
        {
            return Internal.IsLineInAnyDynamicArea(from.X, from.Y, from.Z, to.X, to.Y, to.Z);
        }

        public IEnumerable<Vector3> GetPoints()
        {
            AssertNotDisposed();

            var pointCount = GetPointsCount();
            Internal.GetDynamicPolygonPoints(Id, out var points, pointCount * 2);

            if (points == null) yield break;

            for (var i = 0; i < points.Length - 1; i += 2)
            {
                yield return new Vector3(points[i], points[i + 1]);
            }
        }

        public int GetPointsCount()
        {
            AssertNotDisposed();

            return Internal.GetDynamicPolygonNumberPoints(Id);
        }

        public static IEnumerable<DynamicArea> GetAreasForPoint(Vector3 point)
        {
            Internal.GetDynamicAreasForPoint(point.X, point.Y, point.Z, out var areas, GetAreasForPointCount(point));

            if (areas == null) yield break;

            foreach (var areaid in areas)
            {
                var area = Find(areaid);

                if (area != null)
                    yield return area;
            }
        }

        public static int GetAreasForPointCount(Vector3 point)
        {
            return Internal.GetNumberDynamicAreasForPoint(point.X, point.Y, point.Z);
        }

        public static IEnumerable<DynamicArea> GetAreasForLine(Vector3 from, Vector3 to)
        {
            Internal.GetDynamicAreasForLine(from.X, from.Y, from.Z, to.X, to.Y, to.Z, out var areas, GeAreasForLineCount(from, to));

            if (areas == null) yield break;

            foreach (var areaid in areas)
            {
                var area = Find(areaid);

                if (area != null)
                    yield return area;
            }
        }

        public static int GeAreasForLineCount(Vector3 from, Vector3 to)
        {
            return Internal.GetNumberDynamicAreasForLine(from.X, from.Y, from.Z, to.X, to.Y, to.Z);
        }

        public bool IsInArea(Vector3 point)
        {
            AssertNotDisposed();

            return Internal.IsPointInDynamicArea(Id, point.X, point.Y, point.Z);
        }

        public static bool IsInAnyArea(Vector3 point)
        {
            return Internal.IsPointInAnyDynamicArea(point.X, point.Y, point.Z);
        }

        public bool IsAnyPlayerInArea(bool recheck = false)
        {
            AssertNotDisposed();

            return Internal.IsAnyPlayerInDynamicArea(Id, recheck);
        }

        public static bool IsPlayerInAnyArea(BasePlayer player, bool recheck = false)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return Internal.IsPlayerInAnyDynamicArea(player.Id, recheck);
        }

        public static bool IsAnyPlayerInAnyArea(bool recheck = false)
        {
            return Internal.IsAnyPlayerInAnyDynamicArea(recheck);
        }

        public static int GetAreaCountForPlayer(BasePlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return Internal.GetPlayerNumberDynamicAreas(player.Id);
        }

        public static IEnumerable<DynamicArea> GetAreasForPlayer(BasePlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.GetPlayerDynamicAreas(player.Id, out var areas, GetAreaCountForPlayer(player));

            return areas?.Select(FindOrCreate);
        }

        public void ToggleForPlayer(BasePlayer player, bool toggle)
        {
            AssertNotDisposed();

            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.TogglePlayerDynamicArea(player.Id, Id, toggle);
        }

        public static void ToggleAllForPlayer(BasePlayer player, bool toggle)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.TogglePlayerAllDynamicAreas(player.Id, toggle);
        }

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            base.Dispose(disposing);

            Internal.DestroyDynamicArea(Id);
        }

        public static void ToggleAllItems(BasePlayer player, bool toggle, DynamicArea[] exceptions)
        {
            var ids = exceptions?.Select(e => e.Id).ToArray() ?? new[] { -1 };
            WorldInternal.ToggleAllItems(player?.Id ?? -1, (int) StreamType.Area, toggle, ids,
                ids.Length);
        }

        public virtual void OnEnter(PlayerEventArgs e)
        {
            AssertNotDisposed();

            Enter?.Invoke(this, e);
        }

        public virtual void OnLeave(PlayerEventArgs e)
        {
            AssertNotDisposed();

            Leave?.Invoke(this, e);
        }

        #region Factories

        private static DynamicArea CreateArea<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3, int[] worlds, int[] interiors, BasePlayer[] players,
            int priority, Func<T1, T2, T3, int[], int[], int[], int, int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] { -1 };
            if (interiors == null) interiors = new[] { -1 };
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] { -1 };
            return
                FindOrCreate(func(arg1, arg2, arg3, worlds, interiors, pl, worlds.Length, interiors.Length, pl.Length, priority));
        }

        private static DynamicArea CreateArea<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, int[] worlds, int[] interiors, BasePlayer[] players,
            int priority, Func<T1, T2, T3, T4, int[], int[], int[], int, int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] { -1 };
            if (interiors == null) interiors = new[] { -1 };
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] { -1 };
            return
                FindOrCreate(func(arg1, arg2, arg3, arg4, worlds, interiors, pl, worlds.Length, interiors.Length,
                    pl.Length, priority));
        }

        private static DynamicArea CreateArea<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, int[] worlds,
            int[] interiors, BasePlayer[] players, int priority, Func<T1, T2, T3, T4, T5, T6, int[], int[], int[], int, int, int, int, int> func)
        {
            if (worlds == null) worlds = new[] { -1 };
            if (interiors == null) interiors = new[] { -1 };
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] { -1 };
            return
                FindOrCreate(func(arg1, arg2, arg3, arg4, arg5, arg6, worlds, interiors, pl, worlds.Length, interiors.Length,
                    pl.Length, priority));
        }

        public static DynamicArea CreateCircle(float x, float y, float size, int worldid = -1, int interiorid = -1,
            BasePlayer player = null, int priority = 0)
        {
            return
                FindOrCreate(Internal.CreateDynamicCircle(x, y, size, worldid, interiorid, player?.Id ?? -1, priority));
        }

        public static DynamicArea CreateCircleEx(float x, float y, float size, int[] worlds = null,
            int[] interiors = null, BasePlayer[] players = null, int priority = 0)
        {
            return CreateArea(x, y, size, worlds, interiors, players, priority, Internal.CreateDynamicCircleEx);
        }

        public static DynamicArea CreateCube(float minx, float miny, float minz, float maxx, float maxy, float maxz,
            int worldid = -1, int interiorid = -1, BasePlayer player = null, int priority = 0)
        {
            return
                FindOrCreate(Internal.CreateDynamicCube(minx, miny, minz, maxx, maxy, maxz, worldid, interiorid, player?.Id ?? -1, priority));
        }


        public static DynamicArea CreateCube(Vector3 min, Vector3 max, int worldid = -1, int interiorid = -1,
            BasePlayer player = null, int priority = 0)
        {
            return
                FindOrCreate(Internal.CreateDynamicCube(min.X, min.Y, min.Z, max.X, max.Y, max.Z, worldid, interiorid, player?.Id ?? -1, priority));
        }

        public static DynamicArea CreateCubeEx(float minx, float miny, float minz, float maxx, float maxy, float maxz,
            int[] worlds = null, int[] interiors = null, BasePlayer[] players = null, int priority = 0)
        {
            return CreateArea(minx, miny, minz, maxx, maxy, maxz, worlds, interiors, players, priority, Internal.CreateDynamicCubeEx);
        }

        public static DynamicArea CreateCubeEx(Vector3 min, Vector3 max, int[] worlds = null, int[] interiors = null,
            BasePlayer[] players = null, int priority = 0)
        {
            return CreateArea(min.X, min.Y, min.Z, max.X, max.Y, max.Z, worlds, interiors, players, priority, Internal.CreateDynamicCubeEx);
        }

        public static DynamicArea CreatePolygon(float[] points, float minz = float.NegativeInfinity,
            float maxz = float.PositiveInfinity, int worlid = -1, int interiorid = -1, BasePlayer player = null, int priority = 0)
        {
            return
                FindOrCreate(Internal.CreateDynamicPolygon(points, minz, maxz, points.Length, worlid, interiorid,
                    player?.Id ?? -1, priority));
        }

        public static DynamicArea CreatePolygon(Vector3[] points, float minz, float maxz, int worlid = -1,
            int interiorid = -1, BasePlayer player = null, int priority = 0)
        {
            return
                FindOrCreate(Internal.CreateDynamicPolygon(points.SelectMany(p => new[] { p.X, p.Y }).ToArray(),
                    minz, maxz, points.Length * 2, worlid, interiorid, player?.Id ?? -1, priority));
        }

        public static DynamicArea CreatePolygon(Vector3[] points, int worlid = -1, int interiorid = -1,
            BasePlayer player = null, int priority = 0)
        {
            return
                FindOrCreate(Internal.CreateDynamicPolygon(points.SelectMany(p => new[] { p.X, p.Y }).ToArray(),
                    points.Min(p => p.Z), points.Max(p => p.Z), points.Length * 2, worlid, interiorid,
                    player?.Id ?? -1, priority));
        }

        public static DynamicArea CreatePolygonEx(float[] points, float minz = float.NegativeInfinity,
            float maxz = float.PositiveInfinity, int[] worlds = null, int[] interiors = null,
            BasePlayer[] players = null, int priority = 0)
        {
            return CreateArea(points, minz, maxz, points.Length, worlds, interiors, players, priority, Internal.CreateDynamicPolygonEx);
        }

        public static DynamicArea CreatePolygonEx(Vector3[] points, float minz = float.NegativeInfinity,
            float maxz = float.PositiveInfinity, int[] worlds = null, int[] interiors = null,
            BasePlayer[] players = null, int priority = 0)
        {
            return CreateArea(points.SelectMany(p => new[] { p.X, p.Y }).ToArray(), minz, maxz,
                points.Length * 2, worlds, interiors, players, priority, Internal.CreateDynamicPolygonEx);
        }

        public static DynamicArea CreatePolygonEx(Vector3[] points, int[] worlds = null, int[] interiors = null,
            BasePlayer[] players = null, int priority = 0)
        {
            return CreateArea(points.SelectMany(p => new[] { p.X, p.Y }).ToArray(), points.Min(p => p.Z),
                points.Max(p => p.Z), points.Length * 2, worlds, interiors, players, priority, Internal.CreateDynamicPolygonEx);
        }

        public static DynamicArea CreateRectangle(float minx, float miny, float maxx, float maxy, int worldid = -1,
            int interiorid = -1, BasePlayer player = null, int priority = 0)
        {
            return FindOrCreate(Internal.CreateDynamicRectangle(minx, miny, maxx, maxy, worldid, interiorid,
                player?.Id ?? -1, priority));
        }

        public static DynamicArea CreateRectangleEx(float minx, float miny, float maxx, float maxy, int[] worlds = null,
            int[] interiors = null, BasePlayer[] players = null, int priority = 0)
        {
            return CreateArea(minx, miny, maxx, maxy, worlds, interiors, players, priority, Internal.CreateDynamicRectangleEx);
        }

        public static DynamicArea CreateSphere(Vector3 pos, float size, int worldid = -1, int interiorid = -1,
            BasePlayer player = null, int priority = 0)
        {
            return FindOrCreate(Internal.CreateDynamicSphere(pos.X, pos.Y, pos.Z, size, worldid, interiorid, player?.Id ?? -1, priority));
        }

        public static DynamicArea CreateSphereEx(Vector3 pos, float size, int[] worlds = null, int[] interiors = null,
            BasePlayer[] players = null, int priority = 0)
        {
            return CreateArea(pos.X, pos.Y, pos.Z, size, worlds, interiors, players, priority, Internal.CreateDynamicSphereEx);
        }

        #endregion
    }
}