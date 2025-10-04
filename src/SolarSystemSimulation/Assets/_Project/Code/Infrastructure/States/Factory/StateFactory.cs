namespace SolarSystem.Infrastructure
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _globalContainer;
        private readonly ISceneContainerProvider _sceneContainerProvider;

        public StateFactory(
            DiContainer globalContainer,
            ISceneContainerProvider sceneContainerProvider)
        {
            _globalContainer = globalContainer;
            _sceneContainerProvider = sceneContainerProvider;
        }

        public T GetState<T>() where T : class, IExitableState
        {
            if (typeof(ILocalState).IsAssignableFrom(typeof(T)))
            {
                return _sceneContainerProvider.Container.Resolve<T>();
            }
            
            return _globalContainer.Resolve<T>();
        }
    }
}