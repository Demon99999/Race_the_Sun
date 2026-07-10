using UnityEngine;

namespace RaseTheSun.Scripts.Services.StaticDataService.Configs
{
    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "StaticData/Create new levels config", order = 51)]
    public class LevelsConfig : ScriptableObject
    {
        public LevelUnclockInfoConfig[] LevelUnclockInfoConfigs;

        public LevelUnclockInfoConfig GetLevelUnclockInfoConfigs(int level)
        {
            foreach (var levelConfig in LevelUnclockInfoConfigs)
            {
                if (levelConfig.Level == level)
                    return levelConfig;
            }

            return null;
        }
    }
}
