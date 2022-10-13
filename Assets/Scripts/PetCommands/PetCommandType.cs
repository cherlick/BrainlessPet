using BrainlessPet.Scriptables;
using UnityEngine;

namespace BrainlessPet.Characters.Pets
{
    [CreateAssetMenu(fileName = "NewCommandType", menuName = "PetCommands/New PetCommandType")]
    public class PetCommandType : ScriptableObject
    {
        [Header("Event Channels")]
        public FloatEventChannelSO commandSetupChannel;
        public VoidEventChannelSO commandTriggerChannel;
        [Space]
        [Header("UI")]
        public Sprite icon;
        [Space]
        [Header("Commands Values")]
        public FloatReference modifier;
        public FloatReference duration;
        public FloatVariable usageVariableReference;
    }
}

