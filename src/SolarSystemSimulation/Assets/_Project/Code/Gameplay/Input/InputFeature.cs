using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Input;

public sealed class InputFeature : CustomFeature
{
    public InputFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<InitializeSpaceshipInputSystem>());
        
        Add(systemFactory.Create<EmitSpaceshipWorldInputSystem>());
        Add(systemFactory.Create<EmitSpaceshipCameraRelativeInputSystem>());
        
        Add(systemFactory.Create<TearDownSpaceshipInputSystem>());
    }
}