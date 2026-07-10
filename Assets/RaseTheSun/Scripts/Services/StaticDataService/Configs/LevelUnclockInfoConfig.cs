using System;
using UnityEngine.AddressableAssets;

namespace RaseTheSun.Scripts.Services.StaticDataService.Configs
{
    [Serializable]
    public class LevelUnclockInfoConfig
    {
        public int Level;
        public AssetReference IconReference;
        public string Title;
        public string Subtitle;
        public bool NeedReward;
    }
}
