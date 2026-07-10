using RaseTheSun.Scripts.GameLogic.Audio;
using RaseTheSun.Scripts.Gameplay.Spaceship.Movement;
using RaseTheSun.Scripts.Gameplay.WorldGenerator.StageInfo;
using RaseTheSun.Scripts.Infrastructure.Factories.GameplayFactory;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay.Portals
{
    public class FinishStagePortal : MonoBehaviour
    {
        private CurrentGenerationStage _currentGenerationStage;
        private WorldGenerator.WorldGenerator _worldGenerator;

        [Inject(Id = GameplayFactoryInjectId.PortalSound)]
        private SoundPlayer _portalSound;

        [Inject]
        private void Construct(CurrentGenerationStage currentGenerationStage, WorldGenerator.WorldGenerator worldGenerator)
        {
            _currentGenerationStage = currentGenerationStage;
            _worldGenerator = worldGenerator;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Spaceship.Spaceship _))
            {
                _portalSound.Play();
                other.GetComponentInChildren<CutSceneMovement>().MoveStart();
                _worldGenerator.Clean();
                _currentGenerationStage.FinishStage();
            }
        }
    }
}
