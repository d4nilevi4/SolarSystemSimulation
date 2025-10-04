namespace SolarSystem.Infrastructure
{
    public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnregisterComponents();
    }
}