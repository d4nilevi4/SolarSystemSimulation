using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Spaceship;

public sealed class SpaceshipMovementFeature : CustomFeature
{
    public SpaceshipMovementFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<CalculateVelocitySystem>());
        Add(systemFactory.Create<CalculateCameraRelativeVelocitySystem>());
        Add(systemFactory.Create<ApplyVelocitySystem>());
        Add(systemFactory.Create<SynchronizeTransformPositionSystem>());
        
    }
}