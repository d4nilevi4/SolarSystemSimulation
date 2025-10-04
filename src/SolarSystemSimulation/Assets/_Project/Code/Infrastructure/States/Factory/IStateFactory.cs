namespace SolarSystem.Infrastructure
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IExitableState;
    }
}