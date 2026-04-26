using Cysharp.Threading.Tasks;
using UnityEngine;

namespace RaseTheSun.Scripts.Infrastructure.Factories.MainMenuFactory
{
    public interface IMainMenuFactory
    {
        UniTask CreateMainMenu();
        UniTask CreateModelSpawner(Vector3 position);
        UniTask CreateTrailPoint(Vector3 position);
    }
}