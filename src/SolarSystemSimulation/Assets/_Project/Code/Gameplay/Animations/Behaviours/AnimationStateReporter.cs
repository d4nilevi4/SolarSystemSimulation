namespace SolarSystem.Gameplay.Animations
{
    public class AnimationStateReporter : StateMachineBehaviour
    {
        private AnimationStateObserver _stateObserver;

        private int _repeatCounter;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            GetAnimatorStateObserver(animator).EnteredState(stateInfo.shortNameHash);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            GetAnimatorStateObserver(animator).ExitedState(stateInfo.shortNameHash);

            if (_repeatCounter == 0)
            {
                GetAnimatorStateObserver(animator).AnimationEnded(stateInfo.shortNameHash);
            }

            _repeatCounter = 0;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            GetAnimatorStateObserver(animator).UpdatedState(stateInfo.shortNameHash);

            if (stateInfo.normalizedTime - _repeatCounter >= 1f)
            {
                GetAnimatorStateObserver(animator).AnimationEnded(stateInfo.shortNameHash);
                _repeatCounter++;
            }
        }

        private AnimationStateObserver GetAnimatorStateObserver(Animator animator) =>
            _stateObserver ??= animator.gameObject.GetComponent<AnimationStateObserver>();
    }
}