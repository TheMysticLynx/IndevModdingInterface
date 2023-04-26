using System;
using System.Collections.Generic;
using Modding.PublicInterfaces.Cells;
using UnityEngine;

namespace Modding
{
    //Saves state information about a simulation as well as
    //a list of cell processors that will be used to process
    //state updates for the simulation
    public interface ICellGrid
    {
        public int Width { get; }
        public int Height { get; }

        public event Action<BasicCell>? OnCellAdded;
        public event Action<BasicCell>? OnCellRemoved;
        public event Action<BasicCell, CellTransform>? OnCellChanged;

        public void RemoveCell(BasicCell cell);
        public void RemoveCell(int x, int y);
        public void RemoveCell(Vector2Int position);
        public BasicCell? AddCell(Vector2Int position, Direction direction, int cellType, CellTransform? previousPosition = null);
        public void AddCell(BasicCell cell);
        public bool InBounds(int x, int y);
        public bool InBounds(Vector2Int pos);
        public BasicCell? MoveCell(BasicCell cell, Vector2Int newPos);
        public BasicCell RotateCell(BasicCell cell, Direction newDirection);

        public BasicCell? GetCell(int x, int y);
        public BasicCell? GetCell(Vector2Int pos);
        public bool PushCell(BasicCell cell, Direction direction, int force);
        public CellProcessor GetCellProcessor(int type);

        public BasicCell? this[int x, int y] { get; }
        public BasicCell? this[Vector2Int pos] { get; }

        public IEnumerable<BasicCell> GetCells();
        public abstract IEnumerable<IEnumerable<BasicCell>> GetRows();
        public abstract IEnumerable<IEnumerable<BasicCell>> GetColumns();
    }
}