using System;
using BrainlessPet.Actions;

namespace BrainlessPet.Characters.Pets
{    
    [Serializable]
    public class PetCommandsData
    {
        public PetCommandsEnum command;
        public int usageLimit;
        public ScriptableActionsFloat commandToSetup;
        public void SetupDataCommands()
        {
            commandToSetup.Raise(usageLimit);
        }
    }
}
