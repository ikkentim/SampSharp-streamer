using SampSharp.Streamer.Definitions;

namespace SampSharp.Streamer
{
    public sealed class OptionItemTypeSet
    {
        public OptionItemType this[StreamType type] => new OptionItemType(type);
    }
}