using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure
{
    public class AssetProvider : IAssetProvider
    {
        public UniTask<T> LoadAsset<T>(string path) where T : Object =>
            new(Resources.Load<T>(path));

        public UniTask<T[]> LoadAll<T>(string path) where T : Object => 
            new (Resources.LoadAll<T>(path));
    }
}