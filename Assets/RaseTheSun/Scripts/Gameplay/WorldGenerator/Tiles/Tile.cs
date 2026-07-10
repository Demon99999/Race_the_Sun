using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay.WorldGenerator.Tiles
{
    public class Tile : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<AssetReferenceGameObject, UniTask<Tile>>
        {
            
        }
    }
}
