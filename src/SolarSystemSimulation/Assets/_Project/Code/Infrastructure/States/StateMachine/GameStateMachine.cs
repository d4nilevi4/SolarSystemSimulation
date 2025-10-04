using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure
{
    public class GameStateMachine : IGameStateMachine, ITickable, IFixedTickable
    {
        private readonly IStateFactory _stateFactory;
        private IExitableState _activeState;

        public GameStateMachine(
            IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Tick()
        {
            if (_activeState is IUpdatableState updatableState)
                updatableState.Update();
        }

        public void FixedTick()
        {
            if (_activeState is IFixedUpdatableState fixedUpdatableState)
                fixedUpdatableState.FixedUpdate();
        }

        public async UniTask Enter<TState>() where TState : class, IState
        {
            TState state = await ChangeState<TState>();
            await state.Enter();
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = await ChangeState<TState>();
            await state.Enter(payload);
        }

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            if (_activeState != null)
                await _activeState.Exit();

            TState state = _stateFactory.GetState<TState>();
            _activeState = state;

            return state;
        }
    }
}