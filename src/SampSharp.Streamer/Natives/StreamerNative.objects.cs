using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Natives;
using SampSharp.GameMode.World;

namespace SampSharp.Streamer.Natives
{
    public static partial class StreamerNative
    {
        public static int CreateDynamicObject(int modelid, float x, float y, float z, float rx, float ry, float rz,
            int worldid = -1, int interiorid = -1, int playerid = -1, float streamdistance = 200.0f,
            float drawdistance = 0.0f)
        {
            return Native.CallNative("CreateDynamicObject",
                __arglist(modelid, x, y, z, rx, ry, rz, worldid, interiorid, playerid, streamdistance, drawdistance));
        }

        public static int DestroyDynamicObject(int objectid)
        {
            return Native.CallNative("DestroyDynamicObject", __arglist(objectid));
        }

        public static bool IsValidDynamicObject(int objectid)
        {
            return Native.CallNativeAsBool("IsValidDynamicObject", __arglist(objectid));
        }

        public static int SetDynamicObjectPos(int objectid, float x, float y, float z)
        {
            return Native.CallNative("SetDynamicObjectPos", __arglist(objectid, x, y, z));
        }

        public static int GetDynamicObjectPos(int objectid, out float x, out float y, out float z)
        {
            return Native.CallNative("GetDynamicObjectPos", __arglist(objectid, out x, out y, out z));
        }

        public static int SetDynamicObjectRot(int objectid, float rx, float ry, float rz)
        {
            return Native.CallNative("SetDynamicObjectRot", __arglist(objectid, rx, ry, rz));
        }

        public static int GetDynamicObjectRot(int objectid, out float rx, out float ry, out float rz)
        {
            return Native.CallNative("GetDynamicObjectRot", __arglist(objectid, out rx, out ry, out rz));
        }

        public static int SetDynamicObjectNoCameraCol(int objectid)
        {
            return Native.CallNative("SetDynamicObjectNoCameraCol", __arglist(objectid));
        }

        public static int MoveDynamicObject(int objectid, float x, float y, float z, float speed, float rx = -1000.0f,
            float ry = -1000.0f, float rz = -1000.0f)
        {
            return Native.CallNative("MoveDynamicObject", __arglist(objectid, x, y, z, speed, rx, ry, rz));
        }

        public static int StopDynamicObject(int objectid)
        {
            return Native.CallNative("StopDynamicObject", __arglist(objectid));
        }

        public static bool IsDynamicObjectMoving(int objectid)
        {
            return Native.CallNativeAsBool("IsDynamicObjectMoving", __arglist(objectid));
        }

        public static int AttachCameraToDynamicObject(int playerid, int objectid)
        {
            return Native.CallNative("AttachCameraToDynamicObject", __arglist(playerid, objectid));
        }

        public static int AttachDynamicObjectToObject(int objectid, int attachtoid, float offsetx, float offsety,
            float offsetz, float rx, float ry, float rz, bool syncrotation = true)
        {
            return Native.CallNative("AttachDynamicObjectToObject",
                __arglist(objectid, attachtoid, offsetx, offsety, offsetz, rx, ry, rz, syncrotation));
        }

        public static int AttachDynamicObjectToPlayer(int objectid, int playerid, float offsetx, float offsety,
            float offsetz, float rx, float ry, float rz)
        {
            return Native.CallNative("AttachDynamicObjectToPlayer",
                __arglist(objectid, playerid, offsetx, offsety, offsetz, rx, ry, rz));
        }

        public static int AttachDynamicObjectToVehicle(int objectid, int vehicleid, float offsetx, float offsety,
            float offsetz, float rx, float ry, float rz)
        {
            return Native.CallNative("AttachDynamicObjectToVehicle",
                __arglist(objectid, vehicleid, offsetx, offsety, offsetz, rx, ry, rz));
        }

        public static int EditDynamicObject(int playerid, int objectid)
        {
            return Native.CallNative("EditDynamicObject", __arglist(playerid, objectid));
        }

        public static bool IsDynamicObjectMaterialUsed(int objectid, int materialindex)
        {
            return Native.CallNativeAsBool("IsDynamicObjectMaterialUsed", __arglist(objectid, materialindex));
        }

        public static int GetDynamicObjectMaterial(int objectid, int materialindex, out int modelid, out string txdname,
            out string texturename, out int materialcolor, int maxtxdname, int maxtexturename)
        {
            return Native.CallNative("GetDynamicObjectMaterial", new[] {6, 7},
                __arglist(
                    objectid, materialindex, out modelid, out txdname, out texturename, out materialcolor, maxtxdname,
                    maxtexturename));
        }

        public static int SetDynamicObjectMaterial(int objectid, int materialindex, int modelid, string txdname,
            string texturename, int materialcolor)
        {
            return Native.CallNative("SetDynamicObjectMaterial",
                __arglist(
                    objectid, materialindex, modelid, txdname, texturename,
                    materialcolor));
        }

        public static bool IsDynamicObjectMaterialTextUsed(int objectid, int materialindex)
        {
            return Native.CallNativeAsBool("IsDynamicObjectMaterialTextUsed", __arglist(objectid, materialindex));
        }

        public static int GetDynamicObjectMaterialText(int objectid, int materialindex, out string text,
            out ObjectMaterialSize materialsize, out string fontface, out int fontsize, out bool bold,
            out int fontcolor, out int backcolor, out ObjectMaterialTextAlign textalignment, int maxtext,
            int maxfontface)
        {
            int holderMaterialSize, holderTextAlignment, holderBold;
            int retval = Native.CallNative("GetDynamicObjectMaterialText", new[] {10, 11},
                __arglist(
                    objectid, materialindex, out text, out holderMaterialSize, out fontface, out fontsize,
                    out holderBold,
                    out fontcolor, out backcolor, out holderTextAlignment, maxtext, maxfontface));

            materialsize = (ObjectMaterialSize) holderMaterialSize;
            textalignment = (ObjectMaterialTextAlign) holderTextAlignment;
            bold = holderBold != 0;
            return retval;
        }

        public static int SetDynamicObjectMaterialText(int objectid, int materialindex, string text,
            ObjectMaterialSize materialsize = ObjectMaterialSize.X256X128, string fontface = "Arial", int fontsize = 24,
            bool bold = true, int fontcolor = -1, int backcolor = 0,
            ObjectMaterialTextAlign textalignment = ObjectMaterialTextAlign.Center)
        {
            return Native.CallNative("SetDynamicObjectMaterialText",
                __arglist(
                    objectid, materialindex, text, (int) materialsize, fontface, fontsize, bold, fontcolor, backcolor,
                    (int) textalignment));
        }
    }
}