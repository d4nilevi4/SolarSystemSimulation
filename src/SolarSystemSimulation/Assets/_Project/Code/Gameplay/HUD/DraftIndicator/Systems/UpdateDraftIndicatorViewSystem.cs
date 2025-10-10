using SolarSystem.Common;

namespace SolarSystem.Gameplay.HUD;

public sealed class UpdateDraftIndicatorViewSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    private readonly IGroup<InputEntity> _inputs;

    public UpdateDraftIndicatorViewSystem(GameContext game, InputContext input)
    {
        _entities = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.DraftIndicatorView));
        
        _inputs = input.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.SpaceshipInput,
                InputMatcher.SpaceshipMovementInput,
                InputMatcher.WorldInput));
    }

    public void Execute()
    {
        foreach (InputEntity input in _inputs)
        foreach (GameEntity entity in _entities)
        {
            entity.DraftIndicatorView.SetDraftVector(input.hasSpaceshipMovementInputAxis
                ? input.SpaceshipMovementInputAxis.Invert()
                : Vector3.zero);
        }  
    }
}