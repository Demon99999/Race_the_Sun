using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace RaseTheSun.Scripts.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        UniTask<TAsset> Load<TAsset>(string key)
            where TAsset : class;
        
        UniTask<TAsset> Load<TAsset>(AssetReferenceGameObject reference)
            where TAsset : class;
        
        UniTask InitializeAsync();
        UniTask WarmupAssetsByLable(string label);
        UniTask<TAsset[]> LoadAll<TAsset>(List<string> keys)
            where TAsset : class;
        
        UniTask<List<string>> GetAssetsListByLabel<TAsset>(string label);
        void CleanUp();
        UniTask<TAsset> Load<TAsset>(AssetReference reference);
    }
}