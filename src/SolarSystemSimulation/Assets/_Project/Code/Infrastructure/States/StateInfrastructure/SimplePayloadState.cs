using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure
{
    public class SimplePayloadState<TPayload> : IPayloadState<TPayload>
    {
        protected virtual void Enter(TPayload payload) { }

        protected virtual void Exit() { }

        UniTask IPayloadState<TPayload>.Enter(TPayload payload)
        {
            Enter(payload);
            return UniTask.CompletedTask;
        }
        
        UniTask IExitableState.Exit()
        {
            Exit();
            return UniTask.CompletedTask;
        }
    }
}