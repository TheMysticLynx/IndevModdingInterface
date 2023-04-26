using System;

namespace Modding
{
    //Used in combination with /recordsubstep and /showstep {int}
    //to provide helpful state recording and playback
    public interface IRecorderProcessor
    {
        public event Action RecordSubtick;
    }
}