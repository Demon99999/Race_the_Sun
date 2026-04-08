using Cysharp.Threading.Tasks;

namespace RaseTheSun.Scripts.Infrastructure.GameStateMachine
{
    public interface IState : IExitableState
    {
        UniTask Enter();
    }
}