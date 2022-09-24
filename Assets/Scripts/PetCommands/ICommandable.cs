using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrainlessPet.Characters.Pets
{
    public interface ICommandable
    {
        public float CurrentModifierValue { get; set;}
        public void ResetCommand();
    }
}

