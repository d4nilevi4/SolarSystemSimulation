namespace SolarSystem.Gameplay.Input;

public class SpaceshipInputProvider : ISpaceshipInputProvider
{
    private readonly IMainInputMapProvider _mainInputMapProvider;

    public bool HasSpaceshipInput => GetSpaceshipInput().sqrMagnitude > 0.1f;
    private PlayerInputActionsMap.SpaceshipActions Actions => _mainInputMapProvider.Map.Spaceship;

    public SpaceshipInputProvider(
        IMainInputMapProvider mainInputMapProvider
    )
    {
        _mainInputMapProvider = mainInputMapProvider;
    }

    public void Enable() =>
        Actions.Enable();

    public void Disable() =>
        Actions.Disable();

    public Vector3 GetSpaceshipInput()
    {
        Vector2 xzInput = Actions.XZMovement.ReadValue<Vector2>();
        return new Vector3(xzInput.x, Actions.UpDownMovement.ReadValue<float>(), xzInput.y);
    }
}