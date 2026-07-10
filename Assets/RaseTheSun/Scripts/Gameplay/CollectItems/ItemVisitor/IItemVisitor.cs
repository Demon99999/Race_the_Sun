using RaseTheSun.Scripts.Gameplay.CollectItems.Items;

namespace RaseTheSun.Scripts.Gameplay.CollectItems.ItemVisitor
{
    public interface IItemVisitor
    {
        void Visit(Shield shield);
        void Visit(JumpBoost jumpBoost);
        void Visit(ScoreItem scoreItem);
        void Visit(SpeedBoost speedBoost);
        void Visit(MysteryBox mysteryBox);
    }
}