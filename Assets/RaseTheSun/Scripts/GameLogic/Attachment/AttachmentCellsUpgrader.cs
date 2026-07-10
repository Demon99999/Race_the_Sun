using RaseTheSun.Scripts.Data;
using RaseTheSun.Scripts.Services.PersistentProgress;

namespace RaseTheSun.Scripts.GameLogic.Attachment
{
    public class AttachmentCellsUpgrader
    {
        private readonly IPersistentProgressService _persistentProgressService;

        public AttachmentCellsUpgrader(IPersistentProgressService persistentProgressService) =>
            _persistentProgressService = persistentProgressService;

        public void TryUpgrade(int stageNumber)
        {
            UpgradingData upgradingData = _persistentProgressService.Progress.Upgrading;

            switch (stageNumber)
            {
                case 2:
                    upgradingData.Upgrade(UpgradeType.FirstAttachmentCell);
                    break;
                case 3:
                    upgradingData.Upgrade(UpgradeType.SecondAttachmentCell);
                    break;
                case 4:
                    upgradingData.Upgrade(UpgradeType.ThirdAttachmentCell);
                    break;
            }
        }
    }
}
