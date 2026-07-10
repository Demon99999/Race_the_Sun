using RaseTheSun.Scripts.GameLogic.Audio;
using RaseTheSun.Scripts.Gameplay.CollectItems.Effects;
using RaseTheSun.Scripts.Gameplay.Counters;
using RaseTheSun.Scripts.Gameplay.Spaceship;
using RaseTheSun.Scripts.Gameplay.Spaceship.Movement;
using RaseTheSun.Scripts.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay.CollectItems.ItemVisitor
{
    public partial class CollectItems : MonoBehaviour
    {
        private readonly Collider[] _overlapColliders = new Collider[128];

        [SerializeField] private Spaceship.Spaceship _spaceship;
        [SerializeField] private SpaceshipDie _spaceshipDie;
        [SerializeField] private SpaceshipJump _spaceshipJump;
        [SerializeField] private CollectItemEffect _collectItemEffect;
        [SerializeField] private ParticleSystem _destroyItemEffectPrefab;

        private float _collectRadius;
        private IPersistentProgressService _persistentProgressService;
        private IItemVisitor _itemVisitor;

        [Inject]
        private void Construct(
            ScoreItemsCounter scoreItemsCounter,
            IPersistentProgressService persistentProgressService,
            CollectItemsSoundEffects collectItemsSoundEffects)
        {
            _persistentProgressService = persistentProgressService;

            _itemVisitor = new ItemVisitor(
                    _spaceship,
                    _spaceshipDie,
                    _spaceshipJump,
                    scoreItemsCounter,
                    persistentProgressService,
                    collectItemsSoundEffects);
        }

        private void Start()
        {
            _collectRadius = _persistentProgressService
                .Progress
                .AvailableSpaceships
                .GetCurrentSpaceshipData()
                .PickUpRange
                .Value + _spaceship.AttachmentStats.CollectRadius;
        }

        private void Update()
        {
            int overlapCount = Physics.OverlapSphereNonAlloc(transform.position, _collectRadius, _overlapColliders);

            for (int i = 0; i < overlapCount; i++)
            {
                if (_overlapColliders[i].TryGetComponent(out IItem item))
                {
                    TakeItem(item);
                    Instantiate(_destroyItemEffectPrefab, _overlapColliders[i].transform.position, Quaternion.identity).GetComponent<DestroyItemEffect>().SetColor(item.DestroyEffectColor);
                    _collectItemEffect.Show();
                    Destroy(_overlapColliders[i].gameObject);
                }
            }
        }

        private void OnDrawGizmos() =>
            Gizmos.DrawWireSphere(transform.position, _collectRadius);

        private void TakeItem(IItem item) =>
            item.Accept(_itemVisitor);
    }
}
