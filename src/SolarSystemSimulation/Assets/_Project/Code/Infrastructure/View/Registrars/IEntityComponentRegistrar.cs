namespace SolarSystem.Infrastructure
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponents();
        void UnregisterComponents();
    }
}