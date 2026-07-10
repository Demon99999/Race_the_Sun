using RaseTheSun.Scripts.Infrastructure.GameStateMachine;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay.StateMachine
{
    public class GameplayStateMachineInstaller : Installer<GameplayStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();
            Container.Bind<GameplayStateMachine>().AsSingle();
        }
    }
}
