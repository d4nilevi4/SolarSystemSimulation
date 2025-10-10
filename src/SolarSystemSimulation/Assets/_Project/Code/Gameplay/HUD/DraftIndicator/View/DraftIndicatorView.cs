namespace SolarSystem.Gameplay.HUD
{
    public class DraftIndicatorView : MonoBehaviour
    {
        [SerializeField] private DraftIndicatorAxisView _xAxis;
        [SerializeField] private DraftIndicatorAxisView _yAxis;
        [SerializeField] private DraftIndicatorAxisView _zAxis;
        
        public void SetDraftVector(Vector3 draftVector)
        {
            _xAxis.SetNormalizedAxisValue(draftVector.x);
            _yAxis.SetNormalizedAxisValue(draftVector.y);
            _zAxis.SetNormalizedAxisValue(draftVector.z);
        }
    }
}