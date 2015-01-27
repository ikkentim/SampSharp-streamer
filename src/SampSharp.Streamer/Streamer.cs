using System;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Natives;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Controllers;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.Natives;

namespace SampSharp.Streamer
{
    public partial class Streamer
    {
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
            get { return new OptionItemTypeCollection(); }
        }

        public static void ProcessActiveItems()
        {
            StreamerNative.ProcessActiveItems();
        }


        public static Streamer Load(ControllerCollection controllers)
        {
            var streamer = new Streamer();
            Native.RegisterExtension(streamer);
            var controller = new StreamerController();

            controller.RegisterStreamerEvents(streamer);
            controllers.Add(controller);

            return streamer;
        }

        public static void ToggleIdleUpdate(GtaPlayer player, bool toggle)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            StreamerNative.ToggleIdleUpdate(player.Id, toggle);
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

        #region Subclasses

        public class OptionItemType
        {
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

            public StreamType StreamType { get; set; }

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

        public class OptionItemTypeCollection
        {
            public OptionItemType this[StreamType t]
            {
                get { return new OptionItemType {StreamType = t}; }
            }
        }

        #endregion
    }
}