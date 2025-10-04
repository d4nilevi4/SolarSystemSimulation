namespace SolarSystem.Infrastructure
{
    public abstract class BindingsInstaller : MonoBehaviour, IMonoInstaller
    {
        public abstract void InstallBindings(DiContainer container);
    }
}