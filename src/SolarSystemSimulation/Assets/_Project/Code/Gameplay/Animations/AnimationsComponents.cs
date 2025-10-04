namespace SolarSystem.Gameplay.Animations;

[Game] public class AnimatorComponent : IComponent { public Animator Value; }
[Game] public class AnimationEventOwnerId : IComponent { public int Value; }

[Game] public class AnimationEvent : IComponent { }
[Game] public class AnimationEventName : IComponent { public string Value; }

[Game] public class AnimationStateEvent : IComponent { }
[Game] public class AnimationEnterState : IComponent { }
[Game] public class AnimationEndState : IComponent { }
[Game] public class AnimationExitState : IComponent { }
[Game] public class AnimationUpdateState : IComponent { }
[Game] public class AnimationHash : IComponent { public int Value; }