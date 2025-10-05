using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Input
{
    public class SpaceshipInputProviderInstaller : BindingsInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            container.Bind<ISpaceshipInputProvider>().To<SpaceshipInputProvider>().AsSingle();
        }
    }
}