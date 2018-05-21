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
            int interiorid = -1, BasePlayer player = null, float streamdistance = 100.0f, DynamicArea area = null,
            int priority = 0)
        {
            Id = Internal.CreateDynamic3DTextLabel(text, color, position.X, position.Y, position.Z, drawdistance,
                attachedPlayer?.Id ?? BasePlayer.InvalidId, attachedVehicle?.Id ?? BaseVehicle.InvalidId, testLOS,
                worldid, interiorid, player?.Id ?? -1, streamdistance, area?.Id ?? -1, priority);
        }

        public DynamicTextLabel(string text, Color color, Vector3 position, float drawdistance, float streamdistance,
            BasePlayer attachedPlayer = null, BaseVehicle attachedVehicle = null, bool testLOS = false,
            int[] worlds = null, int[] interiors = null, BasePlayer[] players = null, DynamicArea[] areas = null,
            int priority = 0)
        {
            if (worlds == null) worlds = new[] { -1 };
            if (interiors == null) interiors = new[] { -1 };
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] { -1 };
            var ar = areas?.Select(a => a.Id).ToArray() ?? new[] { -1 };
            Id = Internal.CreateDynamic3DTextLabelEx(text, color, position.X, position.Y, position.Z, drawdistance,
                attachedPlayer?.Id ?? BasePlayer.InvalidId, attachedVehicle?.Id ?? BaseVehicle.InvalidId, testLOS,
                streamdistance, worlds, interiors, pl, ar, priority, worlds.Length, interiors.Length, pl.Length,
                ar.Length);
        }

        public override StreamType StreamType
        {
            get
            {
                AssertNotDisposed();
                return StreamType.TextLabel;
            }
        }

        public bool TestLOS
        {
            get
            {
                AssertNotDisposed();
                return GetInteger(StreamerDataType.TestLOS) != 0;
            }
            set
            {
                AssertNotDisposed();
                SetInteger(StreamerDataType.TestLOS, value ? 1 : 0);
            }
        }

        public float DrawDistance
        {
            get
            {
                AssertNotDisposed();
                return GetFloat(StreamerDataType.DrawDistance);
            }
            set
            {
                AssertNotDisposed();
                SetFloat(StreamerDataType.DrawDistance, value);
            }
        }

        public string Text
        {
            get
            {
                AssertNotDisposed();
                Internal.GetDynamic3DTextLabelText(Id, out var value, 1024);
                return value;
            }
            set
            {
                AssertNotDisposed();
                Internal.UpdateDynamic3DTextLabelText(Id, Color, value);
            }
        }

        public Color Color
        {
            get
            {
                AssertNotDisposed();
                return GetInteger(StreamerDataType.Color);
            }
            set
            {
                AssertNotDisposed();
                Internal.UpdateDynamic3DTextLabelText(Id, value, Text);
            }
        }

        public bool IsValid
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsValidDynamic3DTextLabel(Id);
            }
        }

        public static void ToggleAllItems(BasePlayer player, bool toggle, DynamicTextLabel[] exceptions)
        {
            var ids = exceptions?.Select(e => e.Id).ToArray() ?? new[] { -1 };
            WorldInternal.ToggleAllItems(player?.Id ?? -1, (int) StreamType.TextLabel, toggle, ids,
                ids.Length);
        }

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            base.Dispose(disposing);

            Internal.DestroyDynamic3DTextLabel(Id);
        }
    }
}