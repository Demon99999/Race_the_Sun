using System;

namespace RaseTheSun.Scripts.UI.LoadingCurtain
{
    public interface ILoadingCurtain
    {
        void Show(float duration = 0, Action callback = null);
        void Hide(float duration = 0, Action callback = null);
    }
}