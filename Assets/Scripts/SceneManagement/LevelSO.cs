using UnityEngine;

namespace BrainlessPet.Scriptables
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
    public class LevelSO : GameSceneSO
    {
        [Header("Level specific")]
        public LevelData levelData;
    }
}

