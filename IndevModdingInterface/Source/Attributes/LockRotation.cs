using System;

namespace Modding
{
    //Use this attribute on a cell processor to tell the mod loader to ignore
    //rotation requests for this cell type. (ex: wall)
    public class LockRotation : Attribute
    {
    }
}