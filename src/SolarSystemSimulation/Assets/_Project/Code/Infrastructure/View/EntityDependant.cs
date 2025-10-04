namespace SolarSystem.Infrastructure
{
    public class EntityDependant : MonoBehaviour
    {
        public EntityBehaviour EntityView;

        public GameEntity Entity => EntityBehaviour?.Entity;

        private EntityBehaviour EntityBehaviour => EntityView ??= 
            GetComponent<EntityBehaviour>() 
            ?? GetComponent<EntityBehaviorProvider>().EntityBehaviour;
    }
}