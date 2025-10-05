using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Spaceship
{
    public class TempSpaceshipRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity
                .AddAcceleration(10f)
                .AddWorldPosition(new Vector3(0, 500, 0))
                .AddVelocity(Vector3.zero)
                .With(x => x.isSpaceship = true);
        }

        public override void UnregisterComponents()
        {
        }
    }
}