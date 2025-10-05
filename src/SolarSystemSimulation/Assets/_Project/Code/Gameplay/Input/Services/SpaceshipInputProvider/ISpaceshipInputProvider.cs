namespace SolarSystem.Gameplay.Input;

public interface ISpaceshipInputProvider
{
    void Enable();
    void Disable();
    
    bool HasSpaceshipMovementInput { get; }
    bool HasSpaceshipRotationInput { get; }
    
    Vector3 GetSpaceshipMovementInput();
    Vector2 GetSpaceshipRotationInput();
}