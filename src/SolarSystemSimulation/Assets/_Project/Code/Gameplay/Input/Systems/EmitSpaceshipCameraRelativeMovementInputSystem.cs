using SolarSystem.Gameplay.Cameras;

namespace SolarSystem.Gameplay.Input;

public sealed class EmitSpaceshipCameraRelativeMovementInputSystem : IExecuteSystem
{
    private readonly ISpaceshipInputProvider _spaceshipInputProvider;
    private readonly ICameraProvider _cameraProvider;
    private readonly IGroup<InputEntity> _inputs;

    public EmitSpaceshipCameraRelativeMovementInputSystem(
        InputContext input,
        ISpaceshipInputProvider spaceshipInputProvider,
        ICameraProvider cameraProvider)
    {
        _spaceshipInputProvider = spaceshipInputProvider;
        _cameraProvider = cameraProvider;
        _inputs = input.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.Input,
                InputMatcher.SpaceshipInput,
                InputMatcher.SpaceshipMovementInput,
                InputMatcher.CameraRelativeInput));
    }

    public void Execute()
    {
        foreach (InputEntity input in _inputs)
        {
            if (_spaceshipInputProvider.HasSpaceshipMovementInput)
                input.ReplaceSpaceshipMovementInputAxis(
                    GetCameraRelativeInput(_spaceshipInputProvider.GetSpaceshipMovementInput()));
            else if (input.hasSpaceshipMovementInputAxis)
                input.RemoveSpaceshipMovementInputAxis();
        }
    }

    private Vector3 GetCameraRelativeInput(Vector3 input)
    {
        var camera = _cameraProvider.MainCamera;

        if (camera == null)
            return input;

        var forward = camera.transform.forward;
        var right = camera.transform.right;
        var up = camera.transform.up;

        Vector3 relativeInput = input.x * right + input.y * up + input.z * forward;
        
        return relativeInput;
    }
}