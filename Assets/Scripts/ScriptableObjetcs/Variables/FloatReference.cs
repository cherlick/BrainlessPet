using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrainlessPet.Scriptables
{
    [CreateAssetMenu]
    [Serializable]
    public class FloatReference
    {
        public bool UseConstante = true;
        public float ConstanteValue;
        public FloatVariable Variable;

        public float Value => UseConstante ? ConstanteValue : Variable.Value;
        
    }
}

