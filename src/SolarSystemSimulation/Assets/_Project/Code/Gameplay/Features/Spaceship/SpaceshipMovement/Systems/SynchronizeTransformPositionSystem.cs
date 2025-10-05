namespace SolarSystem.Gameplay.Spaceship;

public sealed class SynchronizeTransformPositionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public SynchronizeTransformPositionSystem(GameContext game)
    {
        _entities = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Transform));
    }

    public void Execute()
    {
        foreach (GameEntity entity in _entities)
        {
            entity.Transform.position = entity.WorldPosition;
        }
    }
}