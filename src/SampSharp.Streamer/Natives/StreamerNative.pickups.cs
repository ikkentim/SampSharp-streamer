using SampSharp.GameMode.Natives;

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int CreateDynamicPickup(int modelid, int type, float x, float y, float z, int worldid = -1,
            int interiorid = -1, int playerid = -1, float streamdistance = 100.0f)
        {
            return Native.CallNative("CreateDynamicPickup",
                __arglist(modelid, type, x, y, z, worldid, interiorid, playerid, streamdistance));
        }

        public static int DestroyDynamicPickup(int pickupid)
        {
            return Native.CallNative("DestroyDynamicPickup", __arglist(pickupid));
        }

        public static bool IsValidDynamicPickup(int pickupid)
        {
            return Native.CallNativeAsBool("IsValidDynamicPickup", __arglist(pickupid));
        }
    }
}