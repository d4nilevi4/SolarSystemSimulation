namespace SolarSystem.Gameplay.Input;

public sealed class EmitSpaceshipRotationInputSystem : IExecuteSystem
{
    private readonly ISpaceshipInputProvider _spaceshipInputProvider;
    private readonly IGroup<InputEntity> _inputs;

    public EmitSpaceshipRotationInputSystem(InputContext input,
        ISpaceshipInputProvider spaceshipInputProvider)
    {
        _spaceshipInputProvider = spaceshipInputProvider;
        _inputs = input.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.Input,
                InputMatcher.SpaceshipInput,
                InputMatcher.SpaceshipRotationInput));
    }

    public void Execute()
    {
        foreach (InputEntity input in _inputs)
        {
            if (_spaceshipInputProvider.HasSpaceshipRotationInput)
                input.ReplaceSpaceshipRotationInputAxis(_spaceshipInputProvider.GetSpaceshipRotationInput());
            else if (input.hasSpaceshipRotationInputAxis)
                input.RemoveSpaceshipRotationInputAxis();
        }
    }
}