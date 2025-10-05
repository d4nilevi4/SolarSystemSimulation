using SolarSystem.Common;
using SolarSystem.Common.Entity;

namespace SolarSystem.Gameplay.Input;

public class InitializeSpaceshipInputSystem : IInitializeSystem
{
    private readonly ISpaceshipInputProvider _spaceshipInputProvider;

    public InitializeSpaceshipInputSystem(
        ISpaceshipInputProvider spaceshipInputProvider
    )
    {
        _spaceshipInputProvider = spaceshipInputProvider;
    }
    
    public void Initialize()
    {
        _spaceshipInputProvider.Enable();

        CreateInputEntity.Empty()
            .With(x => x.isInput = true)
            .With(x => x.isSpaceshipInput = true)
            .With(x => x.isSpaceshipMovementInput = true)
            .With(x => x.isWorldInput = true);
        
        CreateInputEntity.Empty()
            .With(x => x.isInput = true)
            .With(x => x.isSpaceshipInput = true)
            .With(x => x.isSpaceshipMovementInput = true)
            .With(x => x.isCameraRelativeInput = true);
        
        CreateInputEntity.Empty()
            .With(x => x.isInput = true)
            .With(x => x.isSpaceshipInput = true)
            .With(x => x.isSpaceshipRotationInput = true);
    }
}