using System;
using BrainlessPet.Scriptables;
using UnityEngine;

namespace BrainlessPet.Characters.Pets
{    
    [Serializable]
    public class PetCommandsData
    {
        public PetCommandType commandType;
        public FloatReference usageLimits;

        public void SetupCommand()
        {
            Debug.Log($"Setup {commandType.commandSetupChannel}");
            commandType.commandSetupChannel.RaiseEvent(usageLimits.Value);
        }
    }
}
