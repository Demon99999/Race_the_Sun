using RaseTheSun.Scripts.Data;
using RaseTheSun.Scripts.Services.PersistentProgress;
using RaseTheSun.Scripts.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.UI.MainMenu.Spaceships
{
    public abstract class StatInfoButton : InformationButton
    {
        [SerializeField] private SpaceshipStatPanel _statPanel;
        [SerializeField] private CurrentClickedSpaceshipInfo _currentClickedSpaceshipInfo;

        [Inject]
        private void Construct(IStaticDataService staticDataService, IPersistentProgressService persistentProgressService)
        {
            StaticDataService = staticDataService;
            PersistentProgressService = persistentProgressService;

            _statPanel.Updated += OnStatPanelUpdated;
        }

        protected IStaticDataService StaticDataService { get; private set; }
        protected IPersistentProgressService PersistentProgressService { get; private set; }
        protected SpaceshipType CurrentSpaceshipType => _currentClickedSpaceshipInfo.SpaceshipType;

        private void OnDestroy() =>
            _statPanel.Updated -= OnStatPanelUpdated;

        public override void OpenInfo()
        {
            Info.text = GetInfo();
            base.OpenInfo();
        }

        protected abstract string GetInfo();

        private void OnStatPanelUpdated() =>
            HideInfo();
    }
}