using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Modding.PublicInterfaces.Cells;
using Unity.Collections;
using Unity.Jobs;

namespace Modding
{
    //Inherit from this class to access GetOrderedCellEnumerable
    //which will return a list of cells in the order they would be processed by the
    //original game's cell processing system.
    public abstract class SteppedCellProcessor : CellProcessor, IUpdatedCellProcessor, IRecorderProcessor
    {
        private static readonly int[] DirectionUpdateOrder = new int[] { 0, 2, 3, 1 };

        protected SteppedCellProcessor(ICellGrid cellGrid) : base(cellGrid)
        {
            var size = Math.Max(cellGrid.Width, cellGrid.Height);
        }

        public event Action RecordSubtick;
        public abstract void Step(CancellationToken cancellationToken);

        public IEnumerable<BasicCell> GetOrderedCellEnumerable()
        {
            foreach (var d in DirectionUpdateOrder)
            {
                var direction = Direction.FromInt(d);

                if (direction.Axis == Axis.Horizontal)
                {
                    foreach (var row in _cellGrid.GetRows())
                    {
                        var cells = row.Where(a => a.Transform.Direction == direction && a.Instance.Type == CellType);
                        //sort
                        var cached = cells.OrderBy(c => c.Transform.GetDepth(_cellGrid)).ToArray();
                        foreach (var cell in cached)
                        {
                            if(!cell.Frozen)
                                yield return cell;
                        }
                    }
                }
                else
                {
                    foreach (var column in _cellGrid.GetColumns())
                    {
                        var cells = column.Where(a => a.Transform.Direction == direction && a.Instance.Type == CellType);
                        //sort
                        var cached = cells.OrderBy(c => c.Transform.GetDepth(_cellGrid)).ToArray();
                        foreach (var cell in cached)
                        {
                            if(!cell.Frozen)
                                yield return cell;
                        }
                    }
                }
                RecordSubtick?.Invoke();
            }
        }
    }
}