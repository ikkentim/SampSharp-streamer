using SampSharp.GameMode.Controllers;
using SampSharp.Streamer.World;

namespace SampSharp.Streamer.Controllers
{
    public class StreamerController : ITypeProvider
    {
        public void RegisterTypes()
        {
            DynamicArea.Register<DynamicArea>();
            DynamicCheckpoint.Register<DynamicCheckpoint>();
            DynamicMapIcon.Register<DynamicMapIcon>();
            DynamicObject.Register<DynamicObject>();
            DynamicPickup.Register<DynamicPickup>();
            DynamicRaceCheckpoint.Register<DynamicRaceCheckpoint>();
            DynamicTextLabel.Register<DynamicTextLabel>();
        }

        public void RegisterStreamerEvents(Streamer streamer)
        {
            streamer.DynamicObjectMoved += (sender, args) =>
            {
                var @object = sender as DynamicObject;
                if (@object != null)
                    @object.OnMoved(args);
            };
            streamer.PlayerEditDynamicObject += (sender, args) =>
            {
                var @object = sender as DynamicObject;
                if (@object != null)
                    @object.OnEdited(args);
            };
            streamer.PlayerEnterDynamicArea += (sender, args) =>
            {
                var area = sender as DynamicArea;
                if (area != null)
                    area.OnEnter(args);
            };
            streamer.PlayerEnterDynamicCheckpoint += (sender, args) =>
            {
                var checkpoint = sender as DynamicCheckpoint;
                if (checkpoint != null)
                    checkpoint.OnEnter(args);
            };
            streamer.PlayerEnterDynamicRaceCheckpoint += (sender, args) =>
            {
                var checkpoint = sender as DynamicRaceCheckpoint;
                if (checkpoint != null)
                    checkpoint.OnEnter(args);
            };
            streamer.PlayerLeaveDynamicArea += (sender, args) =>
            {
                var area = sender as DynamicArea;
                if (area != null)
                    area.OnLeave(args);
            };
            streamer.PlayerLeaveDynamicCheckpoint += (sender, args) =>
            {
                var checkpoint = sender as DynamicCheckpoint;
                if (checkpoint != null)
                    checkpoint.OnLeave(args);
            };
            streamer.PlayerLeaveDynamicRaceCheckpoint += (sender, args) =>
            {
                var checkpoint = sender as DynamicRaceCheckpoint;
                if (checkpoint != null)
                    checkpoint.OnLeave(args);
            };
            streamer.PlayerPickUpDynamicPickup += (sender, args) =>
            {
                var pickup = sender as DynamicPickup;
                if (pickup != null)
                    pickup.OnPickedUp(args);
            };
            streamer.PlayerSelectDynamicObject += (sender, args) =>
            {
                var @object = sender as DynamicObject;
                if (@object != null)
                    @object.OnSelected(args);
            };
            streamer.PlayerShootDynamicObject += (sender, args) =>
            {
                var @object = sender as DynamicObject;
                if (@object != null)
                    @object.OnShot(args);
            };
        }
    }
}