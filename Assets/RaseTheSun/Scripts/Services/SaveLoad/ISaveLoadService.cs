using RaseTheSun.Scripts.Data;

namespace RaseTheSun.Scripts.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}