using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using RaseTheSun.Scripts.Services.StaticDataService.Configs;

namespace RaseTheSun.Scripts.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetsProvider;
        
        private GameplayWorldConfig _gameplayWorldConfig;
        
        public StaticDataService(IAssetProvider assetsProvider) =>
            _assetsProvider = assetsProvider;
        
        public async UniTask InitializeAsync()
        {
            List<UniTask> tasks = new List<UniTask>();
            
            tasks.Add(LoadGameplayWorldConfig());
            
            
            await UniTask.WhenAll(tasks);
        }
        
        public GameplayWorldConfig GetGameplayWorld() =>
            _gameplayWorldConfig;
        
        private async UniTask LoadGameplayWorldConfig()
        {
            GameplayWorldConfig[] gameplayWorldConfigs = await GetConfigs<GameplayWorldConfig>();
            _gameplayWorldConfig = gameplayWorldConfigs.First();

            //_stageConfigs = _gameplayWorldConfig.StageConfigs.ToDictionary(value => value.Stage, value => value);
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