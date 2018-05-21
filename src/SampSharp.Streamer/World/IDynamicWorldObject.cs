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

using System.Collections.Generic;
using SampSharp.GameMode;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer.World
{
    public interface IDynamicWorldObject : IWorldObject
    {
        DynamicArea Area { get; set; }
        int Interior { get; set; }
        IEnumerable<int> Interiors { get; set; }
        bool IsCallbacksEnabled { get; set; }
        bool IsCheckAreaInversed { get; set; }
        bool IsStatic { get; set; }
        BasePlayer Player { get; set; }
        IEnumerable<BasePlayer> Players { get; set; }
        int Priority { get; set; }
        float StreamDistance { get; set; }
        StreamType StreamType { get; }
        int World { get; set; }
        IEnumerable<int> Worlds { get; set; }
        Vector3 Offset { get; set; }

        void HideForPlayer(BasePlayer player);
        void HideInInterior(int interiorid);
        void HideInWorld(int worlid);
        bool IsToggleItem(BasePlayer player);
        bool IsVisibleForPlayer(BasePlayer player);
        bool IsVisibleInInterior(int interiorid);
        bool IsVisibleInWorld(int worldid);
        void ShowForPlayer(BasePlayer player);
        void ShowInInterior(int interiorid);
        void ShowInWorld(int worlid);
        void ToggleItem(BasePlayer player, bool toggle);
        void ToggleUpdate(BasePlayer player, bool toggle);
    }
}