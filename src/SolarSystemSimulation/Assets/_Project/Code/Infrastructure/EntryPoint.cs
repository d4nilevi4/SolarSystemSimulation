using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            gameStateMachine.Enter<BootstrapState>().Forget();
        }
    }
}