using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace SolarSystem.Infrastructure
{
    public interface IExitableState
    {
        [MustUseReturnValue]
        UniTask Exit();
    }
}