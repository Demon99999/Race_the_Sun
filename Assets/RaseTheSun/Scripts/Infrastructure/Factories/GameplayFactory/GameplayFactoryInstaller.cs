using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.GameLogic.Audio;
using RaseTheSun.Scripts.Gameplay.Bird;
using RaseTheSun.Scripts.Gameplay.CollectItems.Items;
using RaseTheSun.Scripts.Gameplay.Portals;
using RaseTheSun.Scripts.Gameplay.Spaceship;
using RaseTheSun.Scripts.Gameplay.Spaceship.Collision;
using RaseTheSun.Scripts.Gameplay.Sun;
using RaseTheSun.Scripts.Gameplay.WorldGenerator;
using RaseTheSun.Scripts.Gameplay.WorldGenerator.Tiles;
using RaseTheSun.Scripts.Infrastructure.AssetManagement;
using RaseTheSun.Scripts.UI.GameOverPanel;
using RaseTheSun.Scripts.UI.Hud;
using UnityEngine.AddressableAssets;
using Zenject;

namespace RaseTheSun.Scripts.Infrastructure.Factories.GameplayFactory
{
    public class GameplayFactoryInstaller : Installer<GameplayFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGameplayFactory>()
                .To<GameplayFactory>()
                .AsSingle();

            Container
                .BindFactory<string, UniTask<Hud>, Hud.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<Hud>>();

            Container
                .BindFactory<string, UniTask<Spaceship>, Spaceship.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<Spaceship>>();

            Container
                .BindFactory<AssetReferenceGameObject, UniTask<Tile>, Tile.Factory>()
                .FromFactory<RefefencePrefabFactoryAsync<Tile>>();

            Container
                .BindFactory<string, UniTask<WorldGenerator>, WorldGenerator.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<WorldGenerator>>();

            Container
                .BindFactory<string, UniTask<Sun>, Sun.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<Sun>>();

            Container
                .BindFactory<string, UniTask<SpaceshipShieldPortal>, SpaceshipShieldPortal.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<SpaceshipShieldPortal>>();

            Container
                .BindFactory<string, UniTask<GameOverPanel>, GameOverPanel.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<GameOverPanel>>();

            Container
                .BindFactory<string, UniTask<JumpBoost>, JumpBoost.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<JumpBoost>>();

            Container
                .BindFactory<string, UniTask<Shield>, Shield.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<Shield>>();

            Container
                .BindFactory<string, UniTask<ShieldPortal>, ShieldPortal.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<ShieldPortal>>();

            Container
                .BindFactory<string, UniTask<Bird>, Bird.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<Bird>>();

            Container
                .BindFactory<string, UniTask<ScoreItem>, ScoreItem.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<ScoreItem>>();

            Container
                .BindFactory<string, UniTask<SpeedBoost>, SpeedBoost.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<SpeedBoost>>();

            Container
                .BindFactory<string, UniTask<StageMusic>, StageMusic.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<StageMusic>>();

            Container
                .BindFactory<string, UniTask<Plane>, Plane.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<Plane>>();

            Container
                .BindFactory<string, UniTask<CollectItemsSoundEffects>, CollectItemsSoundEffects.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<CollectItemsSoundEffects>>();

            Container
                .BindFactory<string, UniTask<SoundPlayer>, SoundPlayer.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<SoundPlayer>>();

            Container
                .BindFactory<string, UniTask<CollisionFx>, CollisionFx.Factory>()
                .FromFactory<KeyPrefabFactoryAsync<CollisionFx>>();
        }
    }
}
