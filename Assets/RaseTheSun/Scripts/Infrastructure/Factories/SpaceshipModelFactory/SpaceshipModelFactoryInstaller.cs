using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using UnityEngine.AddressableAssets;
using Zenject;

namespace RaseTheSun.Scripts.Infrastructure.Factories.SpaceshipModelFactory
{
    public class SpaceshipModelFactoryInstaller : Installer<SpaceshipModelFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISpaceshipModelFactory>().To<SpaceshipModelFactory>().AsSingle();

            Container
               .BindFactory<AssetReferenceGameObject, UniTask<SpaceshipModel>, SpaceshipModel.Factory>()
               .FromFactory<RefefencePrefabFactoryAsync<SpaceshipModel>>();

            Container
               .BindFactory<AssetReferenceGameObject, UniTask<GameLogic.Trail.Trail>, GameLogic.Trail.Trail.Factory>()
               .FromFactory<RefefencePrefabFactoryAsync<GameLogic.Trail.Trail>>();
        }
    }
}