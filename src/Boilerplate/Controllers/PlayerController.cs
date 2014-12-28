using Boilerplate.World;
using SampSharp.GameMode.Controllers;

namespace Boilerplate.Controllers
{
    public class PlayerController : GtaPlayerController
    {
        public override void RegisterTypes()
        {
            Player.Register<Player>();
        }
    }
}