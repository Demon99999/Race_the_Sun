using RaseTheSun.Scripts.Services.StaticDataService;
using RaseTheSun.Scripts.Services.StaticDataService.Configs;
using TMPro;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.UI.MainMenu.MysteryBox
{
    public class RewardsInfoPanel : OpenableWindow
    {
        [SerializeField] public TMP_Text _minScoreItemsRewardChance;
        [SerializeField] public TMP_Text _minScoreItemsRewardMinCount;
        [SerializeField] public TMP_Text _minScoreItemsRewardMaxCount;

        [SerializeField] public TMP_Text _maxScoreItemsRewardChance;
        [SerializeField] public TMP_Text _maxScoreItemsRewardMinCount;
        [SerializeField] public TMP_Text _maxScoreItemsRewardMaxCount;

        [SerializeField] public TMP_Text _experienceRewardChance;

        [Inject]
        private void Construct(IStaticDataService staticDataService)
        {
            MysteryBoxRewardsConfig mysteryBoxRewardsConfig = staticDataService.GetMysteryBoxRewards();

            _minScoreItemsRewardChance.text = mysteryBoxRewardsConfig.MinScoreItemsRewardChance.ToString();
            _minScoreItemsRewardMinCount.text = mysteryBoxRewardsConfig.MinScoreItemsRewardMinCount.ToString();
            _minScoreItemsRewardMaxCount.text = mysteryBoxRewardsConfig.MinScoreItemsRewardMaxCount.ToString();

            _maxScoreItemsRewardChance.text = mysteryBoxRewardsConfig.MaxScoreItemsRewardChance.ToString();
            _maxScoreItemsRewardMinCount.text = mysteryBoxRewardsConfig.MaxScoreItemsRewardMinCount.ToString();
            _maxScoreItemsRewardMaxCount.text = mysteryBoxRewardsConfig.MaxScoreItemsRewardMaxCount.ToString();

            _experienceRewardChance.text = mysteryBoxRewardsConfig.ExperienceRewardChance.ToString();
        }

        public override void Hide() =>
            gameObject.SetActive(false);

        public override void Open() =>
            gameObject.SetActive(true);
    }
}
