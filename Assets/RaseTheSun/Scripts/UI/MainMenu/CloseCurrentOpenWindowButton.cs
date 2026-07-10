using UnityEngine;

namespace RaseTheSun.Scripts.UI.MainMenu
{
    public class CloseCurrentOpenWindowButton : WindowInteractionButton
    {
        [SerializeField] private OpenableWindow _currentWindow;

        protected override void Interact()
        {
            _currentWindow.Hide();
            OpenableWindow.Open();
        }
    }
}
