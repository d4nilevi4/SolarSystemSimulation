namespace SolarSystem.Gameplay.Animations;

public class AnimationEventsCleanupSystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _animationEvents;
    private readonly List<GameEntity> _buffer = new(64);

    public AnimationEventsCleanupSystem(GameContext game)
    {
        _animationEvents = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.AnimationEvent));
    }

    public void Cleanup()
    {
        foreach (GameEntity animationEvent in _animationEvents.GetEntities(_buffer))
        {
            animationEvent.Destroy();
        }
    }
}