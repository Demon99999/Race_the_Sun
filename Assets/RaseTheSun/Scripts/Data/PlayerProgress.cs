using System;
using UnityEngine;

namespace RaseTheSun.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public AudioSettings AudioSettings;
        public int HighScore;

        public PlayerProgress()
        {
            
            AudioSettings = new AudioSettings();
            HighScore = 0;
        }
    }
}