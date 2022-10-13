using UnityEngine;
using BrainlessPet.ScenesChangeSystem;

namespace BrainlessPet.UI
{
    public class UIButtons : MonoBehaviour
    {
        [SerializeField] private SceneNamesEnum sceneNameToLoad;
        [SerializeField] bool isAdditiveScene;

        public void PressToLoad()
        {
            ScenesManager.LoadScene(sceneNameToLoad);
        }
        public void PressToOpenUI()
        {
            
        }
    }
}
