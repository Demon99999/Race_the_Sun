using UnityEngine;

namespace RaseTheSun.Scripts.Gameplay.CollectItems.Effects
{
    public class CollectItemEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;

        public void Show() =>
            _effect.Play();
    }
}
