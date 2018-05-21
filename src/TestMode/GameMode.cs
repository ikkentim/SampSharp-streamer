using System;
using System.Linq;
using System.Threading.Tasks;
using SampSharp.Core.Natives;
using SampSharp.Core.Natives.NativeObjects;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using SampSharp.Streamer;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.World;

namespace TestMode
{
    public class GameMode : BaseMode
    {
        private static DynamicArea _area;

        [Command("create")]
        public static async void CreateCommand(BasePlayer player, float size = 5)
        {
            player.SendClientMessage($"Delay...");
            await Task.Delay(100);

            var position = player.Position;
            _area?.Dispose();
            _area = DynamicArea.CreateSphere(position, size);

            player.SendClientMessage($"Area with size {size} created at {position}.");
        }
        [Command("destroy")]
        public static async void DestroyCommand(BasePlayer player)
        {
            player.SendClientMessage($"Delay...");
            await Task.Delay(100);

            _area?.Dispose();

            player.SendClientMessage(_area == null ? "Create an area with /create first." : "Area destroyed.");
            _area = null;
        }


        #region Overrides of BaseMode

        /// <summary>
        ///     Raises the <see cref="E:SampSharp.GameMode.BaseMode.Initialized" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var vehicle = BaseVehicle.Create(VehicleModelType.Alpha, Vector3.Up * 15, 0, -1, -1);
            vehicle.GetDamageStatus(out var panels, out var doors, out var lights, out var tires);
            Console.WriteLine(panels.ToString());
            Console.WriteLine(doors.ToString());
            Console.WriteLine(lights.ToString());
            Console.WriteLine(tires.ToString());
            
            var streamer = Services.GetService<IStreamer>();
            Console.WriteLine("Service: " + streamer);
            
            var area =
                DynamicArea.CreatePolygon(new[]
                {
                    Vector3.One + new Vector3(-10, -10),
                    Vector3.One + new Vector3(10, -10),
                    Vector3.One + new Vector3(10, 10),
                    Vector3.One + new Vector3(-10, 10)
                }, -100.0f, 100.0f);

            Console.WriteLine("Area handle: " + area.Id);

            area.Enter += (sender, args) => args.Player.SendClientMessage("Entered polygon");
            area.Leave += (sender, args) => args.Player.SendClientMessage("Left polygon");

            var isValid = area.IsValid;
            var position = area.Position;
            var points = area.GetPoints().ToArray();
            Console.WriteLine($"area.IsValid = {isValid}, area.Position = {position}, Points = {string.Join(", ", points)}");
            
            var area2 = DynamicArea.CreateRectangle(0, 0, 20, 20);
            area2.Enter += (sender, args) => args.Player.SendClientMessage("Entered Rectangle");
            area2.Leave += (sender, args) => args.Player.SendClientMessage("Left Rectangle");

            var icon = new DynamicMapIcon(new Vector3(1500, -1500, 0), Color.Blue, MapIconType.Global, -1, -1, null, 300);

            Console.WriteLine(icon.Position);
            icon.Position = new Vector3(50, 50, 5);
            Console.WriteLine(icon.Position);

            var pickup = new DynamicPickup(1274, 23, new Vector3(0, 0, 3), 100f,
                new[] { 11, 22, 33, 44, 0, 55, 66, 77, 88, 99 }); //Dollar icon
            pickup.PickedUp += (sender, args) => args.Player.SendClientMessage(Color.White, "Picked Up");

            var pickup2 = new DynamicPickup(1274, 23, Vector3.One, 42);

            Console.WriteLine("World: {0}", string.Join(",", pickup.Worlds));
            Console.WriteLine("World: {0}", string.Join(",", pickup2.Worlds));

            var checkpoint = new DynamicCheckpoint(new Vector3(10, 10, 3));
            checkpoint.Enter += (sender, args) => args.Player.SendClientMessage(Color.White, "Entered CP");
            checkpoint.Leave += (sender, args) => args.Player.SendClientMessage(Color.White, "Left CP");

            var actor = new DynamicActor(100, new Vector3(20, 10, 5), 0);
            


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
            streamer.IsErrorCallbackEnabled = true;
            streamer.Error += (sender, args) => { Console.WriteLine("Error CB: " + args.Error); };
            streamer.PrintStackTraceOnError = true;
            streamer.ItemType[StreamType.MapIcon].GetArray(9999, StreamerDataType.Color, 1);
            Console.WriteLine("Messages should have appeared above.");
        }

        #endregion
    }
}