using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using RaseTheSun.Scripts.Infrastructure.SceneManagement;
using RaseTheSun.Scripts.Services.SaveLoad;
using RaseTheSun.Scripts.UI.LoadingCurtain;

namespace RaseTheSun.Scripts.Infrastructure.GameStateMachine.States
{
    public class MainMenuState : IState
    {
        private readonly ILoadingCurtain _loadingCurtainProxy;
        private readonly ISceneLoader _sceneLoader;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IAssetProvider _assetProvider;

        public MainMenuState(
            ILoadingCurtain loadingCurtainProxy,
            ISceneLoader sceneLoader,
            ISaveLoadService saveLoadService,
            IAssetProvider assetProvider)
        {
            _loadingCurtainProxy = loadingCurtainProxy;
            _sceneLoader = sceneLoader;
            _saveLoadService = saveLoadService;
            _assetProvider = assetProvider;
        }
        
        public async UniTask Enter()
        {
            _loadingCurtainProxy.Show();

            await _sceneLoader.Load(InfrasructureAssetPath.MainMenuScene);
        }
        
        public UniTask Exit()
        {
            _assetProvider.CleanUp();
            _saveLoadService.SaveProgress();
            return default;
        }
    }
}