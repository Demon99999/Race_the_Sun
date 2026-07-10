using UnityEngine;

namespace RaseTheSun.Scripts.Gameplay.CollectItems.ItemVisitor
{
    public interface IItem
    {
        public Color DestroyEffectColor { get; }
        void Accept(IItemVisitor visitor);
    }
}