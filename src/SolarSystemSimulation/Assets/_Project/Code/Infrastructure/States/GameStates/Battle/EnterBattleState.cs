using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure;

public class EnterBattleState : LocalEnterState
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly ISceneLoader _sceneLoader;

    public EnterBattleState(
        IGameStateMachine gameStateMachine,
        ISceneLoader sceneLoader
    )
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }
    
    public override UniTask Enter()
    {
        // PLACE HERO
        return _gameStateMachine.Enter<BattleLoopState>();
    }

    public override UniTask Exit()
    {
        return UniTask.CompletedTask;
    }
}