using System;

namespace Modding
{
    public enum CellCategory
    {
        All,
        Gen,
        Push,
        Tick,
        Other
    }

    public class Info : Attribute
    {
        public CellCategory Category;
        public string? Description;

        public Info(CellCategory category = CellCategory.Other, string? description = null)
        {
            Category = category;
            Description = description;
        }
    }
}