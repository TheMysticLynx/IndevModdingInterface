using Modding;

namespace CellEncoding
{
    public interface ILevel
    {
        public int Width { get; }
        public int Height { get; }
        public ICellGrid CellGrid { get; }
        public ILevelProperties Properties { get; }
    }
}