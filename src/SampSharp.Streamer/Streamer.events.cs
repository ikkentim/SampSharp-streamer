using System;
using SampSharp.GameMode.Events;
using SampSharp.Streamer.Events;
using SampSharp.Streamer.World;

namespace SampSharp.Streamer
{
    public partial class Streamer
    {
        public event EventHandler<EventArgs> DynamicObjectMoved;
        public event EventHandler<PlayerEditEventArgs> PlayerEditDynamicObject;
        public event EventHandler<PlayerSelectEventArgs> PlayerSelectDynamicObject;
        public event EventHandler<PlayerShootEventArgs> PlayerShootDynamicObject;
        public event EventHandler<PlayerEventArgs> PlayerPickUpDynamicPickup;
        public event EventHandler<PlayerEventArgs> PlayerEnterDynamicCheckpoint;
        public event EventHandler<PlayerEventArgs> PlayerLeaveDynamicCheckpoint;
        public event EventHandler<PlayerEventArgs> PlayerEnterDynamicRaceCheckpoint;
        public event EventHandler<PlayerEventArgs> PlayerLeaveDynamicRaceCheckpoint;
        public event EventHandler<PlayerEventArgs> PlayerEnterDynamicArea;
        public event EventHandler<PlayerEventArgs> PlayerLeaveDynamicArea;

        private void OnDynamicObjectMoved(DynamicObject @object, EventArgs e)
        {
            if (DynamicObjectMoved != null)
                DynamicObjectMoved(@object, e);
        }

        private void OnPlayerEditDynamicObject(DynamicObject @object, PlayerEditEventArgs e)
        {
            if (PlayerEditDynamicObject != null)
                PlayerEditDynamicObject(@object, e);
        }


        private void OnPlayerSelectDynamicObject(DynamicObject @object, PlayerSelectEventArgs e)
        {
            if (PlayerSelectDynamicObject != null)
                PlayerSelectDynamicObject(@object, e);
        }

        private void OnPlayerShootDynamicObject(DynamicObject @object, PlayerShootEventArgs e)
        {
            if (PlayerShootDynamicObject != null)
                PlayerShootDynamicObject(@object, e);
        }

        private void OnPlayerPickUpDynamicPickup(DynamicPickup pickup, PlayerEventArgs e)
        {
            if (PlayerPickUpDynamicPickup != null)
                PlayerPickUpDynamicPickup(pickup, e);
        }

        private void OnPlayerEnterDynamicCheckpoint(DynamicCheckpoint checkpoint, PlayerEventArgs e)
        {
            if (PlayerEnterDynamicCheckpoint != null)
                PlayerEnterDynamicCheckpoint(checkpoint, e);
        }

        private void OnPlayerLeaveDynamicCheckpoint(DynamicCheckpoint checkpoint, PlayerEventArgs e)
        {
            if (PlayerLeaveDynamicCheckpoint != null)
                PlayerLeaveDynamicCheckpoint(checkpoint, e);
        }

        private void OnPlayerEnterDynamicRaceCheckpoint(DynamicRaceCheckpoint checkpoint, PlayerEventArgs e)
        {
            if (PlayerEnterDynamicRaceCheckpoint != null)
                PlayerEnterDynamicRaceCheckpoint(checkpoint, e);
        }

        private void OnPlayerLeaveDynamicRaceCheckpoint(DynamicRaceCheckpoint checkpoint, PlayerEventArgs e)
        {
            if (PlayerLeaveDynamicRaceCheckpoint != null)
                PlayerLeaveDynamicRaceCheckpoint(checkpoint, e);
        }

        private void OnPlayerEnterDynamicArea(DynamicArea area, PlayerEventArgs e)
        {
            if (PlayerEnterDynamicArea != null)
                PlayerEnterDynamicArea(area, e);
        }

        protected virtual void OnPlayerLeaveDynamicArea(DynamicArea area, PlayerEventArgs e)
        {
            if (PlayerLeaveDynamicArea != null)
                PlayerLeaveDynamicArea(area, e);
        }
    }
}