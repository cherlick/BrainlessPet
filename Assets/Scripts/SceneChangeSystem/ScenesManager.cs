using UnityEngine;
using UnityEngine.SceneManagement;

namespace BrainlessPet.ScenesChangeSystem
{
    public static class ScenesManager {
        public static void LoadScene(int index, LoadSceneMode mode = LoadSceneMode.Single)
        {
            if(index < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(index, mode);
            }
        }

        public static void LoadScene(SceneNamesEnum sceneName, bool isAdditive = false)
        {
            if (IsValidScene(sceneName.ToString()))
            {
                SceneManager.LoadScene(sceneName.ToString(), isAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
            }
        }

        public static void UnloadScene(SceneNamesEnum sceneName)
        {
            try
            {
                SceneManager.UnloadSceneAsync(sceneName.ToString());
            }
            catch (System.Exception)
            {
                Debug.LogWarning($"Unable to unload scene {sceneName}");
            }
        }

        public static void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static int GetNumberOfActiveScenes() => SceneManager.sceneCount;

        public static int GetLatestSceneAdded()
        {
            var scene = SceneManager.GetSceneAt(GetNumberOfActiveScenes()-1);
            return scene.buildIndex;
        }

        public static bool IsValidScene(string sceneName)
        {
            int sceneIndex = SceneUtility.GetBuildIndexByScenePath(sceneName);

            return sceneIndex >= 0 ? true : false;
        }

        
    }
}
