using Cysharp.Threading.Tasks;

namespace RaseTheSun.Scripts.Infrastructure.GameStateMachine
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}