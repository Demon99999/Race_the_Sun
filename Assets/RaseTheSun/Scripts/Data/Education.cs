using System;

namespace RaseTheSun.Scripts.Data
{
    [Serializable]
    public class Education
    {
        public bool IsSpaceshipWindowShowed;
        public bool IsShopWindowShowed;

        public Education()
        {
            IsSpaceshipWindowShowed = false;
            IsShopWindowShowed = false;
        }
    }
}