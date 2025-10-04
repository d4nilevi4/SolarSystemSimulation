namespace SolarSystem.Gameplay.SolarSystem
{
    [CreateAssetMenu(
        menuName = "SolarSystem/" + nameof(SolarSystemObjectConfig), 
        fileName = nameof(SolarSystemObjectConfig))]
    public class SolarSystemObjectConfig : ScriptableObject
    {
        [field: SerializeField] public SolarSystemObjectTypeId Id { get; private set; }
        
        [field: SerializeField] public double Mass { get; private set; }
    }
}