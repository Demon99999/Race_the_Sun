using UnityEngine;

namespace RaseTheSun.Scripts.Services.TimeScale
{
    public class TimeScale : ITimeScale
    {
        public void Scale(TimeScaleType timeScaleType) =>
            Time.timeScale = (int)timeScaleType;
    }
}
