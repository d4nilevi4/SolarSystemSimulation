namespace SolarSystem.Infrastructure
{
    public class EntityBehaviorProvider : IEntityBehaviorProvider
    {
        public EntityBehaviour EntityBehaviour { get; }

        public EntityBehaviorProvider(
            EntityBehaviour entityBehaviour
        )
        {
            EntityBehaviour = entityBehaviour;
        }
    }
}