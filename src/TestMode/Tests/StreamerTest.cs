using System;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using SampSharp.Streamer;
using SampSharp.Streamer.World;

namespace TestMode.Tests
{
    public class StreamerTest : ITest, IControllerTest
    {
        private static DynamicObject _obj;

        private readonly Vector _rotate = new Vector(20);
        private Vector _poschange = new Vector(0, 0, 1f);

        public void LoadControllers(ControllerCollection controllers)
        {
            Console.WriteLine("Loading streamer");
            Streamer.Load(controllers);
        }

        public void Start(GameMode gameMode)
        {
            DynamicArea area =
                DynamicArea.CreatePolygon(new[]
                {
                    new Vector(-1, -1, 0),
                    new Vector(1, -1, 0),
                    new Vector(1, 1, 0),
                    new Vector(-1, 1, 0)
                });
            Console.WriteLine("area.IsValid = {0}", area.IsValid);

            var icon = new DynamicMapIcon(new Vector(1500, -1500, 0), Color.Firebrick, MapIconType.Global, -1, -1, null,
                300);

            Console.WriteLine(icon.Position);
            icon.Position = new Vector(50, 50, 5);
            Console.WriteLine(icon.Position);


            var pickup = new DynamicPickup(1274, 23, new Vector(0, 0, 3), 100f,
                new[] {11, 22, 33, 44, 0, 55, 66, 77, 88, 99}); //Dollar icon
            pickup.PickedUp += (sender, args) => args.Player.SendClientMessage(Color.White, "Picked Up");

            var checkpoint = new DynamicCheckpoint(new Vector(10, 10, 3));
            checkpoint.Enter += (sender, args) => args.Player.SendClientMessage(Color.White, "Entered CP");
            checkpoint.Leave += (sender, args) => args.Player.SendClientMessage(Color.White, "Left CP");


            var racecheckpoint = new DynamicRaceCheckpoint(CheckpointType.Normal, new Vector(-10, -10, 3), new Vector());
            racecheckpoint.Enter += (sender, args) => args.Player.SendClientMessage(Color.White, "Entered RCP");
            racecheckpoint.Leave += (sender, args) => args.Player.SendClientMessage(Color.White, "Left RCP");

            new DynamicTextLabel("I am maroon", Color.Maroon, new Vector(0, 0, 5), 100.0f);

            _obj = new DynamicObject(12991, new Vector(15));

            _obj.SetMaterialText(1, "Test", ObjectMaterialSize.X512X512, "Arial", 24, false, Color.Red, Color.White);

            _obj.Moved += (sender, args) =>
            {
                _obj.Move(_obj.Position + _poschange, 0.5f, _obj.Rotation + _rotate);
                _poschange = -_poschange;
            };

            _obj.Move(_obj.Position + _poschange, 0.5f, _obj.Rotation + _rotate);

            _poschange = -_poschange;

            var pu = new DynamicPickup(1274, 23, new Vector(111), 3);

            Console.WriteLine("World: {0}", string.Join(",", pu.Worlds));
        }

        [Command("attachcam")]
        public static void AttachCamCommand(GtaPlayer player)
        {
            _obj.AttachCameraToObject(player);
        }
    }
}