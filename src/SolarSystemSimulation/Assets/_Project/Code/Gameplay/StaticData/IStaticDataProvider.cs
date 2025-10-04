using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace SolarSystem.Gameplay.StaticData;

public interface IStaticDataProvider
{
    [MustUseReturnValue]
    UniTask LoadAll();
}