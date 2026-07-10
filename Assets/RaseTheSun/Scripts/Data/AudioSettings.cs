using System;

namespace RaseTheSun.Scripts.Data
{
    [Serializable]
    public class AudioSettings
    {
        public float MusicVolume;
        public float SoundsVolume;

        public AudioSettings()
        {
            MusicVolume = 0;
            SoundsVolume = 0;
        }
    }
}