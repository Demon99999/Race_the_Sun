using RaseTheSun.Scripts.Gameplay.Spaceship.Movement;
using UnityEngine;

namespace RaseTheSun.Scripts.GameLogic.Audio
{
    public class JumpSound : MonoBehaviour
    {
        [SerializeField] private SpaceshipJump _spaceshipJump;
        [SerializeField] private AudioSource _audioSource;

        private void OnEnable() =>
            _spaceshipJump.Jumped += OnJumped;

        private void OnDisable() =>
            _spaceshipJump.Jumped -= OnJumped;

        private void OnJumped() =>
            _audioSource.Play();
    }
}
