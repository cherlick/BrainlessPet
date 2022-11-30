using UnityEngine;
using BrainlessPet.Scriptables;

namespace BrainlessPet.LevelsSystem
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO onSceneReadyChannel = default;
        [SerializeField] private LoadEventChannelSO onloadLevelRequestChannel = default;
        [SerializeField] private VoidEventChannelSO onNextLevelChannel = default;
        [SerializeField] private VoidEventChannelSO onDeathChannel = default;
        [Tooltip("Initialize it with Core LevelSO")]
        [SerializeField] private LevelSO currentLevel = default;

        private void Start() 
        {
            if (currentLevel == null)
            {
                Debug.LogWarning($"currentLevel variable is empty {currentLevel}");
            }

            NextLevel();
        }

        private void OnEnable() 
        {
            if (onSceneReadyChannel != null)
            {
                onSceneReadyChannel.OnEventRaised += SetupLevelData;
            }
            if (onNextLevelChannel != null)
            {
                onNextLevelChannel.OnEventRaised += NextLevel;
            }
            if (onDeathChannel != null)
            {
                onDeathChannel.OnEventRaised += RestartLevel;
            }
        }
        private void OnDisable() 
        {
            onSceneReadyChannel!.OnEventRaised -= SetupLevelData;
            onNextLevelChannel!.OnEventRaised -= NextLevel;
            onDeathChannel!.OnEventRaised -= RestartLevel;
        }

        private void SetupLevelData() => currentLevel.levelData.SetupLevel();

        private void NextLevel()
        {
            onloadLevelRequestChannel?.RaiseEvent(currentLevel.levelData.nextLevel,false);
            currentLevel = currentLevel.levelData.nextLevel;    
        }
        private void RestartLevel()
        {
            onloadLevelRequestChannel?.RaiseEvent(currentLevel,false);
        }
    }
}

