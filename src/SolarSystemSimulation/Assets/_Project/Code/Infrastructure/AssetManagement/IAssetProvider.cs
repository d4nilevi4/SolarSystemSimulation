using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure
{
    public interface IAssetProvider
    {
        UniTask<T> LoadAsset<T>(string path) where T : Object;
        UniTask<T[]> LoadAll<T>(string path) where T : Object;
    }
}