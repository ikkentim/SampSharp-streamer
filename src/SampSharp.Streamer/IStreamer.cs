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
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.Events;

namespace SampSharp.Streamer
{
    public interface IStreamer : IService
    {
        float CellDistance { get; set; }
        float CellSize { get; set; }
        bool IsErrorCallbackEnabled { get; set; }
        bool IsToggleErrorCallback { get; set; }
        Streamer.OptionItemTypeCollection ItemType { get; }
        bool PrintStackTraceOnError { get; set; }
        int TickRate { get; set; }
        event EventHandler<EventArgs> DynamicObjectMoved;

        event EventHandler<PlayerEditEventArgs> PlayerEditDynamicObject;

        event EventHandler<PlayerSelectEventArgs> PlayerSelectDynamicObject;

        event EventHandler<PlayerShootEventArgs> PlayerShootDynamicObject;

        event EventHandler<PlayerEventArgs> PlayerPickUpDynamicPickup;

        event EventHandler<PlayerEventArgs> PlayerEnterDynamicCheckpoint;

        event EventHandler<PlayerEventArgs> PlayerLeaveDynamicCheckpoint;

        event EventHandler<PlayerEventArgs> PlayerEnterDynamicRaceCheckpoint;

        event EventHandler<PlayerEventArgs> PlayerLeaveDynamicRaceCheckpoint;

        event EventHandler<PlayerEventArgs> PlayerEnterDynamicArea;

        event EventHandler<PlayerEventArgs> PlayerLeaveDynamicArea;

        event EventHandler<PlayerEventArgs> DynamicActorStreamIn;

        event EventHandler<PlayerEventArgs> DynamicActorStreamOut;
        
        event EventHandler<PlayerShotActorEventArgs> PlayerGiveDamageDynamicActor;

        event EventHandler<ErrorEventArgs> Error;

        float GetLastUpdateTime();
        StreamType[] GetPriority();
        bool IsToggleCameraUpdate(BasePlayer player);
        bool IsToggleIdleUpdate(BasePlayer player);
        void LoadControllers(BaseMode gameMode, ControllerCollection controllerCollection);
        void LoadServices(BaseMode gameMode);
        void ProcessActiveItems();
        void SetPriority(params StreamType[] types);
        void ToggleCameraUpdate(BasePlayer player, bool toggle);
        void ToggleIdleUpdate(BasePlayer player, bool toggle);
        void Update(BasePlayer player, Vector3 position, int worldid = -1, int interiorid = -1, int compensatedtime = -1, bool freezeplayer = true);
    }
}