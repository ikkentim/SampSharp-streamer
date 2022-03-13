using System;
using SampSharp.GameMode;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer
{
    public sealed class OptionItemType
    {
        public OptionItemType(StreamType streamType)
        {
            StreamType = streamType;
        }

        public int VisibleItems
        {
            get { return Streamer.Internal.GetVisibleItems((int)StreamType, -1); }
            set { Streamer.Internal.SetVisibleItems((int)StreamType, value, -1); }
        }

        public int MaxItems
        {
            get { return Streamer.Internal.GetMaxItems((int)StreamType); }
            set { Streamer.Internal.SetMaxItems((int)StreamType, value); }
        }

        public int ChunkSize
        {
            get { return Streamer.Internal.GetChunkSize((int)StreamType); }
            set { Streamer.Internal.SetChunkSize((int)StreamType, value); }
        }

        public StreamType StreamType { get; }

        public Vector3 GetPosition(int id)
        {
            Streamer.Internal.GetItemPos((int)StreamType, id, out var x, out var y, out var z);
            return new Vector3(x, y, z);
        }

        public void SetPosition(int id, Vector3 position)
        {
            Streamer.Internal.SetItemPos((int)StreamType, id, position.X, position.Y, position.Z);
        }

        public int GetChunkTickRate(BasePlayer player = null)
        {
            return Streamer.Internal.GetChunkTickRate((int)StreamType, player?.Id ?? -1);
        }

        public void SetChunkTickRate(int rate, BasePlayer player = null)
        {
            Streamer.Internal.SetChunkTickRate((int)StreamType, rate, player?.Id ?? -1);
        }

        public int GetInteger(int id, StreamerDataType data)
        {
            return Streamer.Internal.GetIntData((int)StreamType, id, (int)data);
        }

        public float GetFloat(int id, StreamerDataType data)
        {
            Streamer.Internal.GetFloatData((int)StreamType, id, (int)data, out var value);

            return value;
        }

        public int[] GetArray(int id, StreamerDataType data, int maxlength = -1)
        {
            if (maxlength < 0)
            {
                maxlength = GetArrayDataLength(id, data);
            }

            Streamer.Internal.GetArrayData((int)StreamType, id, (int)data, out var value, maxlength);

            return value;
        }

        public int GetArrayDataLength(int id, StreamerDataType data)
        {
            return Streamer.Internal.GetArrayDataLength((int)StreamType, id, (int)data);
        }

        public void AppendToArray(int id, StreamerDataType data, int value)
        {
            Streamer.Internal.AppendArrayData((int)StreamType, id, (int)data, value);
        }

        public void RemoveArrayData(int id, StreamerDataType data, int value)
        {
            Streamer.Internal.RemoveArrayData((int)StreamType, id, (int)data, value);
        }

        public bool IsInArray(int id, StreamerDataType data, int value)
        {
            return Streamer.Internal.IsInArrayData((int)StreamType, id, (int)data, value);
        }

        public void SetInteger(int id, StreamerDataType data, int value)
        {
            Streamer.Internal.SetIntData((int)StreamType, id, (int)data, value);
        }

        public void SetFloat(int id, StreamerDataType data, float value)
        {
            Streamer.Internal.SetFloatData((int)StreamType, id, (int)data, value);
        }

        public void SetArray(int id, StreamerDataType data, int[] value)
        {
            Streamer.Internal.SetArrayData((int)StreamType, id, (int)data, value, value.Length);
        }

        public void ToggleUpdate(BasePlayer player, bool toggle)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Streamer.Internal.ToggleItemUpdate(player.Id, (int)StreamType, toggle);
        }

        public int GetVisibleItems(BasePlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return Streamer.Internal.GetVisibleItems((int)StreamType, player.Id);
        }

        public void SetVisibleItems(BasePlayer player, int items)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Streamer.Internal.SetVisibleItems((int)StreamType, items, player.Id);
        }
    }
}