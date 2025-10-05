using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Input;

public sealed class InputFeature : CustomFeature
{
    public InputFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<InitializeSpaceshipInputSystem>());
        
        Add(systemFactory.Create<EmitSpaceshipWorldMovementInputSystem>());
        Add(systemFactory.Create<EmitSpaceshipCameraRelativeMovementInputSystem>());
        Add(systemFactory.Create<EmitSpaceshipRotationInputSystem>());
        
        Add(systemFactory.Create<TearDownSpaceshipInputSystem>());
    }
}