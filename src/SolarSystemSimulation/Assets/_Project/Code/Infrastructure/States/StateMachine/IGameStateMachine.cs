using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace SolarSystem.Infrastructure
{
    public interface IGameStateMachine
    {
        [MustUseReturnValue]
        UniTask Enter<TState>() where TState : class, IState;
        [MustUseReturnValue]
        UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}