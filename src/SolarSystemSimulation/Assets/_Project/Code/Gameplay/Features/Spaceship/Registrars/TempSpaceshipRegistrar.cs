using SolarSystem.Common;
using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.Spaceship
{
    public class TempSpaceshipRegistrar : EntityComponentRegistrar
    {
        public Transform StartPoint;
        
        public override void RegisterComponents()
        {
            Entity
                .AddAcceleration(10f)
                .AddWorldPosition(StartPoint.position)
                .AddWorldRotation(StartPoint.rotation)
                .AddVelocity(Vector3.zero)
                .AddRotationSpeed(100f)
                .With(x => x.isSpaceship = true);
        }

        public override void UnregisterComponents()
        {
        }
    }
}