using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.GameLogic.Cameras.MainMenu;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using Zenject;

namespace RaseTheSun.Scripts.Infrastructure.Factories.CamerasFactory.MainMenu
{
    public class MainMenuCamerasFactoryInstaller : Installer<MainMenuCamerasFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IMainMenuCamerasFactory>()
                .To<MainMenuCamerasFactory>()
                .AsSingle();

            Container
                .BindFactory<string, UniTask<FreeLookCamera>, FreeLookCamera.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<FreeLookCamera>>();
        }
    }
}
