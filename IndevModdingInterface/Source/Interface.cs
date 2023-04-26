using UnityEngine;

namespace Modding
{
    //Provides a way to access internal api
    public interface Interface
    {
        public void PlaySound(string soundName, Vector2Int position, float volume = 1f);
    }
}