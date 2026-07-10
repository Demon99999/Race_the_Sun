using RaseTheSun.Scripts.Gameplay.Spaceship;
using UnityEngine;

namespace RaseTheSun.Scripts.GameLogic.Audio
{
    public class SpeedBoostSound : MonoBehaviour
    {
        [SerializeField] private Spaceship _spaceship;
        [SerializeField] private AudioSource _audioSource;

        private void OnEnable() =>
            _spaceship.SpeedBoosted += OnSpeedBoosted;

        private void OnDisable() =>
            _spaceship.SpeedBoosted -= OnSpeedBoosted;

        private void OnSpeedBoosted() =>
            _audioSource.Play();
    }
}
