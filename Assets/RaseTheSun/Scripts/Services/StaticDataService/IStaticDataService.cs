using Cysharp.Threading.Tasks;

namespace RaseTheSun.Scripts.Services.StaticDataService
{
    public interface IStaticDataService
    {
        UniTask InitializeAsync();
        
    }
}