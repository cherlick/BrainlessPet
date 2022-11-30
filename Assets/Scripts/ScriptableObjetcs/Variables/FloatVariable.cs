using UnityEngine;

namespace BrainlessPet.Scriptables
{
    [CreateAssetMenu(menuName = "VariablesSO/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float value;
        private float previousValue;

        public float Value 
        { 
            get => value; 
            set 
            {
                previousValue = this.value;
                this.value = value;
            }
        }

        public float PreviousValue => previousValue;
    }
}

