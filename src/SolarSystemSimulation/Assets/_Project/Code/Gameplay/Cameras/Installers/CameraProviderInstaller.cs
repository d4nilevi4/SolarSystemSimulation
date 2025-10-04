using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Cameras
{
    public class CameraProviderInstaller : BindingsInstaller
    {
        public Camera MainCamera;

        public override void InstallBindings(DiContainer container)
        {
            container.Bind<ICameraProvider>().To<CameraProvider>()
                .AsSingle().WithArguments(MainCamera);
        }
    }
}