using System.Collections.Generic;

namespace Modding
{
    //Inherit from this class
    public interface IMod
    {
        public string UniqueName { get; }
        public string DisplayName { get; }
        public string Author { get; }
        public string Version { get; }
        public IEnumerable<CellProcessor> GetCellProcessors(ICellGrid cellGrid);
    }
}