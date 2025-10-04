using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly Vector3 _farAway = new (999,999,999);

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        
        public async UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity)
        {
            EntityBehaviour viewPrefab = await _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                viewPrefab,
                position: entity.hasWorldPosition ? entity.WorldPosition : _farAway,
                rotation: Quaternion.identity,
                parentTransform: null);
            
            view.SetEntity(entity);
            
            return view;
        }

        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                entity.ViewPrefab,
                position: entity.hasWorldPosition ? entity.WorldPosition : _farAway,
                rotation: Quaternion.identity,
                parentTransform: null);
            
            view.SetEntity(entity);
            
            return view;
        }
    }
}