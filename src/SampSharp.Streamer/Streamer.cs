// SampSharp.Streamer
// Copyright 2015 Tim Potze
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
using SampSharp.GameMode.Natives;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Controllers;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.Natives;

namespace SampSharp.Streamer
{
    public partial class Streamer : IStreamer
    {
        public const int InvalidId = 0;

        private static readonly OptionItemTypeCollection OptionItemTypeCollectionBackingField =
            new OptionItemTypeCollection();

        #region Constructors

        public Streamer(BaseMode gameMode)
        {
            GameMode = gameMode;
        }

        #endregion

        #region Implementation of IService

        /// <summary>
        ///     Gets the game mode.
        /// </summary>
        public BaseMode GameMode { get; private set; }

        #endregion

        public static void ProcessActiveItems()
        {
            StreamerNative.ProcessActiveItems();
        }

        public static IStreamer Load(BaseMode gameMode, ControllerCollection controllers)
        {
            // Check whether the streamer service was already loaded.
            var existing = gameMode.Services.GetService<IStreamer>();
            if (existing != null)
                return existing;

            // Create and add the steamer service to the service provider.
            var streamer = new Streamer(gameMode);
            gameMode.Services.AddService<IStreamer>(streamer);

            // Register the streamer as a gamemode extension
            Native.RegisterExtension(streamer);

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

                if (streamerController != null)
                    streamerController.RegisterStreamerEvents(streamer);

                var controller = instance as IController;

                controllers.Add(controller);
            }

            return streamer;
        }

        public static void ToggleIdleUpdate(GtaPlayer player, bool toggle)
        {
            if (player == null)
                throw new ArgumentNullException("player");

            StreamerNative.ToggleIdleUpdate(player.Id, toggle);
        }

        public static bool IsToggleIdleUpdate(GtaPlayer player)
        {
            if (player == null)
                throw new ArgumentNullException("player");

            return StreamerNative.IsToggleIdleUpdate(player.Id);
        }

        public static void ToggleCameraUpdate(GtaPlayer player, bool toggle)
        {
            if (player == null)
                throw new ArgumentNullException("player");

            StreamerNative.ToggleCameraUpdate(player.Id, toggle);
        }

        public static bool IsToggleCameraUpdate(GtaPlayer player)
        {
            if (player == null)
                throw new ArgumentNullException("player");

            return StreamerNative.IsToggleCameraUpdate(player.Id);
        }

        public static void Update(GtaPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            StreamerNative.Update(player.Id);
        }

        public static void Update(GtaPlayer player, Vector position, int worldid = -1, int interiorid = -1)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            StreamerNative.UpdateEx(player.Id, position.X, position.Y, position.Z, worldid, interiorid);
        }

        #region Properties of Streamer

        public static bool IsToggleErrorCallback
        {
            get { return StreamerNative.IsToggleErrorCallback(); }
            set { StreamerNative.ToggleErrorCallback(value); }
        }

        public static int TickRate
        {
            get { return StreamerNative.GetTickRate(); }
            set { StreamerNative.SetTickRate(value); }
        }

        public static float CellDistance
        {
            get
            {
                float value;
                StreamerNative.GetCellDistance(out value);
                return value;
            }
            set { StreamerNative.SetCellDistance(value); }
        }

        public static float CellSize
        {
            get
            {
                float value;
                StreamerNative.GetCellSize(out value);
                return value;
            }
            set { StreamerNative.SetCellSize(value); }
        }

        public static OptionItemTypeCollection ItemType
        {
            get { return OptionItemTypeCollectionBackingField; }
        }

        public static bool IsErrorCallbackEnabled
        {
            get { return StreamerNative.IsToggleErrorCallback(); }
            set { StreamerNative.ToggleErrorCallback(value); }
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
                get { return StreamerNative.GetVisibleItems(StreamType); }
                set { StreamerNative.SetVisibleItems(StreamType, value); }
            }

            public int MaxItems
            {
                get { return StreamerNative.GetMaxItems(StreamType); }
                set { StreamerNative.SetMaxItems(StreamType, value); }
            }

            public StreamType StreamType { get; private set; }

            public int GetInteger(int id, StreamerDataType data)
            {
                return StreamerNative.GetIntData(StreamType, id, data);
            }

            public float GetFloat(int id, StreamerDataType data)
            {
                float value;
                StreamerNative.GetFloatData(StreamType, id, data, out value);

                return value;
            }

            public int[] GetArray(int id, StreamerDataType data, int maxlength)
            {
                int[] value;
                StreamerNative.GetArrayData(StreamType, id, data, out value, maxlength);

                return value;
            }

            public void AppendToArray(int id, StreamerDataType data, int value)
            {
                StreamerNative.AppendArrayData(StreamType, id, data, value);
            }

            public void RemoveArrayData(int id, StreamerDataType data, int value)
            {
                StreamerNative.RemoveArrayData(StreamType, id, data, value);
            }

            public bool IsInArray(int id, StreamerDataType data, int value)
            {
                return StreamerNative.IsInArrayData(StreamType, id, data, value);
            }

            public void SetInteger(int id, StreamerDataType data, int value)
            {
                StreamerNative.SetIntData(StreamType, id, data, value);
            }

            public void SetFloat(int id, StreamerDataType data, float value)
            {
                StreamerNative.SetFloatData(StreamType, id, data, value);
            }

            public void SetArray(int id, StreamerDataType data, int[] value)
            {
                StreamerNative.SetArrayData(StreamType, id, data, value);
            }

            public void ToggleUpdate(GtaPlayer player, bool toggle)
            {
                if (player == null)
                {
                    throw new ArgumentNullException("player");
                }

                StreamerNative.ToggleItemUpdate(player.Id, StreamType, toggle);
            }
        }

        public sealed class OptionItemTypeCollection
        {
            public OptionItemType this[StreamType type]
            {
                get { return new OptionItemType(type); }
            }
        }

        #endregion
    }
}