namespace SolarSystem.Infrastructure;

public class SceneContainerProvider : ISceneContainerProvider
{
    public DiContainer Container { get; private set; }
    
    public void SetContainer(DiContainer container)
    {
        Container = container;
    }
}