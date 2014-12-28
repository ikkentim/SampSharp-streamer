using Boilerplate.Controllers;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.Streamer;

namespace Boilerplate
{
    public class GameMode : BaseMode
    {
        public override bool OnGameModeInit()
        {
            // TODO: Load things

            return base.OnGameModeInit();
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);

            /*
             * Load streamer. If you do not want to use streamer, remove this line and
             * remove SampSharp.Streamer from the Project References.
             */
            Streamer.Load(controllers);

            controllers.Remove<GtaPlayerController>();
            controllers.Add(new PlayerController());
        }
    }
}