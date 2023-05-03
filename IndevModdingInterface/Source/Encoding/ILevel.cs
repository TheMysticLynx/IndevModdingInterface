using Modding;

namespace CellEncoding
{
    public class ILevel
    {
        public int Width => Properties.Width;
        public int Height => Properties.Height;
        public ICellGrid CellGrid;
        public ILevelProperties Properties;
    }
}