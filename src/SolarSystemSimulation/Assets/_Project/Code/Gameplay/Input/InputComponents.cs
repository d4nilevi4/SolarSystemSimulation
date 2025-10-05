namespace SolarSystem.Gameplay.Input;

[Input] public class Input : IComponent { }
[Input] public class InputAxis : IComponent { public Vector2 Value; }
[Input] public class WorldInput : IComponent { }
[Input] public class CameraRelativeInput : IComponent { }
[Input] public class SpaceshipInput : IComponent { }
[Input] public class SpaceshipMovementInput : IComponent { }
[Input] public class SpaceshipRotationInput : IComponent { }
[Input] public class SpaceshipMovementInputAxis : IComponent { public Vector3 Value; }
[Input] public class SpaceshipRotationInputAxis : IComponent { public Vector2 Value; }
