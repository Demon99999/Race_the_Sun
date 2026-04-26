using Assets.RaceTheSun.Sources.Data;
using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.GameLogic.Trail;
using RaseTheSun.Scripts.Infrastructure.Factories.SpaceshipModelFactory;
using RaseTheSun.Scripts.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.MainMenu.Model
{
    public class ModelSpawner : MonoBehaviour
    {
        private IPersistentProgressService _persistentProgressService;
        private ISpaceshipModelFactory _spaceshipModelFactory;
        private SpaceshipModel _currentModel;

        [Inject]
        private void Construct(PersistentProgressService persistentProgressService, ISpaceshipModelFactory spaceshipModelFactory)
        {
            _persistentProgressService = persistentProgressService;
            _spaceshipModelFactory = spaceshipModelFactory;
        }

        private async void Start()
        {
            //await Change(_persistentProgressService.Progress.AvailableSpaceships.CurrentSpaceshipType);
            await Change(SpaceshipType.TheArrow);
        }

        public async UniTask Change(SpaceshipType spaceshipType)
        {
            if (_currentModel != null)
                Destroy(_currentModel.gameObject);

            _currentModel = await _spaceshipModelFactory.CreateSpaceshipModel(spaceshipType, transform.position, transform);
        }

        public void ChangeTrail(TrailType trailType)
        {
            _currentModel.GetComponentInChildren<TrailSpawner>().CreateTrails(trailType);
        }

        public class Factory : PlaceholderFactory<string, UniTask<ModelSpawner>>
        {
        }
    }
}
