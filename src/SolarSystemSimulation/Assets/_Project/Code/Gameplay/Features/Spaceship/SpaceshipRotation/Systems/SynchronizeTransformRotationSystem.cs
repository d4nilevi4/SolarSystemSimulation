namespace SolarSystem.Gameplay.Spaceship;

public sealed class SynchronizeTransformRotationSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public SynchronizeTransformRotationSystem(GameContext game)
    {
        _entities = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.WorldRotation,
                GameMatcher.Transform));
    }

    public void Execute()
    {
        foreach (GameEntity entity in _entities)
        {
            entity.Transform.rotation = entity.WorldRotation;
        }
    }
}