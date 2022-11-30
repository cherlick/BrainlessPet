using UnityEngine;
using UnityEngine.Events;

namespace BrainlessPet.Scriptables
{
    [CreateAssetMenu(menuName = "Events/Float Event Channel")]
    public class FloatEventChannelSO : ScriptableObject
    {
        public UnityAction<float> OnEventRaised;

        public void RaiseEvent(float levelToLoad)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(levelToLoad);
            }
        }
    }
}
