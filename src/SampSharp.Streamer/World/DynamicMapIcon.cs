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

using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public partial class DynamicMapIcon : DynamicWorldObject<DynamicMapIcon>
    {
        public DynamicMapIcon(Vector3 position, int type, MapIconType mapIconType = MapIconType.Local, int worldid = -1,
            int interiorid = -1,
            BasePlayer player = null, float streamDistance = 100.0f)
        {
            Id = Internal.CreateDynamicMapIcon(position.X, position.Y, position.Z, type, 0, worldid, interiorid,
                player?.Id ?? -1, streamDistance, (int) mapIconType);
        }

        public DynamicMapIcon(Vector3 position, Color color, MapIconType mapIconType = MapIconType.Local,
            int worldid = -1, int interiorid = -1,
            BasePlayer player = null, float streamDistance = 100.0f)
        {
            Id = Internal.CreateDynamicMapIcon(position.X, position.Y, position.Z, 0, color, worldid, interiorid,
                player?.Id ?? -1, streamDistance, (int) mapIconType);
        }

        public int Type
        {
            get { return GetInteger(StreamerDataType.Type); }
            set { SetInteger(StreamerDataType.Type, value); }
        }

        public Color Color
        {
            get { return GetInteger(StreamerDataType.Color); }
            set { SetInteger(StreamerDataType.Color, value); }
        }

        public bool IsValid => Internal.IsValidDynamicMapIcon(Id);

        public override StreamType StreamType => StreamType.MapIcon;

        protected override void Dispose(bool disposing)
        {
            Internal.DestroyDynamicMapIcon(Id);

            base.Dispose(disposing);
        }
    }
}