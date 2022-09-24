using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BrainlessPet.Characters.Pets;
using BrainlessPet.ScenesChangeSystem;

namespace BrainlessPet.LevelsSystem
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "LevelsSystem/LevelData")]
    public class LevelData : ScriptableObject
    {
        [Header("Level scenes information")]
        public SceneNamesEnum sceneName;
        public SceneNamesEnum nextSceneName;
        [Space]
        [Header("Commands usage")]
        public List<PetCommandsData> commandsUsageLimits;

        private void OnValidate()
        {
             if (name != sceneName.ToString())
             {
                 string thisFileNewName = sceneName.ToString();
                 string assetPath = AssetDatabase.GetAssetPath(this.GetInstanceID());
                 AssetDatabase.RenameAsset(assetPath, thisFileNewName);
                 AssetDatabase.SaveAssets();
             }           
        }

        public void SetupCommandsUsage() 
        {
            commandsUsageLimits.ForEach(c => c.SetupDataCommands());
        }
    }
}
