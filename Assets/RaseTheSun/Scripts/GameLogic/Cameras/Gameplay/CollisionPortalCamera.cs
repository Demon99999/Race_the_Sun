using RaseTheSun.Scripts.Gameplay.Portals;
using RaseTheSun.Scripts.Gameplay.Spaceship;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.GameLogic.Cameras.Gameplay
{
    public class CollisionPortalCamera : VirtualCamera
    {
        [Inject]
        private void Construct(Spaceship spaceship)
        {
            Transform target = spaceship.GetComponentInChildren<CollisionPortalPoint>().transform;

            CinemachineVirtualCamera.Follow = target;
            CinemachineVirtualCamera.LookAt = target;
        }
    }
}
