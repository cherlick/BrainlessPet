using System.Collections.Generic;
using UnityEngine;
using BrainlessPet.Characters.Pets;

namespace BrainlessPet.Scriptables
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "LevelsSystem/LevelData")]
    public class LevelData : ScriptableObject
    {
        [Header("Level scenes information")]
        public LevelSO nextLevel;
        [Space]
        [Header("Commands usage")]
        public List<PetCommandsData> petCommandsData;

        public void SetupLevel() 
        {
            petCommandsData.ForEach(command => command.SetupCommand());
        }
    }
    
}
