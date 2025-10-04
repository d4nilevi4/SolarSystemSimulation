using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using SolarSystem.Gameplay.SolarSystem;

namespace SolarSystem.Gameplay.StaticData;

public interface IStaticDataProvider
{
    [MustUseReturnValue]
    UniTask LoadAll();
    
    SolarSystemObjectConfig GetSolarSystemObjectConfig(SolarSystemObjectTypeId id);
}