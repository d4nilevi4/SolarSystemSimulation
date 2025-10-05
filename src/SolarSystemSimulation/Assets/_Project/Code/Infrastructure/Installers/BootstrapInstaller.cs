using Cysharp.Threading.Tasks;
using SolarSystem.Common;
using SolarSystem.Gameplay;
using SolarSystem.Gameplay.Input;
using SolarSystem.Gameplay.StaticData;

namespace SolarSystem.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner,
        IDrawGizmoReceiver
    {
        public event Action EventDrawGizmo;

        public override void InstallBindings()
        {
            BindInfrastructureServices();
            BindAssetManagementServices();
            BindCommonServices();
            BindSystemFactory();
            BindContexts();
            BindStateMachine();
            BindStateFactory();
            BindGameStates();
            BindGameplayServices();
            BindGameplayFactories();

            Container.Bind<IInitializable>().FromInstance(this);
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }

        private void BindStateFactory()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLocalState>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();

            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
        }

        private void BindSystemFactory()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            Container.Bind<ISceneContainerProvider>().To<SceneContainerProvider>().AsSingle();
        }

        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IDrawGizmoReceiver>().FromInstance(this).AsSingle();
            Container.Bind<ILogger>().FromInstance(Debug.unityLogger).AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IMainInputMapProvider>().To<MainInputMapProvider>().AsSingle();
            Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle();
        }

        private void BindGameplayFactories()
        {
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
        }
        

        private void OnDrawGizmos()
        {
            EventDrawGizmo?.Invoke();
        }

        public void Initialize()
        {
            UniTaskScheduler.UnobservedTaskException += ex =>
            {
                Container
                    .Resolve<ILogger>()
                    .LogError(
                        tag: "¯\\_(ツ)_/¯",
                        message: $"Unobserved exception: {ex.Message}\n{ex.StackTrace}");
            };
        }
    }
}