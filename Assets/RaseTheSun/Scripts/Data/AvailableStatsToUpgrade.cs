using System;
using System.Collections.Generic;
using System.Linq;
using RaseTheSun.Scripts.Services.StaticDataService.Configs;

namespace RaseTheSun.Scripts.Data
{
    [Serializable]
    public class AvailableStatsToUpgrade
    {
        public List<StatType> Stats;

        public AvailableStatsToUpgrade() =>
            Stats = new List<StatType>();

        public void Add(StatType stat)
        {
            if (CheckAvailability(stat))
                return;

            Stats.Add(stat);
        }

        public bool CheckAvailability(StatType stat) =>
            Stats.Any(value => value == stat);
    }
}