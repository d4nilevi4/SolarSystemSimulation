namespace SolarSystem.Gameplay.Cameras;

public class CameraProvider : ICameraProvider
{
    public Camera MainCamera { get; }

    public CameraProvider(
        Camera mainCamera
    )
    {
        MainCamera = mainCamera;
    }
}