using SolarSystem.Common.Entity;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Animations
{
    [RequireComponent(typeof(Animator))]
    public class AnimationsCallbackReceiver : MonoBehaviour
    {
        private IEntityBehaviorProvider _entityBehaviorProvider;

        [Inject]
        private void Construct(IEntityBehaviorProvider entityBehaviorProvider)
        {
            _entityBehaviorProvider = entityBehaviorProvider;
        }
        
        public void OnAnimEvent(string eventName)
        {
            CreateEntity.Empty()
                .AddAnimationEventName(eventName)
                .AddAnimationEventOwnerId(_entityBehaviorProvider.EntityBehaviour.Entity.Id)
                .isAnimationEvent = true;
        }
    }
}