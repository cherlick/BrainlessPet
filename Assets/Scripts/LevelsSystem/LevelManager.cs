using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrainlessPet.ScenesChangeSystem;

namespace BrainlessPet.LevelsSystem
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] List<LevelData> allLevels = new List<LevelData>();
        private readonly int numberOfPossibleActiveScenes = 2;

        private SceneNamesEnum currentLevel;
        private SceneNamesEnum nextLevel = SceneNamesEnum.Level_1;
        private Dictionary<SceneNamesEnum, LevelData> levels = new Dictionary<SceneNamesEnum, LevelData>();

        private void Awake() 
        {
            allLevels.ForEach( data => levels.Add(data.sceneName, data));
        }

        private void Start() 
        {
            ChangeLevel();
            SetupLevel();
        }

        private void SetupLevel()
        {
            levels[currentLevel].SetupCommandsUsage();
        }
        private void ChangeLevel()
        {
            //Debug.Log($"Is {nextLevel} a valid scene? {ScenesManager.IsValidScene(nextLevel.ToString())}");

            if (!ScenesManager.IsValidScene(nextLevel.ToString())) return;

            if (ScenesManager.GetNumberOfActiveScenes() >= numberOfPossibleActiveScenes)
            {
                ScenesManager.UnloadScene(currentLevel);
            }
            
            ScenesManager.LoadScene(nextLevel, true);

            currentLevel = nextLevel;
            if (IsSceneALevel(currentLevel))
            {
                SetupLevel();
            }
        }
        private bool IsSceneALevel(SceneNamesEnum nextSceneName) => levels.ContainsKey(nextSceneName);

    }
}

