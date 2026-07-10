using System;
using System.Collections;
using RaseTheSun.Scripts.Services.CoroutineRunner;
using UnityEngine;

namespace RaseTheSun.Scripts.Services.WaitingService
{
    public class WaitingService : IWaitingService
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public WaitingService(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Wait(float delay, Action callback) =>
            _coroutineRunner.StartCoroutine(Waiting(delay, callback));

        private IEnumerator Waiting(float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);

            callback.Invoke();
        }
    }
}
