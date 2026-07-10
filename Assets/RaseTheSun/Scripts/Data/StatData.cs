using System;
using RaseTheSun.Scripts.Services.StaticDataService.Configs;

namespace RaseTheSun.Scripts.Data
{
    [Serializable]
    public class StatData
    {
        public StatType Type;
        public float Value;
        public int Level;

        public StatData(StatType type, float value, int startLevel)
        {
            Level = startLevel;
            Type = type;
            Value = value;
        }
    }
}