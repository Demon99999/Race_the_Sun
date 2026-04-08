using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Data;
using RaseTheSun.Scripts.Services.PersistentProgress;
using RaseTheSun.Scripts.Services.SaveLoad;
using RaseTheSun.Scripts.Services.StaticDataService;

namespace RaseTheSun.Scripts.Infrastructure.GameStateMachine.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStaticDataService _staticDataService;
        
        public LoadProgressState(
            GameStateMachine stateMachine,
            IPersistentProgressService persistentProgressService,
            ISaveLoadService saveLoadService,
            IStaticDataService staticDataService)
        {
            _gameStateMachine = stateMachine;
            _persistentProgressService = persistentProgressService;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;
        }
        
        public UniTask Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<MainMenuState>().Forget();

            return default;
        }
        
        public UniTask Exit()
        {
            return default;
        }
        
        private void LoadProgressOrInitNew() =>
            _persistentProgressService.Progress = _saveLoadService.LoadProgress() ?? CreateNewProgress();
        
        private PlayerProgress CreateNewProgress()
        {
            return default;
        }
    }
}