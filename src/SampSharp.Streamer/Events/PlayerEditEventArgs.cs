using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace SampSharp.Streamer.Events
{
    public class PlayerEditEventArgs : PositionEventArgs
    {
        public PlayerEditEventArgs(GtaPlayer player, EditObjectResponse response,
            Vector position,
            Vector rotation)
            : base(position)
        {
            Player = player;
            Response = response;
            Rotation = rotation;
        }

        public GtaPlayer Player { get; private set; }

        public EditObjectResponse EditObjectResponse { get; private set; }

        public EditObjectResponse Response { get; set; }

        public Vector Rotation { get; private set; }
    }
}