using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.GameStateMachine;
using RaseTheSun.Scripts.Infrastructure.GameStateMachine.States;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine.GameStateMachine _gameStateMachine;
        private StatesFactory _statesFactory;

        [Inject]
        private void Construct(GameStateMachine.GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;
        }
        
        private void Start()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<BootstrapState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadProgressState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<MainMenuState>());
            //_gameStateMachine.RegisterState(_statesFactory.Create<GameLoopState>());
            
            _gameStateMachine.Enter<BootstrapState>().Forget();

            DontDestroyOnLoad(this);
        }
    }
}