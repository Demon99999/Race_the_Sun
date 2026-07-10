using Cinemachine;
using RaseTheSun.Scripts.Services.WaitingService;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.GameLogic.Cameras.Gameplay
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _amplitudeGain;
        [SerializeField] private float _frequencyGain;

        private CinemachineBasicMultiChannelPerlin _virtualCameraPerlin;
        private IWaitingService _waitingService;

        [Inject]
        private void Construct(IWaitingService waitingService)
        {
            _waitingService = waitingService;
            _virtualCameraPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void Shake()
        {
            SetShake(_amplitudeGain, _frequencyGain);

            _waitingService.Wait(_shakeDuration, callback: () => SetShake(0, 0));
        }

        private void SetShake(float amplitudeGain, float frequencyGain)
        {
            _virtualCameraPerlin.m_AmplitudeGain = amplitudeGain;
            _virtualCameraPerlin.m_FrequencyGain = frequencyGain;
        }
    }
}
