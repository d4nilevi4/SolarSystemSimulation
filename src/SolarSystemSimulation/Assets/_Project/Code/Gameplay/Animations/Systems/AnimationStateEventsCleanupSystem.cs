namespace SolarSystem.Gameplay.Animations;

public class AnimationStateEventsCleanupSystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _animationEvents;
    private readonly List<GameEntity> _buffer = new(64);

    public AnimationStateEventsCleanupSystem(GameContext game)
    {
        _animationEvents = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.AnimationStateEvent));
    }

    public void Cleanup()
    {
        foreach (GameEntity animationEvent in _animationEvents.GetEntities(_buffer))
        {
            animationEvent.Destroy();
        }
    }
}