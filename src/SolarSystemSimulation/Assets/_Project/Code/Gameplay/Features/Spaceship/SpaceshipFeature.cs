using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Spaceship;

public sealed class SpaceshipFeature : CustomFeature
{
    public SpaceshipFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<SpaceshipMovementFeature>());
    }
}