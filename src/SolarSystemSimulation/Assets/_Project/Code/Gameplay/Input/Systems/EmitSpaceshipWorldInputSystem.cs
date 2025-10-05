namespace SolarSystem.Gameplay.Input;

public sealed class EmitSpaceshipWorldInputSystem : IExecuteSystem
{
    private readonly ISpaceshipInputProvider _spaceshipInputProvider;
    private readonly IGroup<InputEntity> _inputs;

    public EmitSpaceshipWorldInputSystem(InputContext input,
        ISpaceshipInputProvider spaceshipInputProvider)
    {
        _spaceshipInputProvider = spaceshipInputProvider;
        _inputs = input.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.Input,
                InputMatcher.SpaceShipInput,
                InputMatcher.WorldInput));
    }

    public void Execute()
    {
        foreach (InputEntity input in _inputs)
        {
            if (_spaceshipInputProvider.HasSpaceshipInput)
                input.ReplaceSpaceShipInputAxis(_spaceshipInputProvider.GetSpaceshipInput());
            else if (input.hasSpaceShipInputAxis)
                input.RemoveSpaceShipInputAxis();
        }
    }
}