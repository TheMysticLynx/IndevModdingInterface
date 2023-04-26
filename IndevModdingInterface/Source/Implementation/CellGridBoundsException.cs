using System;
using Modding.PublicInterfaces.Cells;
using UnityEngine;

namespace Modding
{
    public class CellGridBoundsException : Exception
    {
        //Used internally to throw an exception when a cell is accessed outside of the grid bounds
        public CellGridBoundsException(int levelWidth, int levelHeight, Vector2Int index, BasicCell cell) : base($"Level bounds exceeded: {levelWidth}x{levelHeight} at {index.x},{index.y} with cell {cell}")
        {
            
        }
    }
}