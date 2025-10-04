using Cysharp.Threading.Tasks;

namespace SolarSystem.Infrastructure;

public class LoadLocalState : IPayloadState<string>
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadLocalState(
        IGameStateMachine gameStateMachine,
        ISceneLoader sceneLoader
    )
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }
    
    public async UniTask Enter(string sceneName)
    {
        await _sceneLoader.LoadSceneAsync(sceneName);
        await _gameStateMachine.Enter<LocalEnterState>();
    }

    public UniTask Exit()
    {
        return UniTask.CompletedTask;
    }
}