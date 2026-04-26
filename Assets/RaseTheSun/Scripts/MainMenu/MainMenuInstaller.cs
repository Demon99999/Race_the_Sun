using RaseTheSun.Scripts.GameLogic.Cameras.MainMenu;
using RaseTheSun.Scripts.Infrastructure.Factories.CamerasFactory.MainMenu;
using RaseTheSun.Scripts.Infrastructure.Factories.MainMenuFactory;
using RaseTheSun.Scripts.Infrastructure.Factories.SpaceshipModelFactory;
using Zenject;

namespace RaseTheSun.Scripts.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMainMenuBootstrapper();
            BindMainMenuFactory();
            BindMainMenuCameras();
            BindSpaceshipModelFactory();
            BindMainMenuCamerasFactory();
        }

        private void BindMainMenuCamerasFactory() =>
            MainMenuCamerasFactoryInstaller.Install(Container);

        private void BindSpaceshipModelFactory() =>
            SpaceshipModelFactoryInstaller.Install(Container);

        private void BindMainMenuCameras()
        {
            Container
                .BindInterfacesAndSelfTo<MainMenuCameras>()
                .AsSingle();
        }

        private void BindMainMenuFactory() =>
            MainMenuFactoryInstaller.Install(Container);

        private void BindMainMenuBootstrapper()
        {
            Container
                .BindInterfacesAndSelfTo<MainMenuBootstrapper>()
                .AsSingle()
                .NonLazy();
        }
    }
}