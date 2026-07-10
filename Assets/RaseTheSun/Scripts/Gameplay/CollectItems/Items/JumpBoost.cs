using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.Gameplay.CollectItems.ItemVisitor;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay.CollectItems.Items
{
    public class JumpBoost : MonoBehaviour, IItem
    {
        [SerializeField] private Color _destroyEffectColor;

        public Color DestroyEffectColor => _destroyEffectColor;

        public void Accept(IItemVisitor visitor) =>
            visitor.Visit(this);

        public class Factory : PlaceholderFactory<string, UniTask<JumpBoost>>
        {
        }
    }
}