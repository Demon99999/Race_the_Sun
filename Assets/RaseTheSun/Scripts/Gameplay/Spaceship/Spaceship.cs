using System;
using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Data;
using RaseTheSun.Scripts.GameLogic.Attachment;
using RaseTheSun.Scripts.GameLogic.Cameras.Gameplay;
using RaseTheSun.Scripts.Gameplay.Spaceship.Movement;
using RaseTheSun.Scripts.Gameplay.Spaceship.SpeedDecorator;
using RaseTheSun.Scripts.Infrastructure.Factories.GameplayFactory;
using RaseTheSun.Scripts.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay.Spaceship
{
    public class Spaceship : MonoBehaviour
    {
        private const float DefaultSpeed = 300;

        [SerializeField] private SpaceshipMovement _spaceshipMovement;
        [SerializeField] private Battery.Battery _battery;
        [SerializeField] private SpaceshipDie _spaceshipDie;
        [SerializeField] private SpaceshipTurning _spaceshipTurning;

        private BoostedSpeed _boostedSpeed;
        private CollisionSpeed _collisionSpeed;
        private ISpeedProvider _speedProvider;
        private GameplayCameras _gameplayCameras;
        private IGameplayFactory _gameplayFactory;

        [Inject]
        private void Construct(
            Attachment attachment,
            IPersistentProgressService persistentProgressService,
            GameplayCameras gameplayCameras,
            IGameplayFactory gameplayFactory)
        {
            _gameplayCameras = gameplayCameras;
            _gameplayFactory = gameplayFactory;

            AttachmentStats = GetAttachmentStats(attachment, persistentProgressService);
        }

        public event Action SpeedBoosted;

        public float Speed { get; private set; }
        public AttachmentStats AttachmentStats { get; private set; }

        private void Update()
        {
            if (_speedProvider != null)
                Speed = _speedProvider.GetSpeed();
        }

        public bool GetCollisionPerStage()
        {
            bool isCollidedPerStage = _collisionSpeed.IsCollidedPerStage;

            _collisionSpeed.Restart();

            return isCollidedPerStage;
        }

        public void BoostSpeed()
        {
            _boostedSpeed.Boost();
            SpeedBoosted?.Invoke();
        }

        public void StopBoostSpeed() =>
            _boostedSpeed.StopBoost();

        public void UpdateSpeedDecorator()
        {
            _speedProvider = new SpaceshipSpeed(DefaultSpeed);

            _collisionSpeed = new CollisionSpeed(
                _speedProvider,
                _spaceshipMovement,
                DefaultSpeed,
                _spaceshipDie,
                _gameplayCameras,
                _gameplayFactory);

            _speedProvider = _collisionSpeed;
            _boostedSpeed = new BoostedSpeed(_speedProvider, DefaultSpeed, this, _gameplayFactory.Sun);
            _speedProvider = _boostedSpeed;
            _speedProvider = new BatterySpeed(_speedProvider, _battery, _spaceshipDie, _spaceshipTurning);
        }

        private AttachmentStats GetAttachmentStats(Attachment attachment, IPersistentProgressService persistentProgressService)
        {
            SpaceshipData spaceshipData = persistentProgressService
                .Progress.AvailableSpaceships
                .GetSpaceshipData(persistentProgressService.Progress.AvailableSpaceships.CurrentSpaceshipType);

            IAttachmentStatsProvider attachmentStatsProvider = new DefaultAttachmentStats();

            foreach (UpgradeType upgradeType in spaceshipData.UpgradeTypes)
                attachmentStatsProvider = attachment.Wrap(upgradeType, attachmentStatsProvider);

            return attachmentStatsProvider.GetStats();
        }

        public class Factory : PlaceholderFactory<string, UniTask<Spaceship>>
        {
        }
    }
}
