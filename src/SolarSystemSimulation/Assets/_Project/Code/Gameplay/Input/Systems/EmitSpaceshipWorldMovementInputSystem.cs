namespace SolarSystem.Gameplay.Input;

public sealed class EmitSpaceshipWorldMovementInputSystem : IExecuteSystem
{
    private readonly ISpaceshipInputProvider _spaceshipInputProvider;
    private readonly IGroup<InputEntity> _inputs;

    public EmitSpaceshipWorldMovementInputSystem(InputContext input,
        ISpaceshipInputProvider spaceshipInputProvider)
    {
        _spaceshipInputProvider = spaceshipInputProvider;
        _inputs = input.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.Input,
                InputMatcher.SpaceshipInput,
                InputMatcher.SpaceshipMovementInput,
                InputMatcher.WorldInput));
    }

    public void Execute()
    {
        foreach (InputEntity input in _inputs)
        {
            if (_spaceshipInputProvider.HasSpaceshipMovementInput)
                input.ReplaceSpaceshipMovementInputAxis(_spaceshipInputProvider.GetSpaceshipMovementInput());
            else if (input.hasSpaceshipMovementInputAxis)
                input.RemoveSpaceshipMovementInputAxis();
        }
    }
}