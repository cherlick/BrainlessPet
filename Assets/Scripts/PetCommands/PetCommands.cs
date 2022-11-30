using System.Collections;
using UnityEngine;
using BrainlessPet.Scriptables;

namespace BrainlessPet.Characters.Pets
{
    public abstract class PetCommands : MonoBehaviour
    {
        [Header("Command settings")]
        [SerializeField] protected PetCommandType commandType;
        [SerializeField] protected FloatReference variableToModify;
        [SerializeField] protected FloatReference limitUsage;
        [SerializeField] protected BoolReference isLevelReady;
        
        protected float originalValue;

        private WaitForSeconds waitingTime;

        protected virtual private void Start() 
        {
            waitingTime = new WaitForSeconds(commandType.duration.Value);
            originalValue = variableToModify.Value;
        }

        protected virtual void OnEnable() 
        {
            commandType.commandSetupChannel.OnEventRaised += UpdateUsage;
            commandType.commandTriggerChannel.OnEventRaised += GiveCommand;
        }
        protected virtual void OnDisable() 
        {
            commandType.commandSetupChannel.OnEventRaised -= UpdateUsage;
            commandType.commandTriggerChannel.OnEventRaised -= GiveCommand;
            if (variableToModify.Variable != null)
            {
                variableToModify.Variable.Value = originalValue;
            }
        }

        protected virtual void GiveCommand()
        {
            if (isLevelReady.Value)
            {
                limitUsage.Variable.Value--;
                commandType.commandSetupChannel.RaiseEvent(limitUsage.Value);
            }
        }

        protected virtual IEnumerator ApplyModifier(float modifierValue)
        {
            if (variableToModify.Value != modifierValue + originalValue)
            {
                variableToModify.Variable.Value += modifierValue;
            }
            yield return waitingTime;
            variableToModify.Variable.Value -= modifierValue;
        }

        public void UpdateUsage(float usage) => limitUsage.Variable.Value = usage;
    }
}

