using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Animations;

public sealed class AnimationsFeature : CustomFeature
{
    public AnimationsFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<AnimationEventsCleanupSystem>());
        Add(systemFactory.Create<AnimationStateEventsCleanupSystem>());
    }
}