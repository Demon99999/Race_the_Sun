using System;
using System.Collections.Generic;
using RaseTheSun.Scripts.GameLogic.Trail;

namespace RaseTheSun.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public Wallet Wallet;
        public AvailableStatsToUpgrade AvailableStatsToUpgrade;
        public AvailableSpaceships AvailableSpaceships;
        public UpgradingData Upgrading;
        public LevelProgress LevelProgress;
        public SpaceshipMainCameraSettings SpaceshipMainCameraSettings;
        public AvailableTrails AvailableTrails;
        public MysteryBoxesData MysteryBoxes;
        public AudioSettings AudioSettings;
        public int HighScore;
        public Education Education;

        public PlayerProgress(List<SpaceshipData> spaceshipDatas, List<TrailType> trails)
        {
            Wallet = new Wallet();
            AvailableStatsToUpgrade = new AvailableStatsToUpgrade();
            AvailableSpaceships = new AvailableSpaceships(spaceshipDatas);
            Upgrading = new UpgradingData();
            LevelProgress = new LevelProgress(Upgrading);
            SpaceshipMainCameraSettings = new SpaceshipMainCameraSettings();
            AvailableTrails = new AvailableTrails(trails);
            MysteryBoxes = new MysteryBoxesData();
            AudioSettings = new AudioSettings();
            HighScore = 0;
            Education = new Education();
        }
    }
}