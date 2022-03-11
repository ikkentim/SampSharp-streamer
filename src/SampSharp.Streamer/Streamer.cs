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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.World;
using SampSharp.Streamer;
using SampSharp.Streamer.Controllers;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.World;

[assembly: SampSharpExtension(typeof(Streamer))]

namespace SampSharp.Streamer
{
    public partial class Streamer : Extension, IStreamer
    {
        public const int InvalidId = 0;

        public static void Update(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.Update(player.Id, -1);
        }

        public void SetPlayerTickRate(BasePlayer player, int rate)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.SetPlayerTickRate(player.Id, rate);
        }

        public int GetPlayerTickRate(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return Internal.GetPlayerTickRate(player.Id);
        }

        public IEnumerable<T> GetNearbyItems<T>(Vector3 position, float range = 300, int maxItems = 32, int worldid = -1) where T : IDynamicWorldObject
        {
            var type = GetType<T>();

            Internal.GetNearbyItems(position.X, position.Y, position.Z, type, out var items, maxItems, range, worldid);

            return items.Where(item => item > 0)
                .Select(GetItem<T>)
                .Where(instance => instance != null)
                .ToArray();
        }

        public IEnumerable<T> GetVisibleItems<T>(BasePlayer player, int maxItems = 32) where T : IDynamicWorldObject
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            var type = GetType<T>();

            Internal.GetAllVisibleItems(player.Id, type, out var items, maxItems);

