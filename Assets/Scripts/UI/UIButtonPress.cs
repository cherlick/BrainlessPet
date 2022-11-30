using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrainlessPet.Scriptables;
using UnityEngine.SceneManagement;

namespace BrainlessPet.UI
{
    public class UIButtonPress : MonoBehaviour
    {
        [SerializeField] private LoadEventChannelSO onloadLevelRequestChannel = default;
        [SerializeField] private GameSceneSO sceneToLoad = default;


        public void ButtonPress()
        {
            onloadLevelRequestChannel?.RaiseEvent(sceneToLoad, false);
            SceneManager.LoadScene("Core", LoadSceneMode.Single);
        }
        
    }
}

