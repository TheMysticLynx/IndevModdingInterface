using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Modding.PublicInterfaces.Cells;

namespace Modding
{
    //Provides convenience feature for fetching cells of this type (GetCells)
    public abstract class TickedCellStepper : CellProcessor, IUpdatedCellProcessor
    {
        private readonly List<BasicCell> _cells = new List<BasicCell>();

        protected TickedCellStepper(ICellGrid cellGrid) : base(cellGrid)
        {
        }

        public abstract void Step(CancellationToken ct);

        protected BasicCell[] GetCells()
        {
            return _cellGrid.GetCells().Where(a => a.Instance.Type == CellType && !a.Frozen).ToArray();
        }
    }
}