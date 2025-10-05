namespace SolarSystem.Gameplay.Input;

public class MainInputMapProvider : IMainInputMapProvider
{
    public PlayerInputActionsMap Map { get; } = new();
}