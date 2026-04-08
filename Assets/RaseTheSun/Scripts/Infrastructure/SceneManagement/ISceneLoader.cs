using Cysharp.Threading.Tasks;

namespace RaseTheSun.Scripts.Infrastructure.SceneManagement
{
    public interface ISceneLoader
    {
        UniTask Load(string scene);
    }
}