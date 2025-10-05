namespace SolarSystem.Gameplay.Input;

public class TearDownSpaceshipInputSystem : ITearDownSystem
{
    private readonly ISpaceshipInputProvider _spaceshipInputProvider;

    public TearDownSpaceshipInputSystem(
        ISpaceshipInputProvider spaceshipInputProvider
    )
    {
        _spaceshipInputProvider = spaceshipInputProvider;
    }
    
    public void TearDown()
    {
        _spaceshipInputProvider.Disable();
    }
}