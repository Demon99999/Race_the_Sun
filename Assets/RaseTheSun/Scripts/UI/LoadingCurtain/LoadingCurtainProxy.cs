using System;
using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Infrastructure;

namespace RaseTheSun.Scripts.UI.LoadingCurtain
{
    public class LoadingCurtainProxy : ILoadingCurtain
    {
        private readonly LoadingCurtain.Factory _factory;

        private ILoadingCurtain _implementation;

        public LoadingCurtainProxy(LoadingCurtain.Factory factory)
        {
            _factory = factory;
        }
        
        public async UniTask InitializeAsync() =>
            _implementation = await _factory.Create(InfrasructureAssetPath.Curtain);
        
        public void Show(float duration = 0, Action callback = null) =>
            _implementation.Show(duration, callback);

        public void Hide(float duration = 0, Action callback = null) =>
            _implementation.Hide(duration, callback);
    }
}