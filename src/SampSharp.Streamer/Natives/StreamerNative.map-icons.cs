using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Natives;

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int CreateDynamicMapIcon(float x, float y, float z, int type, int color, int worldid = -1,
            int interiorid = -1, int playerid = -1, float streamdistance = 100.0f, MapIconType style = MapIconType.Local)
        {
            return Native.CallNative("CreateDynamicMapIcon",
                __arglist(x, y, z, type, color, worldid, interiorid, playerid, streamdistance, (int) style));
        }


        public static int DestroyDynamicMapIcon(int iconid)
        {
            return Native.CallNative("DestroyDynamicMapIcon", __arglist(iconid));
        }

        public static bool IsValidDynamicMapIcon(int iconid)
        {
            return Native.CallNativeAsBool("IsValidDynamicMapIcon", __arglist(iconid));
        }
    }
}