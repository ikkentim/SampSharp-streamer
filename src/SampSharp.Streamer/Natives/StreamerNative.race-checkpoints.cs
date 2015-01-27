using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Natives;

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int CreateDynamicRaceCP(CheckpointType type, float x, float y, float z, float nextx, float nexty,
            float nextz,
            float size, int worldid = -1, int interiorid = -1, int playerid = -1, float streamdistance = 100.0f)
        {
            return Native.CallNative("CreateDynamicRaceCP",
                __arglist((int) type, x, y, z, nextx, nexty, nextz, size, worldid, interiorid, playerid, streamdistance));
        }

        public static int DestroyDynamicRaceCP(int checkpointid)
        {
            return Native.CallNative("DestroyDynamicRaceCP", __arglist(checkpointid));
        }

        public static bool IsValidDynamicRaceCP(int checkpointid)
        {
            return Native.CallNativeAsBool("IsValidDynamicRaceCP", __arglist(checkpointid));
        }

        public static int TogglePlayerDynamicRaceCP(int playerid, int checkpointid, bool toggle)
        {
            return Native.CallNative("TogglePlayerDynamicRaceCP", __arglist(playerid, checkpointid, toggle));
        }

        public static int TogglePlayerAllDynamicRaceCPs(int playerid, bool toggle)
        {
            return Native.CallNative("TogglePlayerAllDynamicRaceCPs", __arglist(playerid, toggle));
        }

        public static bool IsPlayerInDynamicRaceCP(int playerid, int checkpointid)
        {
            return Native.CallNativeAsBool("IsPlayerInDynamicRaceCP", __arglist(playerid, checkpointid));
        }

        public static int GetPlayerVisibleDynamicRaceCP(int playerid)
        {
            return Native.CallNative("GetPlayerVisibleDynamicRaceCP", __arglist(playerid));
        }
    }
}