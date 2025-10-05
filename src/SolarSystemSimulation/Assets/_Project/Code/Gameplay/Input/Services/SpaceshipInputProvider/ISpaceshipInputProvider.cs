namespace SolarSystem.Gameplay.Input;

public interface ISpaceshipInputProvider
{
    void Enable();
    void Disable();
    
    bool HasSpaceshipInput { get; }
    Vector3 GetSpaceshipInput();
}