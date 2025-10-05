namespace SolarSystem.Gameplay.Spaceship;

public sealed class ApplyVelocitySystem : IExecuteSystem
{
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _spaceships;

    public ApplyVelocitySystem(GameContext game, ITimeService timeService)
    {
        _timeService = timeService;
        _spaceships = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Spaceship,
                GameMatcher.Velocity,
                GameMatcher.WorldPosition));
    }

    public void Execute()
    {
        foreach (GameEntity spaceship in _spaceships)
        {
            Vector3 deltaPosition = spaceship.Velocity * _timeService.DeltaTime;
            spaceship.ReplaceWorldPosition(spaceship.WorldPosition + deltaPosition);
        }
    }
}