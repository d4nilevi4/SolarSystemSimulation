namespace SolarSystem.Gameplay.Input;

[Input] public class Input : IComponent { }
[Input] public class InputAxis : IComponent { public Vector2 Value; }
[Input] public class WorldInput : IComponent { }
[Input] public class CameraRelativeInput : IComponent { }