using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace SolarSystem.Infrastructure
{
    public interface IEntityViewFactory
    {
        [MustUseReturnValue]
        UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity);
        EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    }
}