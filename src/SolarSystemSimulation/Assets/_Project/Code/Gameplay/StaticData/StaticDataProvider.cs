using Cysharp.Threading.Tasks;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.StaticData;

public class StaticDataProvider : IStaticDataProvider
{
    private readonly IAssetProvider _assetProvider;

    public StaticDataProvider(IAssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public UniTask LoadAll()
    {
        return UniTask.CompletedTask;
    }
}