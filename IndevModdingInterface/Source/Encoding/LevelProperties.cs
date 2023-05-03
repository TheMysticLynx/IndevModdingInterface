namespace CellEncoding
{
    public interface ILevelProperties
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public long Time { get; set; }
        public string DependMod { get; set; }
        public bool Vault { get; set; }
    }
}