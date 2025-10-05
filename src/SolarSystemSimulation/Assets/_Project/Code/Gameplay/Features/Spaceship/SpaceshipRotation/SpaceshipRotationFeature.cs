using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Spaceship;

public sealed class SpaceshipRotationFeature : CustomFeature
{
    public SpaceshipRotationFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<CalculateRotationSystem>());
        Add(systemFactory.Create<SynchronizeTransformRotationSystem>());
    }
}