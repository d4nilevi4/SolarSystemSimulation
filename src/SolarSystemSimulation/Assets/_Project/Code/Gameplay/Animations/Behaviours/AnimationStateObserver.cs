using SolarSystem.Common;
using SolarSystem.Common.Entity;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Animations
{
    [RequireComponent(typeof(Animator))]
    public class AnimationStateObserver : MonoBehaviour
    {
        private IEntityBehaviorProvider _entityBehaviorProvider;

        private int EntityId => _entityBehaviorProvider.EntityBehaviour.Entity.Id;
        
        [Inject]
        private void Construct(IEntityBehaviorProvider entityBehaviorProvider)
        {
            _entityBehaviorProvider = entityBehaviorProvider;
        }

        public void EnteredState(int stateHash) =>
            CreateAnimationStateEvent(stateHash, EventType.Enter);

        public void ExitedState(int stateHash) =>
            CreateAnimationStateEvent(stateHash, EventType.Exit);

        public void UpdatedState(int stateHash) =>
            CreateAnimationStateEvent(stateHash, EventType.Update);

        public void AnimationEnded(int stateHash) =>
            CreateAnimationStateEvent(stateHash, EventType.End);

        private void CreateAnimationStateEvent(int stateHash, EventType eventType)
        {
            CreateEntity.Empty()
                .AddAnimationEventOwnerId(EntityId)
                .AddAnimationHash(stateHash)
                .With(x => x.isAnimationEnterState = true, when: eventType == EventType.Enter)
                .With(x => x.isAnimationExitState = true, when: eventType == EventType.Exit)
                .With(x => x.isAnimationEndState = true, when: eventType == EventType.End)
                .With(x => x.isAnimationUpdateState = true, when: eventType == EventType.Update)
                .isAnimationStateEvent = true;
        }
        
        private enum EventType
        {
            Enter,
            Exit,
            Update,
            End
        }
    }
}