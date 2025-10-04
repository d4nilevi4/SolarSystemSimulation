using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure
{
    public interface IPayloadState<in TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}