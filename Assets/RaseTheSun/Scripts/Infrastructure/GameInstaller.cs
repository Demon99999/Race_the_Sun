using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using RaseTheSun.Scripts.Infrastructure.GameStateMachine;
using RaseTheSun.Scripts.Infrastructure.SceneManagement;
using RaseTheSun.Scripts.Services.CoroutineRunner;
using RaseTheSun.Scripts.Services.PersistentProgress;
using RaseTheSun.Scripts.Services.SaveLoad;
using RaseTheSun.Scripts.Services.StaticDataService;
using RaseTheSun.Scripts.UI.LoadingCurtain;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace RaseTheSun.Scripts.Infrastructure
{
    public class GameInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private AudioMixer _audioMixer;

        public override void InstallBindings()
        {
           BindGameStateMachine();
           BindLoadingCurtain();
           BindAssetProvider();
           BindSceneLoader();
           
           BindStaticDataService();
           BindSaveLoadService();
           BindPersistentProgressService();
           
           BindCoroutineRunner();
           
        }

        private void BindGameStateMachine()
        {
            GameStateMachineInstaller.Install(Container);
        }
        
        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(this)
                .AsSingle();
        }
        
        private void BindPersistentProgressService()
        {
            Container
                .BindInterfacesAndSelfTo<PersistentProgressService>()
                .AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container
                .BindInterfacesAndSelfTo<SaveLoadService>()
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            Container
                .BindInterfacesAndSelfTo<StaticDataService>()
                .AsSingle();
        }
        
        private void BindSceneLoader()
        {
            Container
                .BindInterfacesTo<SceneLoader>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container
                .BindInterfacesTo<AssetProvider>()
                .AsSingle();
        }

        private void BindLoadingCurtain()
        {
            Container
                .BindFactory<string, UniTask<LoadingCurtain>, LoadingCurtain.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<LoadingCurtain>>();

            Container
                .BindInterfacesAndSelfTo<LoadingCurtainProxy>()
                .AsSingle();
        }
    }
}
