namespace SolarSystem.Gameplay.HUD
{
    public class DraftIndicatorAxisView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] _positiveCells;
        [SerializeField] private MeshRenderer[] _negativeCells;
        
        [SerializeField] private Material _activeMaterial;
        [SerializeField] private Material _inactiveMaterial;

        private float _lastNormalizedValue = float.MinValue;
        
        public void SetNormalizedAxisValue(float normalizedValue)
        {
            if (ValueNotChanged())
                return;
    
            _lastNormalizedValue = normalizedValue;

            MeshRenderer[] cellsToActivate;
            MeshRenderer[] cellsToDeactivate;
    
            float absValue = Mathf.Abs(normalizedValue);
    
            if (normalizedValue >= 0)
            {
                cellsToActivate = _positiveCells;
                cellsToDeactivate = _negativeCells;
            }
            else
            {
                cellsToActivate = _negativeCells;
                cellsToDeactivate = _positiveCells;
            }
    
            int activeCellCount = Mathf.RoundToInt(absValue * cellsToActivate.Length);
            activeCellCount = Mathf.Clamp(activeCellCount, 0, cellsToActivate.Length);
    
            for (int i = 0; i < cellsToActivate.Length; i++)
            {
                Material targetMaterial = i < activeCellCount ? _activeMaterial : _inactiveMaterial;
        
                if (cellsToActivate[i].sharedMaterial != targetMaterial)
                {
                    cellsToActivate[i].sharedMaterial = targetMaterial;
                }
            }
    
            for (int i = 0; i < cellsToDeactivate.Length; i++)
            {
                if (cellsToDeactivate[i].sharedMaterial != _inactiveMaterial)
                {
                    cellsToDeactivate[i].sharedMaterial = _inactiveMaterial;
                }
            }

            bool ValueNotChanged()
            {
                return Mathf.Approximately(_lastNormalizedValue, normalizedValue);
            }
        }
    }
}