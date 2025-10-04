using SolarSystem.Common.Entity;

namespace SolarSystem.Infrastructure
{
    public class SelfInitializedEntityView : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;
        
        private IIdentifierService _identifierService;

        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        private void Awake()
        {
            GameEntity entity = CreateEntity.Empty()
                .AddId(_identifierService.Next());

            EntityBehaviour.SetEntity(entity);
        }
    }
}