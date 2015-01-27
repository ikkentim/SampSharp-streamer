using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace SampSharp.Streamer.Events
{
    public class PlayerSelectEventArgs : PlayerEventArgs
    {
        public PlayerSelectEventArgs(GtaPlayer player, int modelid, Vector position)
            : base(player)
        {
            ModelId = modelid;
            Position = position;
        }

        public int ModelId { get; private set; }
        public Vector Position { get; private set; }
    }
}