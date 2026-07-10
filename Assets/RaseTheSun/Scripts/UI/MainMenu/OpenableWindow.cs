using UnityEngine;

namespace RaseTheSun.Scripts.UI.MainMenu
{
    public abstract class OpenableWindow : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Hide();
    }
}
