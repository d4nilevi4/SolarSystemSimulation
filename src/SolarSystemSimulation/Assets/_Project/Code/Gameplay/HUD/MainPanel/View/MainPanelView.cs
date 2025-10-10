using System.Text;
using TMPro;

namespace SolarSystem.Gameplay.HUD
{
    public class MainPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private TMP_Text _velocityText;

        public void SetSpeed(float speed)
        {
            _speedText.text = $"Speed: {speed:F2}";
        }

        public void SetVelocity(Vector3 velocity)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder
                .Append("Velocity x: ")
                .Append($"{velocity.x:F2}\n")
                .Append("Velocity y: ")
                .Append($"{velocity.y:F2}\n")
                .Append("Velocity z: ")
                .Append($"{velocity.z:F2}");
            _velocityText.SetText(stringBuilder);
        }
    }
}