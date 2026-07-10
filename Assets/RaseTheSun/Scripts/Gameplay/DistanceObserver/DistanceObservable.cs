using System.Collections.Generic;
using RaseTheSun.Scripts.Infrastructure.Factories.GameplayFactory;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay.DistanceObserver
{
    public class DistanceObservable : ITickable
    {
        private readonly IGameplayFactory _gameplayFactory;

        private List<ObserverInfo> _observers;

        public DistanceObservable(IGameplayFactory gameplayFactory)
        {
            _gameplayFactory = gameplayFactory;
            _observers = new List<ObserverInfo>();
        }

        public void Tick()
        {
            if (_gameplayFactory.Spaceship == null)
                return;

            Vector3 spaceshipPosition = _gameplayFactory.Spaceship.transform.position;
            List<ObserverInfo> removedObservers = new List<ObserverInfo>();

            foreach (ObserverInfo info in _observers)
            {
                if (spaceshipPosition.z >= info.InvokePosition.z)
                {
                    info.Observer.Invoke();
                    removedObservers.Add(info);
                }
            }

            RemoveObservers(removedObservers);
        }

        public void RegisterObserver(IObserver observer, Vector3 invokePosition) =>
            _observers.Add(new ObserverInfo(observer, invokePosition));

        private void RemoveObservers(List<ObserverInfo> observers)
        {
            foreach (ObserverInfo removedInfos in observers)
                _observers.Remove(removedInfos);
        }
    }
}
