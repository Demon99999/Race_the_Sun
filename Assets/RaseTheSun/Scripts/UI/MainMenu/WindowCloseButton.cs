namespace RaseTheSun.Scripts.UI.MainMenu
{
    public class WindowCloseButton : WindowInteractionButton
    {
        protected override void Interact() =>
            OpenableWindow.Hide();
    }
}
