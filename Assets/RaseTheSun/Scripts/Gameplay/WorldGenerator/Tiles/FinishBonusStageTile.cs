using RaseTheSun.Scripts.Gameplay.DistanceObserver;
using RaseTheSun.Scripts.Gameplay.Spaceship;
using RaseTheSun.Scripts.Gameplay.Spaceship.Movement;
using RaseTheSun.Scripts.Gameplay.Sun;
using RaseTheSun.Scripts.Gameplay.WorldGenerator.StageInfo;
using RaseTheSun.Scripts.UI.LoadingCurtain;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay.WorldGenerator.Tiles
{
    public class FinishBonusStageTile : Tile, IObserver
    {
        private const float ShowCurtainDuration = 0.2f;
        private const float HideCurtainDuration = 0.8f;

        private DistanceObservable _distanceObservable;
        private CurrentGenerationStage _currentGenerationStage;
        private RaseTheSun.Scripts.Gameplay.WorldGenerator.WorldGenerator _worldGenerator;
        private ILoadingCurtain _loadingCurtain;
        private Sun.Sun _sun;
        private SkyboxSettingsChanger _skyboxSettingsChanger;
        private Plane _plane;
        private CutSceneMovement _cutSceneMovement;

        [Inject]
        private void Construct(
            DistanceObservable distanceObservable,
            CurrentGenerationStage currentGenerationStage,
            RaseTheSun.Scripts.Gameplay.WorldGenerator.WorldGenerator worldGenerator,
            ILoadingCurtain loadingCurtain,
            Sun.Sun sun,
            SkyboxSettingsChanger skyboxSettingsChanger,
            Plane plane,
            CutSceneMovement cutSceneMovement)
        {
            _distanceObservable = distanceObservable;
            _currentGenerationStage = currentGenerationStage;
            _worldGenerator = worldGenerator;
            _loadingCurtain = loadingCurtain;
            _sun = sun;
            _skyboxSettingsChanger = skyboxSettingsChanger;
            _plane = plane;
            _cutSceneMovement = cutSceneMovement;
        }

        private void Start() =>
            _distanceObservable.RegisterObserver(this, transform.position);

        public void Invoke()
        {
            _loadingCurtain.Show(ShowCurtainDuration, callback: () => _loadingCurtain.Hide(HideCurtainDuration));
            _sun.Restart();
            _skyboxSettingsChanger.Reset();
            _plane.gameObject.SetActive(true);
            _worldGenerator.Clean();
            _currentGenerationStage.EndBonusLevel();
            _cutSceneMovement.MoveStart();
        }
    }
}
