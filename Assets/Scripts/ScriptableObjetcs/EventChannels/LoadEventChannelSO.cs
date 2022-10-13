using UnityEngine;
using UnityEngine.Events;

namespace BrainlessPet.Scriptables
{
    [CreateAssetMenu(menuName = "Events/Load Event Channel")]
    public class LoadEventChannelSO : ScriptableObject
    {
        public UnityAction<GameSceneSO, bool> OnLoadingRequested;

        public void RaiseEvent(GameSceneSO levelToLoad, bool showLoadingScreen)
        {
            if (OnLoadingRequested != null)
            {
                OnLoadingRequested.Invoke(levelToLoad, showLoadingScreen);
            }
        }
    }
}
