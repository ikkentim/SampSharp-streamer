using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace SampSharp.Streamer.Events
{
    public class PlayerShootEventArgs : PlayerEventArgs
    {
        public PlayerShootEventArgs(GtaPlayer player, Weapon weapon, Vector position)
            : base(player)
        {
            Weapon = weapon;
            Position = position;
        }

        public Weapon Weapon { get; private set; }
        public Vector Position { get; private set; }
    }
}