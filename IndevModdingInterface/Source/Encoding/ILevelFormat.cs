using IndevModdingInterface.Source;

namespace Encoding
{
    public interface ILevelFormat
    {
        public string Name { get; }

        public (byte[], string) EncodeLevel(Level level);
        public DecodeResult Decode(byte[] data);
        public DecodeResult Decode(string level);
        public bool Matches(byte[] data);
        public bool Matches(string level);
    }
}