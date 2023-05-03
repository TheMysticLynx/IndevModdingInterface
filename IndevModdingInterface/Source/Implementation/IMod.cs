using System.Collections.Generic;
using Encoding;
using JetBrains.Annotations;

namespace Modding
{
    //Inherit from this class
    public interface IMod
    {
        public string UniqueName { get; }
        public string DisplayName { get; }
        public string Author { get; }
        public string Version { get; }
        [CanBeNull] public ILevelFormat LevelFormat { get; }
        public IEnumerable<CellProcessor> GetCellProcessors(ICellGrid cellGrid);
    }
}