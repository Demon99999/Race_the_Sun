using RaseTheSun.Scripts.GameLogic.Audio;
using RaseTheSun.Scripts.Gameplay.CollectItems.Items;
using RaseTheSun.Scripts.Gameplay.Counters;
using RaseTheSun.Scripts.Gameplay.Spaceship;
using RaseTheSun.Scripts.Gameplay.Spaceship.Movement;
using RaseTheSun.Scripts.Services.PersistentProgress;

namespace RaseTheSun.Scripts.Gameplay.CollectItems.ItemVisitor
{
    public partial class CollectItems
    {
        private class ItemVisitor : IItemVisitor
        {
            private readonly Spaceship.Spaceship _spaceship;
            private readonly SpaceshipDie _spaceshipDie;
            private readonly SpaceshipJump _spaceshipJump;
            private readonly ScoreItemsCounter _scoreItemsCounter;
            private readonly IPersistentProgressService _persistentProgressService;
            private readonly CollectItemsSoundEffects _collectItemsSoundEffects;

            public ItemVisitor(Spaceship.Spaceship spaceship, SpaceshipDie spaceshipDie, SpaceshipJump spaceshipJump, ScoreItemsCounter scoreItemsCounter, IPersistentProgressService persistentProgressService, CollectItemsSoundEffects collectItemsSoundEffects)
            {
                _spaceship = spaceship;
                _spaceshipDie = spaceshipDie;
                _spaceshipJump = spaceshipJump;
                _scoreItemsCounter = scoreItemsCounter;
                _persistentProgressService = persistentProgressService;
                _collectItemsSoundEffects = collectItemsSoundEffects;
            }

            public void Visit(Shield shield)
            {
                _spaceshipDie.GiveShield();
                _collectItemsSoundEffects.TakeItem();
            }

            public void Visit(JumpBoost jumpBoost)
            {
                _spaceshipJump.GiveJumpBoost();
                _collectItemsSoundEffects.TakeItem();
            }

            public void Visit(ScoreItem scoreItem)
            {
                _scoreItemsCounter.Give();
                _collectItemsSoundEffects.TakeScoreItem();
            }

            public void Visit(SpeedBoost speedBoost) =>
                _spaceship.BoostSpeed();

            public void Visit(MysteryBox mysteryBox)
            {
                _persistentProgressService.Progress.MysteryBoxes.Give();
                _collectItemsSoundEffects.TakeItem();
            }
        }
    }
}