using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrainlessPet.Actions
{
    [CreateAssetMenu(menuName = "Actions/NewAction")]
    public class ScriptableActions : ScriptableObject
    {
        public Action genericAction;

        public void Raise()
        {
            genericAction?.Invoke();
        }
    }
}

