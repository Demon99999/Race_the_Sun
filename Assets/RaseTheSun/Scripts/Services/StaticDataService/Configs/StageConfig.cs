using System;
using UnityEngine.AddressableAssets;

namespace RaseTheSun.Scripts.Services.StaticDataService.Configs
{
    [Serializable]
    public class StageConfig
    {
        public Stage Stage;
        public SkyboxConfig Skybox;
        public AssetReferenceGameObject[] Tiles;
    }
}
