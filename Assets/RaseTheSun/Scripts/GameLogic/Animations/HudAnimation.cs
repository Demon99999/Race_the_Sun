using System.Collections.Generic;

namespace RaseTheSun.Scripts.GameLogic.Animations
{
    public class HudAnimation
    {
        private readonly List<HudAnimationElement> _hudAnimationElements;

        public HudAnimation() =>
            _hudAnimationElements = new List<HudAnimationElement>();

        public void RegisterHudAnimationElement(HudAnimationElement hudAnimationElement) =>
            _hudAnimationElements.Add(hudAnimationElement);

        public void Open() =>
            SetOpen(true);

        public void Hide() =>
            SetOpen(false);

        private void SetOpen(bool isOpened)
        {
            foreach (HudAnimationElement hudAnimationElement in _hudAnimationElements)
            {
                if (isOpened)
                    hudAnimationElement.Open();
                else
                    hudAnimationElement.Hide();
            }
        }
    }
}
