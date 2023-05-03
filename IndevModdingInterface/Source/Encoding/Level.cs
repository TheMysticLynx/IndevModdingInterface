using Modding;

namespace IndevModdingInterface.Source
{
    public class Level
    {
        public int Width => Properties.Width;
        public int Height => Properties.Height;
        public readonly ICellGrid CellGrid;
        public LevelProperties Properties;
    }
}