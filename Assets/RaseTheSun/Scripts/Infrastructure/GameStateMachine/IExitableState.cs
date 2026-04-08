using Cysharp.Threading.Tasks;

namespace RaseTheSun.Scripts.Infrastructure.GameStateMachine
{
    public interface IExitableState
    {
        UniTask Exit();
    }
}