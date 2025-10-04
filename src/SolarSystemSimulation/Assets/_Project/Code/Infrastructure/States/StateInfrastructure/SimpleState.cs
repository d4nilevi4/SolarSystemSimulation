using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure
{
    public class SimpleState : IState
    {
        protected virtual void Enter() { }

        protected virtual void Exit() { }

        UniTask IState.Enter()
        {
            Enter();
            return default;
        }

        UniTask IExitableState.Exit()
        {
            Exit();
            return default;
        }
    }
}