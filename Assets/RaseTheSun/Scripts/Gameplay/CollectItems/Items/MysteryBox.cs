using RaseTheSun.Scripts.Gameplay.CollectItems.ItemVisitor;
using UnityEngine;

namespace RaseTheSun.Scripts.Gameplay.CollectItems.Items
{
    public class MysteryBox : MonoBehaviour, IItem
    {
        [SerializeField] private Color _destroyEffectColor;

        public Color DestroyEffectColor => _destroyEffectColor;

        public void Accept(IItemVisitor visitor) =>
            visitor.Visit(this);
    }
}