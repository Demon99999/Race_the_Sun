using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using RaseTheSun.Scripts.Services.CoroutineRunner;
using RaseTheSun.Scripts.Services.StaticDataService;
using RaseTheSun.Scripts.UI.LoadingCurtain;

namespace RaseTheSun.Scripts.Infrastructure.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LoadingCurtainProxy _loadingCurtainProxy;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine stateMachine,
            LoadingCurtainProxy loadingCurtainProxy,
            IAssetProvider assetProvider,
            IStaticDataService staticDataService,
            ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _loadingCurtainProxy = loadingCurtainProxy;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
            _coroutineRunner = coroutineRunner;
        }

        public async UniTask Enter()
        {
            await InitServices();
            
            _stateMachine.Enter<LoadProgressState>().Forget();
        }
        
        public UniTask Exit()
        {
            return default;
        }
        
        private async UniTask InitServices()
        {
            await _assetProvider.InitializeAsync();
            await _loadingCurtainProxy.InitializeAsync();
            await _staticDataService.InitializeAsync();
        }
    }
}