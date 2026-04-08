using RaseTheSun.Scripts.Data;

namespace RaseTheSun.Scripts.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}