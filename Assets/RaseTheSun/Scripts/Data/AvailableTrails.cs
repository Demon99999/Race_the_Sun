using System;
using System.Collections.Generic;
using RaseTheSun.Scripts.GameLogic.Trail;

namespace RaseTheSun.Scripts.Data
{
    [Serializable]
    public class AvailableTrails
    {
        public List<TrailType> UnlockedTrails;

        public AvailableTrails(List<TrailType> trails) =>
            UnlockedTrails = trails;

        public bool IsUnlocked(TrailType type) =>
            UnlockedTrails.Contains(type);
    }
}