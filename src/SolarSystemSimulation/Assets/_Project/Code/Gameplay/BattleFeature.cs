using SolarSystem.Common;
using SolarSystem.Common.Destruct;
using SolarSystem.Gameplay.Animations;
using SolarSystem.Gameplay.Input;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay;

public sealed class BattleFeature : CustomFeature
{
    public BattleFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<InputFeature>());


        Add(systemFactory.Create<AnimationsFeature>());


        Add(systemFactory.Create<ProcessDestructedFeature>());
    }
}