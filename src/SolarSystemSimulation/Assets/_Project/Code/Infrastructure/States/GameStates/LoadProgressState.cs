using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace SolarSystem.Infrastructure
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public LoadProgressState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public async UniTask Enter()
        {
            const int secondSceneIndex = 1;
            string sceneName = SceneManager.GetSceneByBuildIndex(secondSceneIndex).name;
            
#if UNITY_EDITOR
            string key = SwitchToEntrySceneInEditor.CURRENT_SCENE_NAME_KEY;
            
            if (EditorPrefs.HasKey(key))
            {
                sceneName = EditorPrefs.GetString(key);

                EditorPrefs.DeleteKey(key);
            }
#endif
            await _stateMachine.Enter<LoadLocalState, string>(sceneName);
        }

        public UniTask Exit() =>
            UniTask.CompletedTask;
    }
}