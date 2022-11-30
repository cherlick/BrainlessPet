using System;
using UnityEngine;

namespace BrainlessPet.Scriptables
{
    [Serializable]
    public class FloatReference
    {
        public bool UseConstante = true;
        public float ConstanteValue;
        public FloatVariable Variable;

        public float Value => UseConstante ? ConstanteValue : Variable.Value;
        
    }
}

