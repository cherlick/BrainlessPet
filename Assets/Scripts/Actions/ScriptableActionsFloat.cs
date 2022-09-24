using System;
using UnityEngine;

namespace BrainlessPet.Actions
{
    [Serializable]
    [CreateAssetMenu(menuName = "Actions/NewActionFloat")]
    public class ScriptableActionsFloat : ScriptableActions
    {
        public new Action<float> genericAction;

        public void Raise(float passFloat)
        {
            genericAction?.Invoke(passFloat);
        }
    }
}

