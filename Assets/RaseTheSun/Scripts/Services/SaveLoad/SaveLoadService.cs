using RaseTheSun.Scripts.Data;
using RaseTheSun.Scripts.Services.PersistentProgress;
using RaseTheSun.Scripts.Utils;
using UnityEngine;

namespace RaseTheSun.Scripts.Services.SaveLoad
{
    internal class SaveLoadService : ISaveLoadService
    {
        private const string Key = "Progress";

        private readonly IPersistentProgressService _progressService;

        public SaveLoadService(IPersistentProgressService progressService) =>
            _progressService = progressService;

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(Key)?.ToDeserialized<PlayerProgress>();

        public void SaveProgress() =>
            PlayerPrefs.SetString(Key, _progressService.Progress.ToJson());
    }
}