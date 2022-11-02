using System;
using UnityEngine;

namespace BrainlessPet.Scriptables
{
    [Serializable]
    public class BoolReference
    {
        public bool UseConstante = true;
        public bool ConstanteValue;
        public BoolVariable Variable;

        public bool Value => UseConstante ? ConstanteValue : Variable.Value;
        
    }
}

