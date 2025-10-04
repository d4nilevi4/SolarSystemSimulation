using SolarSystem.Common;

namespace SolarSystem.Infrastructure
{
    public sealed class BindViewFeature : CustomFeature
    {
        public BindViewFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindEntityFromPathSystem>());
            Add(systemFactory.Create<BindEntityViewFromPrefab>());
        }
    }
}