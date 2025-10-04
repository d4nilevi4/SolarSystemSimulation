using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace SolarSystem.Infrastructure
{
    public interface ISceneLoader
    {
        [MustUseReturnValue]
        UniTask LoadSceneAsync(string name);
    }
}