using RaseTheSun.Scripts.Data;

namespace RaseTheSun.Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}