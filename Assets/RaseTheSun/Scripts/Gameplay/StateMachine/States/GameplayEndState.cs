using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.GameStateMachine;
using RaseTheSun.Scripts.Infrastructure.GameStateMachine.States;

namespace RaseTheSun.Scripts.Gameplay.StateMachine.States
{
    public class GameplayEndState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameplayEndState(GameStateMachine gameStateMachine) =>
            _gameStateMachine = gameStateMachine;

        public UniTask Enter()
        {
            _gameStateMachine.Enter<MainMenuState>().Forget();
            return default;
        }

        public UniTask Exit() =>
            default;
    }
}
