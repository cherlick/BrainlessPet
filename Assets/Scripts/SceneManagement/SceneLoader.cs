using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BrainlessPet.Scriptables;

namespace BrainlessPet.ScenesChangeSystem
{

    /// <summary>
    /// This class manages the scene loading and unloading.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        [Header("Persistent Manager Scene")]
        [SerializeField] private GameSceneSO persistentManagersScene = default;

        [Header("Gameplay Scene")]
        [SerializeField] private GameSceneSO gameplayScene = default;

        [Header("Load Events")]
        //The location load event we are listening to
        [SerializeField] private LoadEventChannelSO loadLocation = default;
        //The menu load event we are listening to
        [SerializeField] private LoadEventChannelSO loadMenu = default;

        [Header("Broadcasting on")]
        //[SerializeField] private BoolEventChannelSO _ToggleLoadingScreen = default;
        [SerializeField] private VoidEventChannelSO OnSceneReady = default;

        private List<AsyncOperation> scenesToLoadAsyncOperations = new List<AsyncOperation>();
        private List<Scene> scenesToUnload = new List<Scene>();
        private GameSceneSO activeScene; // The scene we want to set as active (for lighting/skybox)
        private List<GameSceneSO> persistentScenes = new List<GameSceneSO>(); //Scenes to keep loaded when a load event is raised

        private void OnEnable()
        {
            if (loadLocation != null)
            {
                loadLocation.OnLoadingRequested += LoadLocation;
            }
            if (loadMenu != null)
            {
                loadMenu.OnLoadingRequested += LoadMenu;
            }
        }

        private void OnDisable()
        {
            if (loadLocation != null)
            {
                loadLocation.OnLoadingRequested -= LoadLocation;
            }
            if (loadMenu != null)
            {
                loadMenu.OnLoadingRequested -= LoadMenu;
            }
        }

        /// <summary>
        /// This function loads the location scenes passed as array parameter 
        /// </summary>
        /// <param name="locationsToLoad"></param>
        /// <param name="showLoadingScreen"></param>
        private void LoadLocation(GameSceneSO locationsToLoad, bool showLoadingScreen)
        {
            //When loading a location, we want to keep the persistent managers and gameplay scenes loaded
            persistentScenes.Add(persistentManagersScene);
            persistentScenes.Add(gameplayScene);
            AddScenesToUnload(persistentScenes);
            LoadScenes(locationsToLoad, showLoadingScreen);
        }

        /// <summary>
        /// This function loads the menu scenes passed as array parameter 
        /// </summary>
        /// <param name="MenuToLoad"></param>
        /// <param name="showLoadingScreen"></param>
        private void LoadMenu(GameSceneSO MenuToLoad, bool showLoadingScreen)
        {
            //When loading a menu, we only want to keep the persistent managers scene loaded
            persistentScenes.Add(persistentManagersScene);
            AddScenesToUnload(persistentScenes);
            LoadScenes(MenuToLoad, showLoadingScreen);
        }

        private void LoadScenes(GameSceneSO locationToLoad, bool showLoadingScreen)
        {
            //Take the first scene in the array as the scene we want to set active
            activeScene = locationToLoad;
            UnloadScenes();

            if (showLoadingScreen)
            {
                //ToggleLoadingScreen.RaiseEvent(true);
            }

            if (scenesToLoadAsyncOperations.Count == 0)
            {
                string currentScenePath = locationToLoad.scenePath;
                scenesToLoadAsyncOperations.Add(SceneManager.LoadSceneAsync(currentScenePath, LoadSceneMode.Additive));
            }

            //Checks if any of the persistent scenes is not loaded yet and load it if unloaded
            //This is especially useful when we go from main menu to first location
            for (int i = 0; i < persistentScenes.Count; ++i)
            {
                if (IsSceneLoaded(persistentScenes[i].scenePath) == false)
                {
                    scenesToLoadAsyncOperations.Add(SceneManager.LoadSceneAsync(persistentScenes[i].scenePath, LoadSceneMode.Additive));
                }
            }
            StartCoroutine(WaitForLoading(showLoadingScreen));
        }

        private IEnumerator WaitForLoading(bool showLoadingScreen)
        {
            bool loadingDone = false;
            // Wait until all scenes are loaded
            while (!loadingDone)
            {
                for (int i = 0; i < scenesToLoadAsyncOperations.Count; ++i)
                {
                    if (!scenesToLoadAsyncOperations[i].isDone)
                    {
                        break;
                    }
                    else
                    {
                        loadingDone = true;
                        scenesToLoadAsyncOperations.Clear();
                        persistentScenes.Clear();
                    }
                }
                yield return null;
            }
            //Set the active scene
            SetActiveScene();
            if (showLoadingScreen)
            {
                //Raise event to disable loading screen 
                //ToggleLoadingScreen.RaiseEvent(false);
            }

        }

        /// <summary>
        /// This function is called when all the scenes have been loaded
        /// </summary>
        private void SetActiveScene()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByPath(activeScene.scenePath));
            // Will reconstruct LightProbe tetrahedrons to include the probes from the newly-loaded scene
            LightProbes.TetrahedralizeAsync();
            //Raise the event to inform that the scene is loaded and set active
            OnSceneReady.RaiseEvent();
        }

        private void AddScenesToUnload(List<GameSceneSO> persistentScenes)
        {
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                string scenePath = scene.path;
                for (int j = 0; j < persistentScenes.Count; ++j)
                {
                    if (scenePath != persistentScenes[j].scenePath)
                    {
                        if (j == persistentScenes.Count - 1)
                        {
                            scenesToUnload.Add(scene);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void UnloadScenes()
        {
            if (scenesToUnload != null)
            {
                for (int i = 0; i < scenesToUnload.Count; ++i)
                {
                    SceneManager.UnloadSceneAsync(scenesToUnload[i]);
                }
                scenesToUnload.Clear();
            }
        }

        /// <summary>
        /// This function checks if a scene is already loaded
        /// </summary>
        /// <param name="scenePath"></param>
        /// <returns>bool</returns>
        private bool IsSceneLoaded(string scenePath)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.path == scenePath)
                {
                    return true;
                }
            }
            return false;
        }

        private void ExitGame()
        {
            Application.Quit();
            Debug.Log("Exit!");
        }

    }
}