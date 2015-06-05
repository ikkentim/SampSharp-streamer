using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;

namespace TestMode.Tests
{
    public interface IControllerTest
    {
        void LoadControllers(BaseMode gameMode, ControllerCollection controllers);
    }
}