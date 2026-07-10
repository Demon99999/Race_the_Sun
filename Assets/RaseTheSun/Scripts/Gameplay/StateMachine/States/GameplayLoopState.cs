using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.GameLogic.Animations;
using RaseTheSun.Scripts.GameLogic.Cameras.Gameplay;
using RaseTheSun.Scripts.Infrastructure.GameStateMachine;
using RaseTheSun.Scripts.Services.WaitingService;

namespace RaseTheSun.Scripts.Gameplay.StateMachine.States
{
    public class GameplayLoopState : IState
    {
        private const float HideHudDelay = 2.5f;

        private readonly HudAnimation _hudAnimation;
        private readonly IWaitingService _waitingService;
        private readonly GameplayCameras _cameras;
        private readonly Spaceship.Spaceship _spaceship;

        public GameplayLoopState(
            HudAnimation hudAnimation,
            IWaitingService waitingService,
            GameplayCameras cameras,
            Spaceship.Spaceship spaceship)
        {
            _hudAnimation = hudAnimation;
            _waitingService = waitingService;
            _cameras = cameras;
            _spaceship = spaceship;
        }

        public UniTask Enter()
        {
            _spaceship.UpdateSpeedDecorator();
            _cameras.IncludeCamera(GameplayCameraType.MainCamera);
            _waitingService.Wait(HideHudDelay, callback: _hudAnimation.Open);

            return default;
        }

        public UniTask Exit()
        {
            _hudAnimation.Hide();
            return default;
        }
    }
}
