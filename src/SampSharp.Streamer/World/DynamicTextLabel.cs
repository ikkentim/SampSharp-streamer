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

using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public partial class DynamicTextLabel : DynamicWorldObject<DynamicTextLabel>
    {
        public DynamicTextLabel(string text, Color color, Vector3 position, float drawdistance,
            BasePlayer attachedPlayer = null, BaseVehicle attachedVehicle = null, bool testLOS = false, int worldid = -1,
            int interiorid = -1, BasePlayer player = null, float streamdistance = 100.0f)
        {
            Id = Internal.CreateDynamic3DTextLabel(text, color, position.X, position.Y, position.Z, drawdistance,
                attachedPlayer?.Id ?? BasePlayer.InvalidId, attachedVehicle?.Id ?? BaseVehicle.InvalidId, testLOS,
                worldid, interiorid, player?.Id ?? -1, streamdistance);
        }

        public DynamicTextLabel(string text, Color color, Vector3 position,
            float drawdistance, float streamdistance, BasePlayer attachedPlayer = null,
            BaseVehicle attachedVehicle = null,
            bool testLOS = false,
            int[] worlds = null, int[] interiors = null, BasePlayer[] players = null)
        {
            if (worlds == null) worlds = new[] {-1};
            if (interiors == null) interiors = new[] {-1};
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] {-1};
            Id = Internal.CreateDynamic3DTextLabelEx(text, color, position.X, position.Y, position.Z, drawdistance,
                attachedPlayer?.Id ?? BasePlayer.InvalidId, attachedVehicle?.Id ?? BaseVehicle.InvalidId, testLOS,
                streamdistance, worlds, interiors, pl, worlds.Length, interiors.Length, pl.Length);
        }

        public override StreamType StreamType => StreamType.TextLabel;

        public bool TestLOS
        {
            get { return GetInteger(StreamerDataType.TestLOS) != 0; }
            set { SetInteger(StreamerDataType.TestLOS, value ? 1 : 0); }
        }

        public float DrawDistance
        {
            get { return GetFloat(StreamerDataType.DrawDistance); }
            set { SetFloat(StreamerDataType.DrawDistance, value); }
        }

        public string Text
        {
            get
            {
                string value;
                Internal.GetDynamic3DTextLabelText(Id, out value, 1024);
                return value;
            }
            set { Internal.UpdateDynamic3DTextLabelText(Id, Color, value); }
        }

        public Color Color
        {
            get { return GetInteger(StreamerDataType.Color); }
            set { Internal.UpdateDynamic3DTextLabelText(Id, value, Text); }
        }

        public bool IsValid => Internal.IsValidDynamic3DTextLabel(Id);

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Internal.DestroyDynamic3DTextLabel(Id);
        }
    }
}