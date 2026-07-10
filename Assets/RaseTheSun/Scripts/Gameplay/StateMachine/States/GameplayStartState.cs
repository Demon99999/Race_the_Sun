using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Gameplay.Spaceship.Movement;
using RaseTheSun.Scripts.Infrastructure.GameStateMachine;
using RaseTheSun.Scripts.Services.StaticDataService;
using RaseTheSun.Scripts.Services.StaticDataService.Configs;
using RaseTheSun.Scripts.UI.LoadingCurtain;

namespace RaseTheSun.Scripts.Gameplay.StateMachine.States
{
    public class GameplayStartState : IState
    {
        private const float HideCurtainDuration = 0.6f;

        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly Spaceship.Spaceship _spaceship;
        private readonly CutSceneMovement _startMovement;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly Sun.Sun _sun;

        public GameplayStartState(
            GameplayStateMachine gameplayStateMachine,
            IStaticDataService staticDataService,
            Spaceship.Spaceship spaceship,
            ILoadingCurtain loadingCurtain,
            Sun.Sun sun)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _staticDataService = staticDataService;
            _spaceship = spaceship;
            _startMovement = _spaceship.GetComponentInChildren<CutSceneMovement>();
            _loadingCurtain = loadingCurtain;
            _sun = sun;
        }

        public UniTask Enter()
        {
            _loadingCurtain.Hide(HideCurtainDuration);

            StageConfig stageConfig = _staticDataService.GetStage(Stage.StartStage);

            _startMovement.MoveStart(() =>
            {
                _gameplayStateMachine.Enter<GameplayLoopState>().Forget();
            });

            _sun.Show();

            return default;
        }

        public UniTask Exit() =>
            default;
    }
}
