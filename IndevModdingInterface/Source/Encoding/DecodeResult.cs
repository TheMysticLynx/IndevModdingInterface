using IndevModdingInterface.Source;
using Modding.PublicInterfaces.Cells;
using UnityEngine;

namespace Encoding
{
    public struct DecodeResult
    {
        public string DependMod;
        public string ModVersion;
        public string Format;
        public BasicCell[] Cells;
        public Vector2Int[] DragSpots;
        public LevelProperties LevelProperties;
    }
}