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

using System.Collections.Generic;

using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    /// <summary>
    /// Represents a component which provides the data and functionality of an dynamic area.
    /// </summary>
    public sealed class DynamicArea : Component
    {
        private DynamicArea()
        {

        }

        /// <summary>
        /// Gets whether this dynamic area is valid.
        /// </summary>
        public bool IsValid => GetComponent<NativeDynamicArea>().IsValidDynamicArea();

        /// <summary>
        /// Gets the dynamic area type.
        /// </summary>
        public AreaType AreaType => (AreaType)GetComponent<NativeDynamicArea>().GetDynamicAreaType();

        /// <summary>
        /// Gets polygon points.
        /// </summary>
        public IEnumerable<Vector3> GetPolygonPoints()
        {
            var pointCount = GetPointsCount();
            GetComponent<NativeDynamicArea>().GetDynamicPolygonPoints(out var points, pointCount * 2);

            if (points == null) yield break;

            for (var i = 0; i < points.Length - 1; i += 2)
            {
                yield return new Vector3(points[i], points[i + 1]);
            }
        }

        /// <summary>
        /// Gets number points.
        /// </summary>
        public int GetPointsCount()
        {
            return GetComponent<NativeDynamicArea>().GetDynamicPolygonNumberPoints();
        }

        /// <summary>
        /// Gets any player in area.
        /// </summary>
        public bool IsAnyPlayerInArea(bool recheck = false)
        {
            return GetComponent<NativeDynamicArea>().IsAnyPlayerInDynamicArea(recheck);
        }

        /// <summary>
        /// Gets any player in any area.
        /// </summary>
        public bool IsAnyPlayerInAnyArea(bool recheck = false)
        {
            return GetComponent<NativeDynamicArea>().IsAnyPlayerInAnyDynamicArea(recheck);
        }

        /// <inheritdoc />
        protected override void OnDestroyComponent()
        {
            GetComponent<NativeDynamicArea>().DestroyDynamicArea();
        }
    }
}
