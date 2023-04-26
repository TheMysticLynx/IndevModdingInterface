using System.Collections.Generic;
using Modding.PublicInterfaces.Cells;

namespace Modding
{
    //Provides behavior for a cell
    public abstract class CellProcessor
    {
        public abstract string Name { get; }
        public abstract int CellType { get; }
        public abstract string CellSpriteIndex { get; }

        protected readonly ICellGrid _cellGrid;

        protected CellProcessor(ICellGrid cellGrid)
        {
            _cellGrid = cellGrid;
        }

        /// <summary>
        /// Called to mutate the cell grid
        /// </summary>
        /// <param name="cell">cell to attempt pushing</param>
        /// <param name="direction">direction to push cell in</param>
        /// <param name="force">reduced every time a cell in the try push call stack is pushing against direction</param>
        /// <returns>true if the operation succeeded</returns>
        public abstract bool TryPush(BasicCell cell, Direction direction, int force);

        /// <summary>
        /// Called when a cell trys to occupy the same space as this cell
        /// usually you would avoid writing code that would cause this to happen
        /// but in the case of a trash cell it's  simpler to just have it eat
        /// cells that try to occupy the same space rather then making the api more complex.
        /// This also means trash cells allow other cells to slide over them
        /// (none of the original cells do this)
        /// </summary>
        /// <returns>true if the cell grid should throw a error</returns>
        public abstract bool OnReplaced(BasicCell basicCell, BasicCell replacingCell);
        public abstract void OnCellInit(ref BasicCell cell);
        public abstract void Clear();
    }
}