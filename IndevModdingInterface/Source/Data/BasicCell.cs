using UnityEngine;
using Object = System.Object;

namespace Modding.PublicInterfaces.Cells
{
    //Represents every cell in the game
    public struct BasicCell
    {
        public Instance Instance { get; }
        public CellTransform Transform { get; set; }
        public CellTransform PreviousTransform { get; set; }
        public Color Color { get; set; }
        public bool Frozen { get; set; }

        public BasicCell(int type, CellTransform transform)
        {
            Instance = new Instance((short)type);
            Transform = transform;
            PreviousTransform = transform;
            Color = Color.white;
            Frozen = false;
        }

        public BasicCell(Instance instance, CellTransform transform)
        {
            Instance = instance;
            Transform = transform;
            PreviousTransform = transform;
            Color = Color.white;
            Frozen = false;
        }
    }
}