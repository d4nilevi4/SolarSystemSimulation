using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure;

/// <summary>
/// Local enter states can not implement other interfaces because they will not bind in container
/// </summary>
public abstract class LocalEnterState : ILocalState
{
    public abstract UniTask Enter();

    public abstract UniTask Exit();
}