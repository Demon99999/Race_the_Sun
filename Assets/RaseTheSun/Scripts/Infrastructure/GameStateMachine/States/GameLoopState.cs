using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using RaseTheSun.Scripts.Infrastructure.SceneManagement;
using RaseTheSun.Scripts.Services.SaveLoad;
using RaseTheSun.Scripts.UI.LoadingCurtain;

namespace RaseTheSun.Scripts.Infrastructure.GameStateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly ILoadingCurtain _loadingCurtainProxy;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly ISaveLoadService _saveLoadService;

        public GameLoopState(
            ILoadingCurtain loadingCurtainProxy,
            ISceneLoader sceneLoader,
            IAssetProvider assetProvider,
            ISaveLoadService saveLoadService)
        {
            _loadingCurtainProxy = loadingCurtainProxy;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _saveLoadService = saveLoadService;
        }

        public async UniTask Enter()
        {
            _loadingCurtainProxy.Show();

            await _sceneLoader.Load(InfrasructureAssetPath.GameplayScene);
        }

        public UniTask Exit()
        {
            _assetProvider.CleanUp();
            _saveLoadService.SaveProgress();
            return default;
        }
    }
}
