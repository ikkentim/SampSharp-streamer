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

using System;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.API;
using SampSharp.GameMode.World;
using SampSharp.GameMode.Controllers;
using SampSharp.Streamer;
using SampSharp.Streamer.Controllers;
using SampSharp.Streamer.Definitions;

[assembly: SampSharpExtension(typeof(Streamer))]
namespace SampSharp.Streamer
{
    public partial class Streamer : Extension, IStreamer
    {
        public const int InvalidId = 0;
        
        #region Implementation of IService

        /// <summary>
        ///     Gets the game mode.
        /// </summary>
        public BaseMode GameMode { get; private set; }

        #endregion

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
                typeof (DynamicAreaController),
                typeof (DynamicCheckpointController),
                typeof (DynamicMapIconController),
                typeof (DynamicObjectController),
                typeof (DynamicPickupController),
                typeof (DynamicRaceCheckpointController),
                typeof (DynamicTextLabelController)
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

        public static void ProcessActiveItems()
        {
            Internal.ProcessActiveItems();
        }

        public static void ToggleIdleUpdate(BasePlayer player, bool toggle)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.ToggleIdleUpdate(player.Id, toggle);
        }

        public static bool IsToggleIdleUpdate(BasePlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return Internal.IsToggleIdleUpdate(player.Id);
        }

        public static void ToggleCameraUpdate(BasePlayer player, bool toggle)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Internal.ToggleCameraUpdate(player.Id, toggle);
        }

        public static bool IsToggleCameraUpdate(BasePlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return Internal.IsToggleCameraUpdate(player.Id);
        }

        public static void Update(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.Update(player.Id, -1);
        }

        public static void Update(BasePlayer player, Vector3 position, int worldid = -1, int interiorid = -1, int compensatedtime = -1)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Internal.UpdateEx(player.Id, position.X, position.Y, position.Z, worldid, interiorid, -1, compensatedtime);
        }

        public static void SetPriority(params StreamType[] types)
        {
            if (types == null) throw new ArgumentNullException(nameof(types));
            Internal.SetTypePriority(types.Select(t => (int) t).ToArray(), types.Length);
        }

        public static StreamType[] GetPriority()
        {
            var types = new int[(int)StreamType.Area + 1];
            Internal.GetTypePriority(types, types.Length);
            return types.Select(t => (StreamType) t).ToArray();
        }

        public static float GetLastUpdateTime()
        {
            float time;
            Internal.GetLastUpdateTime(out time);
            return time;
        }
        #region Properties of Streamer

        public static bool IsToggleErrorCallback
        {
            get { return Internal.IsToggleErrorCallback(); }
            set { Internal.ToggleErrorCallback(value); }
        }

        public static int TickRate
        {
            get { return Internal.GetTickRate(); }
            set { Internal.SetTickRate(value); }
        }

        public static float CellDistance
        {
            get
            {
                float value;
                Internal.GetCellDistance(out value);
                return value;
            }
            set { Internal.SetCellDistance(value); }
        }

        public static float CellSize
        {
            get
            {
                float value;
                Internal.GetCellSize(out value);
                return value;
            }
            set { Internal.SetCellSize(value); }
        }

        public static OptionItemTypeCollection ItemType { get; } = new OptionItemTypeCollection();

        public static bool IsErrorCallbackEnabled
        {
            get { return Internal.IsToggleErrorCallback(); }
            set { Internal.ToggleErrorCallback(value); }
        }

        public static bool PrintStackTraceOnError { get; set; }

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
            
            public StreamType StreamType { get; }

            public int GetInteger(int id, StreamerDataType data)
            {
                return Internal.GetIntData((int) StreamType, id, (int) data);
            }

            public float GetFloat(int id, StreamerDataType data)
            {
                float value;
                Internal.GetFloatData((int) StreamType, id, (int) data, out value);

                return value;
            }

            public int[] GetArray(int id, StreamerDataType data, int maxlength)
            {
                int[] value;
                Internal.GetArrayData((int) StreamType, id, (int) data, out value, maxlength);

                return value;
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
                if (player == null) throw new ArgumentNullException(nameof(player));
                return Internal.GetVisibleItems((int) StreamType, player.Id);
            }

            public void SetVisibleItems(BasePlayer player, int items)
            {
                if (player == null) throw new ArgumentNullException(nameof(player));
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