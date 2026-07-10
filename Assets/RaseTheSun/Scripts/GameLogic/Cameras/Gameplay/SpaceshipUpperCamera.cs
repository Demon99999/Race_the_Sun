using RaseTheSun.Scripts.Gameplay.Spaceship;
using Zenject;

namespace RaseTheSun.Scripts.GameLogic.Cameras.Gameplay
{
    public class SpaceshipUpperCamera : VirtualCamera
    {
        [Inject]
        private void Construct(Spaceship spaceship)
        {
            CinemachineVirtualCamera.Follow = spaceship.transform;
            CinemachineVirtualCamera.LookAt = spaceship.transform;
        }
    }
}
