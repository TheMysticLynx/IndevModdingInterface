namespace Modding.PublicInterfaces.Cells
{
    //Contains information about a cell that can be used to track it
    //Unique Id, Type
    public struct Instance
    {
        internal static long _instanceCount = 0;
        public long ID;
        public int Type;

        public Instance(int type)
        {
            ID = _instanceCount++;
            Type = type;
        }

        //Equality
        public static bool operator ==(Instance a, Instance b)
        {
            return a.ID == b.ID;
        }

        public static bool operator !=(Instance a, Instance b)
        {
            return a.ID != b.ID;
        }

        public override bool Equals(object obj)
        {
            if (obj is Instance)
            {
                return this == (Instance)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return $"[{Type}]{ID}";
        }
    }
}