using System;
using UnityEngine;

namespace Modding.PublicInterfaces.Cells
{
    //Represents a cell in the game world
    public struct CellTransform
    {
        public Vector2Int Position;
        public Direction Direction;
        public int ZIndex;

        public CellTransform(Vector2Int position, Direction rotation, int zIndex = 0)
        {
            Position = position;
            Direction = rotation;
            ZIndex = zIndex;
        }

        public CellTransform Rotate(int amount)
        {
            Direction = Direction.Rotate(amount);
            return this;
        }

        public CellTransform SetPosition(Vector2Int position)
        {
            Position = position;
            return this;
        }

        public CellTransform SetDirection(Direction direction)
        {
            Direction = direction;
            return this;
        }

        public int GetDepth(ICellGrid cellGrid)
        {
            switch (Direction.Name)
            {
                case DirectionName.Left:
                    return Position.x;
                    break;
                case DirectionName.Right:
                    return cellGrid.Width - 1 - Position.x;
                    break;
                case DirectionName.Up:
                    return cellGrid.Height - 1 - Position.y;
                    break;
                case DirectionName.Down:
                    return Position.y;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public int GetAxisDepth(ICellGrid cellGrid)
        {
            switch (Direction.Name)
            {
                case DirectionName.Up:
                    return Position.x;
                case DirectionName.Down:
                    return cellGrid.Width - 1 - Position.x;
                case DirectionName.Right:
                    return cellGrid.Height - 1 - Position.y;
                case DirectionName.Left:
                    return Position.y;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}