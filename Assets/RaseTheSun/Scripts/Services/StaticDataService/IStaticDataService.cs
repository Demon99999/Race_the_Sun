using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Data;
using RaseTheSun.Scripts.GameLogic.Trail;
using RaseTheSun.Scripts.Services.StaticDataService.Configs;

namespace RaseTheSun.Scripts.Services.StaticDataService
{
    public interface IStaticDataService
    {
        UniTask InitializeAsync();
        StageConfig GetStage(Stage stage);
        SpaceshipConfig GetSpaceship(SpaceshipType type);
        SpaceshipConfig[] GetSpaceships();
        GameplayWorldConfig GetGameplayWorld();
        TrailConfig GetTrail(TrailType type);
        TrailConfig[] GetTrails();
        MysteryBoxRewardsConfig GetMysteryBoxRewards();
        AttachmentConfig GetAttachment(UpgradeType type);
        LevelUnclockInfoConfig GetLevelUnlockInfo(int level);
    }
}