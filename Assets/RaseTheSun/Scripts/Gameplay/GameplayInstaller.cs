using RaseTheSun.Scripts.GameLogic.Animations;
using RaseTheSun.Scripts.GameLogic.Attachment;
using RaseTheSun.Scripts.GameLogic.Cameras.Gameplay;
using RaseTheSun.Scripts.Gameplay.Counters;
using RaseTheSun.Scripts.Gameplay.DistanceObserver;
using RaseTheSun.Scripts.Gameplay.StateMachine;
using RaseTheSun.Scripts.Gameplay.WorldGenerator.StageInfo;
using RaseTheSun.Scripts.Infrastructure.Factories.CamerasFactory.Gameplay;
using RaseTheSun.Scripts.Infrastructure.Factories.GameplayFactory;
using RaseTheSun.Scripts.Infrastructure.Factories.SpaceshipModelFactory;
using Zenject;

namespace RaseTheSun.Scripts.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameplayBootstrapper();
            BindGameplayFactory();
            BindGameplayCamerasFactory();
            BindGameplayStateMachine();
            BindCounters();
            BindCurrentGenerationStage();
            BindDistanceObservable();
            BindCameras();
            BindHudAnimation();
            BindCurrentSpaceshipStage();
            SpaceshipModelFactory();
            BindAttachmentCellsUpgrader();
        }

        private void BindAttachmentCellsUpgrader()
        {
            Container
                .BindInterfacesAndSelfTo<AttachmentCellsUpgrader>()
                .AsSingle();
        }

        private void SpaceshipModelFactory() =>
            SpaceshipModelFactoryInstaller.Install(Container);

        private void BindGameplayCamerasFactory() =>
            GameplayCamerasFactoryInstaller.Install(Container);

        private void BindCurrentSpaceshipStage()
        {
            Container
                .BindInterfacesAndSelfTo<CurrentSpaceshipStage>()
                .AsSingle();
        }

        private void BindHudAnimation()
        {
            Container
                .Bind<HudAnimation>()
                .FromNew()
                .AsSingle();
        }

        private void BindCameras()
        {
            Container
                .BindInterfacesAndSelfTo<GameplayCameras>()
                .AsSingle();
        }

        private void BindDistanceObservable()
        {
            Container
                .BindInterfacesAndSelfTo<DistanceObservable>()
                .AsSingle();
        }

        private void BindCurrentGenerationStage()
        {
            Container
                .BindInterfacesAndSelfTo<CurrentGenerationStage>()
                .AsSingle();
        }

        private void BindCounters()
        {
            Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreItemsCounter>().AsSingle();
            Container.BindInterfacesAndSelfTo<MultiplierProgressCounter>().AsSingle();
        }

        private void BindGameplayStateMachine() =>
            GameplayStateMachineInstaller.Install(Container);

        private void BindGameplayFactory() =>
            GameplayFactoryInstaller.Install(Container);

        private void BindGameplayBootstrapper()
        {
            Container
                .BindInterfacesAndSelfTo<GameplayBootstrapper>()
                .AsSingle()
                .NonLazy();
        }
    }
}