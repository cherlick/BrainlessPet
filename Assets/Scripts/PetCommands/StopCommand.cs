using System.Collections;
using UnityEngine;

namespace BrainlessPet.Characters.Pets
{
    public class StopCommand : PetCommands
    {
        private void OnValidate() 
        {
            modifier = 1;
        }

        protected override void GiveCommand()
        {
            iComandable.ResetCommand();
            var current = iComandable.CurrentModifierValue;
            StartCoroutine(ApplyModifier(current - current * modifier));
        }
    }
}

