namespace Modding.PublicInterfaces.Cells
{
    //Contains information about a cell that can be used to track it
    //Unique Id, Type
    public struct Instance
    {
        public short Type;

        public Instance(short type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"[{Type}]";
        }
    }
}