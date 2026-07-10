using System;

namespace RaseTheSun.Scripts.Data
{
    [Serializable]
    public class SpaceshipMainCameraSettings
    {
        public bool IsFromThirdPerson;

        public SpaceshipMainCameraSettings() =>
            IsFromThirdPerson = true;

        public event Action Changed;

        public void Change(bool isFromThirdPerson)
        {
            IsFromThirdPerson = isFromThirdPerson;
            Changed?.Invoke();
        }
    }
}