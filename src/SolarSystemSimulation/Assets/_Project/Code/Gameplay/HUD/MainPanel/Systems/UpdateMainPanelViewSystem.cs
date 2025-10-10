namespace SolarSystem.Gameplay.HUD;

public sealed class UpdateMainPanelViewSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public UpdateMainPanelViewSystem(GameContext contextParameter)
    {
        _entities = contextParameter.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.MainPanelView,
                GameMatcher.CameraRelativeVelocity));
    }

    public void Execute()
    {
        foreach (GameEntity entity in _entities)
        {
            entity.MainPanelView.SetSpeed(entity.CameraRelativeVelocity.magnitude);
            entity.MainPanelView.SetVelocity(entity.CameraRelativeVelocity);
        }
    }
}