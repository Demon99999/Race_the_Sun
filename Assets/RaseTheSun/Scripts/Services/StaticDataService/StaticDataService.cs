using System.Collections.Generic;
using System.Linq;
using Assets.RaceTheSun.Sources.Data;
using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.GameLogic.Trail;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using RaseTheSun.Scripts.Services.StaticDataService.Configs;

namespace RaseTheSun.Scripts.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetsProvider;

        private Dictionary<Stage, StageConfig> _stageConfigs;
        private Dictionary<SpaceshipType, SpaceshipConfig> _spaceshipConfigs;
        private GameplayWorldConfig _gameplayWorldConfig;
        private Dictionary<TrailType, TrailConfig> _trailConfigs;
        
        public StaticDataService(IAssetProvider assetsProvider) =>
            _assetsProvider = assetsProvider;
        
        public async UniTask InitializeAsync()
        {
            List<UniTask> tasks = new List<UniTask>();
            
            tasks.Add(LoadGameplayWorldConfig());
            tasks.Add(LoadSpaceshipConfigs());
            tasks.Add(LoadTrailConfigs());
            
            await UniTask.WhenAll(tasks);
        }
        
        public GameplayWorldConfig GetGameplayWorld() =>
            _gameplayWorldConfig;
        
        public SpaceshipConfig[] GetSpaceships() =>
            _spaceshipConfigs.Values.ToArray();
        
        public TrailConfig[] GetTrails() =>
            _trailConfigs.Values.ToArray();
        
        public TrailConfig GetTrail(TrailType type) =>
            _trailConfigs.TryGetValue(type, out TrailConfig config) ? config : null;
        
        public SpaceshipConfig GetSpaceship(SpaceshipType type) =>
            _spaceshipConfigs.TryGetValue(type, out SpaceshipConfig config) ? config : null;

        public StageConfig GetStage(Stage stage) =>
            _stageConfigs.TryGetValue(stage, out StageConfig config) ? config : null;
        
        private async UniTask LoadGameplayWorldConfig()
        {
            GameplayWorldConfig[] gameplayWorldConfigs = await GetConfigs<GameplayWorldConfig>();
            _gameplayWorldConfig = gameplayWorldConfigs.First();

            //_stageConfigs = _gameplayWorldConfig.StageConfigs.ToDictionary(value => value.Stage, value => value);
        }
        
        private async UniTask LoadSpaceshipConfigs()
        {
            SpaceshipConfig[] spaceshipConfigs = await GetConfigs<SpaceshipConfig>();
            _spaceshipConfigs = spaceshipConfigs.ToDictionary(value => value.Type, value => value);
        }
        
        private async UniTask LoadTrailConfigs()
        {
            TrailConfig[] trailConfigs = await GetConfigs<TrailConfig>();

            _trailConfigs = trailConfigs.ToDictionary(value => value.Type, value => value);
        }
        
        private async UniTask<TConfig[]> GetConfigs<TConfig>()
            where TConfig : class
        {
            List<string> keys = await GetConfigKeys<TConfig>();
            return await _assetsProvider.LoadAll<TConfig>(keys);
        }

        private async UniTask<List<string>> GetConfigKeys<TConfig>() =>
            await _assetsProvider.GetAssetsListByLabel<TConfig>(AssetLabels.Configs);
    }
}