using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.GameLogic.Cameras.MainMenu;

namespace RaseTheSun.Scripts.Infrastructure.Factories.CamerasFactory.MainMenu
{
    public interface IMainMenuCamerasFactory
    {
        FreeLookCamera CustomizeCamera { get; }
        FreeLookCamera MainMenuInfoCamera { get; }
        FreeLookCamera SelectionCamera { get; }
        FreeLookCamera TrailCamera { get; }

        UniTask CreateCustomizeCamera();
        UniTask CreateMainMenuMainCamera();
        UniTask CreateSelectionCamera();
        UniTask CreateTrailCamera();
    }
}