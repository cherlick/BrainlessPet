using System.Collections;
using UnityEngine;

namespace BrainlessPet.Characters.Pets
{
    public class SpeedUpCommand : PetCommands
    {
        protected override void GiveCommand()
        {
            iComandable.ResetCommand();
            var current = iComandable.CurrentModifierValue;
            StartCoroutine(ApplyModifier(current + current * modifier));
        }
    }
}

