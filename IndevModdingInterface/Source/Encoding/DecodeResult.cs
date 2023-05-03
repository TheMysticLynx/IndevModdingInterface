using Modding.PublicInterfaces.Cells;
using UnityEngine;

namespace CellEncoding
{
    public struct DecodeResult
    {
        public string DependMod;
        public string Format;
        public string Name;
        public string Description;
        public bool Vault;
        public BasicCell[] Cells;
        public Vector2Int[] DragSpots;
    }
}