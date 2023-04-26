using UnityEngine;
using Object = System.Object;

namespace Modding.PublicInterfaces.Cells
{
    //Represents every cell in the game
    public struct BasicCell
    {
        internal static long _nextCellId = 0;
        public static long GetNextCellId() => _nextCellId++;

        public Instance Instance { get; }
        public ICellGrid ParentCellGrid { get; set; }
        public CellTransform Transform { get; set; }
        public CellTransform PreviousTransform { get; set; }
        public Color Color { get; set; }
        public bool Frozen { get; set; }

        public BasicCell(int type, CellTransform transform, ICellGrid parentCellGrid)
        {
            Instance = new Instance(type);
            ParentCellGrid = parentCellGrid;
            Transform = transform;
            PreviousTransform = transform;
            Color = Color.white;
            Frozen = false;
        }

        public BasicCell(Instance instance, CellTransform transform, ICellGrid parentCellGrid)
        {
            Instance = instance;
            ParentCellGrid = parentCellGrid;
            Transform = transform;
            PreviousTransform = transform;
            Color = Color.white;
            Frozen = false;
        }

        public BasicCell? Move(Vector2Int to)
        {
            return ParentCellGrid.MoveCell(this, to);
        }

        public BasicCell Rotate(int amount)
        {
            return ParentCellGrid.RotateCell(this, Transform.Direction.Rotate(amount));
        }

        public override bool Equals(Object obj)
        {
            return obj is BasicCell c && this == c;
        }
        public override int GetHashCode()
        {
            return Instance.GetHashCode();
        }
        public static bool operator ==(BasicCell x, BasicCell y)
        {
            return x.Instance == y.Instance;
        }
        public static bool operator !=(BasicCell x, BasicCell y)
        {
            return !(x == y);
        }
    }
}