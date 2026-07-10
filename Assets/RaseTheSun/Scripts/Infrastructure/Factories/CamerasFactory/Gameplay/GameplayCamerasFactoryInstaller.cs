using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.GameLogic.Cameras.Gameplay;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using Zenject;

namespace RaseTheSun.Scripts.Infrastructure.Factories.CamerasFactory.Gameplay
{
    public class GameplayCamerasFactoryInstaller : Installer<GameplayCamerasFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGameplayCamerasFactory>()
                .To<GameplayCamerasFactory>()
                .AsSingle();

            Container
                .BindFactory<string, UniTask<VirtualCamera>, VirtualCamera.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<VirtualCamera>>();
        }
    }
}