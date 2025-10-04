namespace SolarSystem.Infrastructure
{
    public class InfrastructureInitializer : MonoBehaviour
    {
        private DiContainer _container;
        private ISceneContainerProvider _sceneContainerProvider;

        [Inject]
        private void Construct(
            DiContainer container,
            ISceneContainerProvider sceneContainerProvider
        )
        {
            _sceneContainerProvider = sceneContainerProvider;
            _container = container;
        }

        private void Awake()
        {
            _sceneContainerProvider.SetContainer(_container);
        }
    }
}