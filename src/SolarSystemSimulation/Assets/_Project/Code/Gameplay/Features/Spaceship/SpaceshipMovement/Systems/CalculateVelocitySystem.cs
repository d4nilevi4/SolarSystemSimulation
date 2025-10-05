namespace SolarSystem.Gameplay.Spaceship;

public sealed class CalculateVelocitySystem : IExecuteSystem
{
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _spaceships;
    private readonly IGroup<InputEntity> _inputs;

    public CalculateVelocitySystem(
        GameContext game,
        InputContext input,
        ITimeService timeService)
    {
        _timeService = timeService;
        _spaceships = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Spaceship,
                GameMatcher.Acceleration,
                GameMatcher.Velocity));
        _inputs = input.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.SpaceshipInput,
                InputMatcher.SpaceshipMovementInput,
                InputMatcher.SpaceshipMovementInputAxis,
                InputMatcher.CameraRelativeInput));
    }

    public void Execute()
    {
        foreach (InputEntity input in _inputs)
        foreach (GameEntity spaceship in _spaceships)
        {
            Vector3 deltaVelocity = (spaceship.Acceleration * _timeService.DeltaTime) *
                                    input.SpaceshipMovementInputAxis;
            spaceship.ReplaceVelocity(spaceship.Velocity + deltaVelocity);
        }
    }
}