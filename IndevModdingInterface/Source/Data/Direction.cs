using System;
using UnityEngine;

namespace Modding
{
    public enum Axis
    {
        Horizontal,
        Vertical
    }

    public enum DirectionName
    {
        Left,
        Right,
        Up,
        Down
    }

    //Cell machine makes heavy use of directions and axis,
    //so I made this class to make it easier to work with them.
    public struct Direction
    {
        public DirectionName Name { get; private set; }
        public int AsInt { get; private set; }
        public Vector2Int AsVector2Int { get; private set; }
        public Vector2 AsVector2 { get; private set; }
        public Axis Axis { get; private set; }

        private Direction(DirectionName name, int asInt, Vector2Int asVector2Int, Vector2 asVector2, Axis axis)
        {
            Name = name;
            AsInt = asInt;
            AsVector2Int = asVector2Int;
            AsVector2 = asVector2;
            Axis = axis;
        }

        public float GetRadians()
        {
            return AsInt * Mathf.PI * -0.5f;
        }

        public float GetDegrees()
        {
            return AsInt * -90;
        }

        public Direction Rotate(int amount)
        {
            amount = amount + AsInt;
            if (amount < 0)
                amount = (Mathf.Abs(amount) + 2);
            var newRotation = amount % 4;

            return FromInt(newRotation);
        }

        public static Direction operator+(Direction a, int b) => a.Rotate(b);
        public static Direction FromInt(int i)
        {
            return (i) switch
            {
                0 => Direction.Right,
                1 => Direction.Down,
                2 => Direction.Left,
                3 => Direction.Up,
                _ => throw new ArgumentOutOfRangeException(nameof(i), i, null)
            };
        }
        public static Direction Up => new Direction() {Name = DirectionName.Up, AsInt = 3, AsVector2Int = Vector2Int.up, AsVector2 = Vector2.up, Axis = Axis.Vertical};
        public static Direction Down => new Direction() {Name = DirectionName.Down, AsInt = 1, AsVector2Int = Vector2Int.down, AsVector2 = Vector2.down, Axis = Axis.Vertical};
        public static Direction Left => new Direction() {Name = DirectionName.Left, AsInt = 2, AsVector2Int = Vector2Int.left, AsVector2 = Vector2.left, Axis = Axis.Horizontal};
        public static Direction Right => new Direction() {Name = DirectionName.Right, AsInt = 0, AsVector2Int = Vector2Int.right, AsVector2 = Vector2.right, Axis = Axis.Horizontal};
        public static Direction[] All => new[] {Up, Down, Left, Right};
        //equality
        public static bool operator ==(Direction a, Direction b) => a.AsInt == b.AsInt;
        public static bool operator !=(Direction a, Direction b) => a.AsInt != b.AsInt;
    }
}