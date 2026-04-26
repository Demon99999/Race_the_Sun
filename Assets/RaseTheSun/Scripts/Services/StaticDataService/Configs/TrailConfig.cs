using RaseTheSun.Scripts.GameLogic.Trail;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RaseTheSun.Scripts.Services.StaticDataService.Configs
{
    [CreateAssetMenu(fileName = "TrailConfig", menuName = "StaticData/Create new trail config", order = 51)]
    public class TrailConfig : ScriptableObject
    {
        public TrailType Type;
        public AssetReferenceGameObject Reference;
        public int BuyCost;
        public bool IsUnlockedOnStart;
        public string Name;
        public string Title;
    }
}
