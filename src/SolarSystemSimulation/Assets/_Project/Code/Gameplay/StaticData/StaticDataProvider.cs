using System.Linq;
using Cysharp.Threading.Tasks;
using SolarSystem.Gameplay.SolarSystem;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.StaticData;

public class StaticDataProvider : IStaticDataProvider
{
    private readonly IAssetProvider _assetProvider;

    private Dictionary<SolarSystemObjectTypeId, SolarSystemObjectConfig> _solarSystemObjectConfigs;

    public StaticDataProvider(IAssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public async UniTask LoadAll()
    {
        var loadSolarSystemObjectConfigsTask = LoadSolarSystemObjectsConfigs();

        await UniTask.WhenAll(
            loadSolarSystemObjectConfigsTask);
    }

    public SolarSystemObjectConfig GetSolarSystemObjectConfig(SolarSystemObjectTypeId id)
    {
        if (!_solarSystemObjectConfigs.TryGetValue(id, out SolarSystemObjectConfig config))
            throw new KeyNotFoundException(
                $"Solar system object configuration for id {id} not found");

        return config;
    }

    private UniTask LoadSolarSystemObjectsConfigs()
    {
        return _assetProvider
            .LoadAll<SolarSystemObjectConfig>("Gameplay/SolarSystemObjects")
            .ContinueWith(configs =>
            {
                _solarSystemObjectConfigs = configs.ToDictionary(
                    keySelector: x => x.Id, 
                    elementSelector: x => x);
            });
    }
}