namespace RaseTheSun.Scripts.UI.MainMenu
{
    public class WindowOpenButton : WindowInteractionButton
    {
        protected override void Interact() =>
            OpenableWindow.Open();
    }
}
