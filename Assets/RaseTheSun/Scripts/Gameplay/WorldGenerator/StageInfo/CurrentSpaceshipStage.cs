using System;
using RaseTheSun.Scripts.Services.StaticDataService.Configs;

namespace RaseTheSun.Scripts.Gameplay.WorldGenerator.StageInfo
{
    public class CurrentSpaceshipStage
    {
        public event Action<Stage> StageChanged;

        public void SetCurrentStage(Stage stage) =>
            StageChanged?.Invoke(stage);
    }
}
