using RaseTheSun.Scripts.MainMenu.Model;
using Zenject;

namespace RaseTheSun.Scripts.GameLogic.Cameras.MainMenu
{
    public class ModelPointCamera : FreeLookCamera
    {
        [Inject]
        private void Construct(ModelSpawner modelPoint)
        {
            CinemachineFreeLook.Follow = modelPoint.transform;
            CinemachineFreeLook.LookAt = modelPoint.transform;
        }
    }
}