            return items.Where(item => item > 0)
                .Select(GetItem<T>)
                .Where(instance => instance != null)
                .ToArray();
        }

        public DynamicObject GetPlayerCameraTargetObject(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return DynamicObject.Find(Internal.GetPlayerCameraTargetDynObject(player.Id));
        }

        public DynamicActor GetPlayerTargetActor(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return DynamicActor.Find(Internal.GetPlayerTargetDynamicActor(player.Id));
        }

        public DynamicActor GetPlayerCameraTargetActor(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return DynamicActor.Find(Internal.GetPlayerCameraTargetDynActor(player.Id));
        }

        private static T GetItem<T>(int id) where T : IDynamicWorldObject
        {
            if (typeof(DynamicTextLabel).IsAssignableFrom(typeof(T)))
            {
                return (T) (IDynamicWorldObject) DynamicTextLabel.Find(id);
            }

            if (typeof(DynamicPickup).IsAssignableFrom(typeof(T)))
            {
                return (T) (IDynamicWorldObject) DynamicPickup.Find(id);
            }

            if (typeof(DynamicRaceCheckpoint).IsAssignableFrom(typeof(T)))
            {
                return (T) (IDynamicWorldObject) DynamicRaceCheckpoint.Find(id);
            }

            if (typeof(DynamicObject).IsAssignableFrom(typeof(T)))
            {
                return (T) (IDynamicWorldObject) DynamicObject.Find(id);
            }

            if (typeof(DynamicMapIcon).IsAssignableFrom(typeof(T)))
            {
                return (T) (IDynamicWorldObject) DynamicMapIcon.Find(id);
            }

            if (typeof(DynamicCheckpoint).IsAssignableFrom(typeof(T)))
            {
                return (T) (IDynamicWorldObject) DynamicCheckpoint.Find(id);
            }

            if (typeof(DynamicArea).IsAssignableFrom(typeof(T)))
            {
                return (T) (IDynamicWorldObject) DynamicArea.Find(id);
            }

            if (typeof(DynamicActor).IsAssignableFrom(typeof(T)))
            {
                return (T) (IDynamicWorldObject) DynamicActor.Find(id);
            }

            throw new InvalidOperationException("Type T is not a known dynamic world object type.");
        }

        private static int GetType<T>() where T : IDynamicWorldObject
        {
            if (typeof(DynamicTextLabel).IsAssignableFrom(typeof(T)))
            {
                return (int) StreamType.TextLabel;
            }

            if (typeof(DynamicPickup).IsAssignableFrom(typeof(T)))
            {
                return (int) StreamType.Pickup;
            }

            if (typeof(DynamicRaceCheckpoint).IsAssignableFrom(typeof(T)))
            {
                return (int) StreamType.RaceCheckpoint;
            }

            if (typeof(DynamicObject).IsAssignableFrom(typeof(T)))
            {
                return (int) StreamType.Object;
            }

            if (typeof(DynamicMapIcon).IsAssignableFrom(typeof(T)))
            {
                return (int) StreamType.MapIcon;
            }

            if (typeof(DynamicCheckpoint).IsAssignableFrom(typeof(T)))
            {
                return (int) StreamType.Checkpoint;
            }

            if (typeof(DynamicArea).IsAssignableFrom(typeof(T)))
            {
                return (int) StreamType.Area;
            }

            if (typeof(DynamicActor).IsAssignableFrom(typeof(T)))
            {
                return (int) StreamType.Actor;
            }

            throw new InvalidOperationException("Type T is not a known dynamic world object type.");
        }

        #region Implementation of IService

        /// <summary>
        ///     Gets the game mode.
        /// </summary>
        public BaseMode GameMode { get; private set; }

        #endregion

        public void ProcessActiveItems()
        {
            Internal.ProcessActiveItems();
        }

        public void ToggleIdleUpdate(BasePlayer player, bool toggle)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.ToggleIdleUpdate(player.Id, toggle);
        }

        public bool IsToggleIdleUpdate(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return Internal.IsToggleIdleUpdate(player.Id);
        }

        public void ToggleCameraUpdate(BasePlayer player, bool toggle)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.ToggleCameraUpdate(player.Id, toggle);
        }

        public bool IsToggleCameraUpdate(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return Internal.IsToggleCameraUpdate(player.Id);
        }

        public void Update(BasePlayer player, Vector3 position, int worldid = -1, int interiorid = -1, int compensatedtime = -1,
            bool freezeplayer = true)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.UpdateEx(player.Id, position.X, position.Y, position.Z, worldid, interiorid, -1, compensatedtime, freezeplayer ? 1 : 0);
        }

        public void SetPriority(params StreamType[] types)
        {
            if (types == null)
            {
                throw new ArgumentNullException(nameof(types));
            }

            Internal.SetTypePriority(types.Select(t => (int) t).ToArray(), types.Length);
        }

        public StreamType[] GetPriority()
        {
            var types = new int[(int) StreamType.Area + 1];
            Internal.GetTypePriority(types, types.Length);
            return types.Select(t => (StreamType) t).ToArray();
        }

        public float GetLastUpdateTime()
        {
            Internal.GetLastUpdateTime(out var time);
            return time;
        }

        #region Overrides of Extension

        /// <summary>
        ///     Loads services provided by this extensions.
        /// </summary>
        /// <param name="gameMode">The game mode.</param>
        public override void LoadServices(BaseMode gameMode)
        {
            // Add the steamer service to the service provider.
            GameMode = gameMode;
            gameMode.Services.AddService<IStreamer>(this);

            base.LoadServices(gameMode);
        }

        /// <summary>
        ///     Loads controllers provided by this extensions.
        /// </summary>
        /// <param name="gameMode">The game mode.</param>
        /// <param name="controllerCollection">The controller collection.</param>
        public override void LoadControllers(BaseMode gameMode, ControllerCollection controllerCollection)
        {
            // Load the steamer controllers.
            var types = new[]
            {
                typeof(DynamicAreaController),
                typeof(DynamicCheckpointController),
                typeof(DynamicMapIconController),
                typeof(DynamicObjectController),
                typeof(DynamicPickupController),
                typeof(DynamicRaceCheckpointController),
                typeof(DynamicTextLabelController)
            };

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var streamerController = instance as IStreamerController;

                streamerController?.RegisterStreamerEvents(gameMode.Services.GetService<IStreamer>());

                var controller = instance as IController;

                controllerCollection.Add(controller);
            }

            base.LoadControllers(gameMode, controllerCollection);
        }

        #endregion

        #region Properties of Streamer

        public bool IsToggleErrorCallback
        {
            get { return Internal.IsToggleErrorCallback(); }
            set { Internal.ToggleErrorCallback(value); }
        }

        [SuppressMessage("Major Code Smell", "S2376:Write-only properties should not be used", Justification = "Streamer provides no getter")]
        public bool AmxUnloadDestroyItems
        {
            set { Internal.AmxUnloadDestroyItems(value); }
        }

        public int TickRate
        {
            get { return Internal.GetTickRate(); }
            set { Internal.SetTickRate(value); }
        }

        public float CellDistance
        {
            get
            {
                Internal.GetCellDistance(out var value);
                return value;
            }
            set { Internal.SetCellDistance(value); }
        }

        public float CellSize
        {
            get
            {
                Internal.GetCellSize(out var value);
                return value;
            }
            set { Internal.SetCellSize(value); }
        }

        public OptionItemTypeCollection ItemType { get; } = new OptionItemTypeCollection();

        public bool IsErrorCallbackEnabled
        {
            get { return Internal.IsToggleErrorCallback(); }
            set { Internal.ToggleErrorCallback(value); }
        }

        public bool IsChunkStreamEnabled
        {
            get { return Internal.IsToggleChunkStream(); }
            set { Internal.ToggleChunkStream(value); }
        }

        public bool PrintStackTraceOnError { get; set; }

        #endregion

        #region Subclasses

        public sealed class OptionItemType
        {
            public OptionItemType(StreamType streamType)
            {
                StreamType = streamType;
            }

            public int VisibleItems
            {
                get { return Internal.GetVisibleItems((int) StreamType, -1); }
                set { Internal.SetVisibleItems((int) StreamType, value, -1); }
            }

            public int MaxItems
            {
                get { return Internal.GetMaxItems((int) StreamType); }
                set { Internal.SetMaxItems((int) StreamType, value); }
            }

            public int ChunkSize
            {
                get { return Internal.GetChunkSize((int) StreamType); }
                set { Internal.SetChunkSize((int) StreamType, value); }
            }

            public StreamType StreamType { get; }
            
            public Vector3 GetPosition(int id)
            {
                Internal.GetItemPos((int) StreamType, id, out var x, out var y, out var z);
                return new Vector3(x, y, z);
            }

            public void SetPosition(int id, Vector3 position)
            {
                Internal.SetItemPos((int) StreamType, id, position.X, position.Y, position.Z);
            }

            public int GetChunkTickRate(BasePlayer player = null)
            {
                return Internal.GetChunkTickRate((int) StreamType, player?.Id ?? -1);
            }

            public void SetChunkTickRate(int rate, BasePlayer player = null)
            {
                Internal.SetChunkTickRate((int) StreamType, rate, player?.Id ?? -1);
            }

            public int GetInteger(int id, StreamerDataType data)
            {
                return Internal.GetIntData((int) StreamType, id, (int) data);
            }

            public float GetFloat(int id, StreamerDataType data)
            {
                Internal.GetFloatData((int)StreamType, id, (int)data, out var value);

                return value;
            }
            
            public int[] GetArray(int id, StreamerDataType data, int maxlength = -1)
            {
                if (maxlength < 0)
                {
                    maxlength = GetArrayDataLength(id, data);
                }

                Internal.GetArrayData((int) StreamType, id, (int) data, out var value, maxlength);

                return value;
            }

            public int GetArrayDataLength(int id, StreamerDataType data)
            {
                return Internal.GetArrayDataLength((int) StreamType, id, (int) data);
            }

            public void AppendToArray(int id, StreamerDataType data, int value)
            {
                Internal.AppendArrayData((int) StreamType, id, (int) data, value);
            }

            public void RemoveArrayData(int id, StreamerDataType data, int value)
            {
                Internal.RemoveArrayData((int) StreamType, id, (int) data, value);
            }

            public bool IsInArray(int id, StreamerDataType data, int value)
            {
                return Internal.IsInArrayData((int) StreamType, id, (int) data, value);
            }

            public void SetInteger(int id, StreamerDataType data, int value)
            {
                Internal.SetIntData((int) StreamType, id, (int) data, value);
            }

            public void SetFloat(int id, StreamerDataType data, float value)
            {
                Internal.SetFloatData((int) StreamType, id, (int) data, value);
            }

            public void SetArray(int id, StreamerDataType data, int[] value)
            {
                Internal.SetArrayData((int) StreamType, id, (int) data, value, value.Length);
            }

            public void ToggleUpdate(BasePlayer player, bool toggle)
            {
                if (player == null)
                {
                    throw new ArgumentNullException(nameof(player));
                }

                Internal.ToggleItemUpdate(player.Id, (int) StreamType, toggle);
            }

            public int GetVisibleItems(BasePlayer player)
            {
                if (player == null)
                {
                    throw new ArgumentNullException(nameof(player));
                }

                return Internal.GetVisibleItems((int) StreamType, player.Id);
            }

            public void SetVisibleItems(BasePlayer player, int items)
            {
                if (player == null)
                {
                    throw new ArgumentNullException(nameof(player));
                }

                Internal.SetVisibleItems((int) StreamType, items, player.Id);
            }
        }

        public sealed class OptionItemTypeCollection
        {
            public OptionItemType this[StreamType type] => new OptionItemType(type);
        }

        #endregion
    }
}