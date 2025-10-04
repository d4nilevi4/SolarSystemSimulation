namespace SolarSystem.Infrastructure
{
    public class EntityInstaller : BindingsInstaller
    {
        public EntityBehaviour EntityBehavior;
        
        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<IEntityBehaviorProvider>().To<EntityBehaviorProvider>()
                .AsSingle().WithArguments(EntityBehavior);
        }
    }
}