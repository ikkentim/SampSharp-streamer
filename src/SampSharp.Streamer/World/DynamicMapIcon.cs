using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.Natives;

namespace SampSharp.Streamer.World
{
    public class DynamicMapIcon : DynamicWorldObject<DynamicMapIcon>
    {
        public DynamicMapIcon(int id)
        {
            Id = id;
        }

        public DynamicMapIcon(Vector position, int type, MapIconType mapIconType = MapIconType.Local, int worldid = -1,
            int interiorid = -1,
            GtaPlayer player = null, float streamDistance = 100.0f)
        {
            Id = StreamerNative.CreateDynamicMapIcon(position.X, position.Y, position.Z, type, 0, worldid, interiorid,
                player == null ? -1 : player.Id, streamDistance, mapIconType);
        }

        public DynamicMapIcon(Vector position, Color color, MapIconType mapIconType = MapIconType.Local,
            int worldid = -1, int interiorid = -1,
            GtaPlayer player = null, float streamDistance = 100.0f)
        {
            Id = StreamerNative.CreateDynamicMapIcon(position.X, position.Y, position.Z, 0, color, worldid, interiorid,
                player == null ? -1 : player.Id, streamDistance, mapIconType);
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

        public bool IsValid
        {
            get { return StreamerNative.IsValidDynamicMapIcon(Id); }
        }

        public override StreamType StreamType
        {
            get { return StreamType.MapIcon; }
        }

        protected override void Dispose(bool disposing)
        {
            StreamerNative.DestroyDynamicMapIcon(Id);

            base.Dispose(disposing);
        }
    }
}