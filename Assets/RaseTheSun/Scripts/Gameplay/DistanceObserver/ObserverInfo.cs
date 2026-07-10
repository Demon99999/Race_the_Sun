using UnityEngine;

namespace RaseTheSun.Scripts.Gameplay.DistanceObserver
{
    public class ObserverInfo
    {
        public readonly IObserver Observer;
        public readonly Vector3 InvokePosition;

        public ObserverInfo(IObserver observer, Vector3 invokePosition)
        {
            Observer = observer;
            InvokePosition = invokePosition;
        }
    }
}
