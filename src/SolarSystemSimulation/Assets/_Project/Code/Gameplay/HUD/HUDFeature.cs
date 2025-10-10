using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.HUD;

public sealed class HUDFeature : CustomFeature
{
    public HUDFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<UpdateDraftIndicatorViewSystem>());
    }
}