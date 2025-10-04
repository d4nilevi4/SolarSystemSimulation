#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.SceneManagement;
#endif

namespace SolarSystem.Infrastructure
{
    // Has execution order to start before every other script
    public class SwitchToEntrySceneInEditor : MonoBehaviour
    {
#if UNITY_EDITOR
        public const string CURRENT_SCENE_NAME_KEY = "CurrentSceneNameKey"; 
        
        public bool LoadCurrentScene;

        private void Awake()
        {
            if (ProjectContext.HasInstance)
                return;

            foreach (GameObject root in gameObject.scene.GetRootGameObjects())
                root.SetActive(false);

            if(LoadCurrentScene)
            {
                EditorPrefs.SetString(CURRENT_SCENE_NAME_KEY, SceneManager.GetActiveScene().name);
            }

            SceneManager.LoadScene(Scenes.BOOT);
        }
#endif
    }
}