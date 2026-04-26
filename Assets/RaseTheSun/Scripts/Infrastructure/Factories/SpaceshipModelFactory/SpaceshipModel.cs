using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace RaseTheSun.Scripts.Infrastructure.Factories.SpaceshipModelFactory
{
    public class SpaceshipModel : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<AssetReferenceGameObject, UniTask<SpaceshipModel>>
        {
        }
    }
}