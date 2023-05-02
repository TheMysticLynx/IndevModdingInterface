using System;
using UnityEngine;

namespace Modding.PublicInterfaces.Cells
{
    //Represents a cell in the game world
    public struct CellTransform
    {
        private ushort _x;
        private ushort _y;
        public Vector2Int Position => new Vector2Int(_x, _y);
        public byte DirectionInt;

        public Direction Direction
        {
            get => Direction.FromInt(DirectionInt);
            set => DirectionInt = (byte)value.AsInt;
        }

        public CellTransform(Vector2Int position, Direction rotation)
        {
            _x = (ushort)position.x;
            _y = (ushort)position.y;
            DirectionInt = (byte)rotation.AsInt;
        }

        public CellTransform Rotate(int amount)
        {
            Direction = Direction.Rotate(amount);
            return this;
        }

        public CellTransform SetPosition(Vector2Int position)
        {
            _x = (ushort)position.x;
            _y = (ushort)position.y;
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