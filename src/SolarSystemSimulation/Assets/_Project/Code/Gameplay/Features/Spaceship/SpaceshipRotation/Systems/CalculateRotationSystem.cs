using SolarSystem.Gameplay.Cameras;

namespace SolarSystem.Gameplay.Spaceship;

public sealed class CalculateRotationSystem : IExecuteSystem
{
    private readonly ITimeService _timeService;
    private readonly ICameraProvider _cameraProvider;
    private readonly IGroup<GameEntity> _spaceships;
    private readonly IGroup<InputEntity> _inputs;

    public CalculateRotationSystem(GameContext game, InputContext input, ITimeService timeService,
        ICameraProvider cameraProvider)
    {
        _timeService = timeService;
        _cameraProvider = cameraProvider;
        _spaceships = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.WorldRotation,
                GameMatcher.RotationSpeed));

        _inputs = input.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.SpaceshipInput,
                InputMatcher.SpaceshipRotationInput,
                InputMatcher.SpaceshipRotationInputAxis));
    }

    public void Execute()
    {
        foreach (InputEntity input in _inputs)
        foreach (GameEntity spaceship in _spaceships)
        {
            Vector2 inputAxis = input.SpaceshipRotationInputAxis;

            Vector3 cameraRight = _cameraProvider.MainCamera.transform.right;
            Vector3 cameraUp = _cameraProvider.MainCamera.transform.up;

            Vector3 rotationAxis =
                cameraUp * inputAxis.x +
                cameraRight * (-inputAxis.y);

            float rotationAmount = spaceship.RotationSpeed * _timeService.DeltaTime;

            Quaternion deltaRotation =
                Quaternion.AngleAxis(rotationAmount, rotationAxis.normalized);
            spaceship.ReplaceWorldRotation(deltaRotation * spaceship.WorldRotation);
        }
    }
}