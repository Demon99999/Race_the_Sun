using Assets.RaceTheSun.Sources.MainMenu.Model;
using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using RaseTheSun.Scripts.MainMenu.Model;
using Zenject;

namespace RaseTheSun.Scripts.Infrastructure.Factories.MainMenuFactory
{
    public class MainMenuFactoryInstaller : Installer<MainMenuFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IMainMenuFactory>()
                .To<RaseTheSun.Scripts.Infrastructure.Factories.MainMenuFactory.MainMenuFactory>()
                .AsSingle();

            Container
                .BindFactory<string, UniTask<RaseTheSun.Scripts.UI.MainMenu.MainMenu>, RaseTheSun.Scripts.UI.MainMenu.MainMenu.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<RaseTheSun.Scripts.UI.MainMenu.MainMenu>>();

            Container
                .BindFactory<string, UniTask<ModelSpawner>, ModelSpawner.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<ModelSpawner>>();

            Container
                .BindFactory<string, UniTask<TrailPoint>, TrailPoint.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<TrailPoint>>();
        }
    }
}