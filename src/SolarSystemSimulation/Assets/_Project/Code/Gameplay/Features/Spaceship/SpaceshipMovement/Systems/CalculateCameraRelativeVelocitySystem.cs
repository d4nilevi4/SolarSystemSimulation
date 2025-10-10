using SolarSystem.Gameplay.Cameras;

namespace SolarSystem.Gameplay.Spaceship;

public sealed class CalculateCameraRelativeVelocitySystem : IExecuteSystem
{
    private readonly ICameraProvider _cameraProvider;
    private readonly IGroup<GameEntity> _entities;

    public CalculateCameraRelativeVelocitySystem(GameContext game, ICameraProvider cameraProvider)
    {
        _cameraProvider = cameraProvider;
        _entities = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Velocity,
                GameMatcher.CameraRelativeVelocity));
    }

    public void Execute()
    {
        var forward = _cameraProvider.MainCamera.transform.forward;
        var right = _cameraProvider.MainCamera.transform.right;
        var up = _cameraProvider.MainCamera.transform.up;
        
        foreach (GameEntity entity in _entities)
        {
            
            entity.ReplaceCameraRelativeVelocity(entity.Velocity.x * right +
                                                 entity.Velocity.y * up +
                                                 entity.Velocity.z * forward);
        }
    }
}