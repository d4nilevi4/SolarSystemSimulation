namespace SolarSystem.Infrastructure
{
    public class SystemFactory : ISystemFactory
    {
        private readonly ISceneContainerProvider _sceneContextProvider;

        private DiContainer Container => _sceneContextProvider.Container;
        
        public SystemFactory(ISceneContainerProvider sceneContextProvider)
        {
            _sceneContextProvider = sceneContextProvider;
        }

        public T Create<T>() where T : ISystem =>
            Container.Instantiate<T>();

        public T Create<T>(params object[] args) where T : ISystem =>
            Container.Instantiate<T>(args);
    }
}