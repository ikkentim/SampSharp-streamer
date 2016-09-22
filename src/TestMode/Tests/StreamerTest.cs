using System;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.Streamer;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.World;

namespace TestMode.Tests
{
    public class StreamerTest : ITest
    {
        public void Start(GameMode gameMode)
        {
            var str = gameMode.Services.GetService<IStreamer>();
            Streamer.PrintStackTraceOnError = true;
            
            DynamicArea area =
                DynamicArea.CreatePolygon(new[]
                {
                    Vector3.One + new Vector3(-10, -10),
                    Vector3.One + new Vector3(10, -10),
                    Vector3.One + new Vector3(10, 10),
                    Vector3.One + new Vector3(-10, 10)
                }, -100.0f, 100.0f);
            
            area.Enter += (sender, args) => args.Player.SendClientMessage("Entered polygon");
            area.Leave += (sender, args) => args.Player.SendClientMessage("Left polygon");

            Console.WriteLine("area.IsValid = {0}, area.Position = {1}, Points = {2}", area.IsValid, area.Position,
                string.Join(", ", area.GetPoints()));

            var area2 = DynamicArea.CreateRectangle(0, 0, 20, 20);
            area2.Enter += (sender, args) => args.Player.SendClientMessage("Entered Rectangle");
            area2.Leave += (sender, args) => args.Player.SendClientMessage("Left Rectangle");

            var icon = new DynamicMapIcon(new Vector3(1500, -1500, 0), Color.Blue, MapIconType.Global, -1, -1, null, 300);

            Console.WriteLine(icon.Position);
            icon.Position = new Vector3(50, 50, 5);
            Console.WriteLine(icon.Position);

            var pickup = new DynamicPickup(1274, 23, new Vector3(0, 0, 3), 100f,
                new[] {11, 22, 33, 44, 0, 55, 66, 77, 88, 99}); //Dollar icon
            pickup.PickedUp += (sender, args) => args.Player.SendClientMessage(Color.White, "Picked Up");
            
            var pickup2 = new DynamicPickup(1274, 23, Vector3.One, 42);
            
            Console.WriteLine("World: {0}", string.Join(",", pickup.Worlds));
            Console.WriteLine("World: {0}", string.Join(",", pickup2.Worlds));

            var checkpoint = new DynamicCheckpoint(new Vector3(10, 10, 3));
            checkpoint.Enter += (sender, args) => args.Player.SendClientMessage(Color.White, "Entered CP");
            checkpoint.Leave += (sender, args) => args.Player.SendClientMessage(Color.White, "Left CP");


            var racecheckpoint = new DynamicRaceCheckpoint(CheckpointType.Normal, new Vector3(-10, -10, 3), new Vector3());
            racecheckpoint.Enter += (sender, args) => args.Player.SendClientMessage(Color.White, "Entered RCP");
            racecheckpoint.Leave += (sender, args) => args.Player.SendClientMessage(Color.White, "Left RCP");

            new DynamicTextLabel("[I am maroon]", Color.Maroon, pickup.Position + new Vector3(0, 0, 1), 100.0f);

            var obj = new DynamicObject(12991, new Vector3(10, 10, 3));
            var offset = Vector3.One;
            obj.SetMaterialText(1, "Test", ObjectMaterialSize.X512X512, "Arial", 30, false, Color.Black, Color.White);
            obj.Move(obj.Position + -offset, 0.6f, obj.Rotation + new Vector3(0, 0, 25));
            obj.Moved += (sender, args) =>
            {
                Console.WriteLine("moved");
                obj.Move(obj.Position + (offset = -offset), 0.6f, obj.Rotation + new Vector3(0, 0, 25));
            };


            Console.WriteLine("Test error handling...");
            Streamer.IsErrorCallbackEnabled = true;
            Streamer.PrintStackTraceOnError = true;
            Streamer.ItemType[StreamType.MapIcon].GetArray(9999, StreamerDataType.Color, 1);
            Console.WriteLine("Messages should have appeared above.");

        }
    }
}