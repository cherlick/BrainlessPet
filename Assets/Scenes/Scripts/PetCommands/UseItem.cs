using System.Collections;
using System.Collections.Generic;
using BrainlessPet.Items;
using BrainlessPet.Scriptables;
using UnityEngine;

namespace BrainlessPet.Characters.Pets
{
    public class UseItem : PetCommands
    {
        [SerializeField] private ItemData itemToUse;
        [SerializeField] protected ItemEventChannelSO ItemSetupChannel;

        protected override void OnEnable() 
        {
            ItemSetupChannel.OnItemRequested += SetupItem;
            base.OnEnable();
        }
        
        protected override void OnDisable() 
        {
            ItemSetupChannel.OnItemRequested -= SetupItem;
            base.OnDisable();
        }
        protected override void GiveCommand()
        {
            if (limitUsage.Value <= 0) return;

            base.GiveCommand();
            //itemToUse..UseItem();
            //StartCoroutine(RunItemAction(itemToUse.IsItemActive));
        }

        protected IEnumerator RunItemAction(bool isActive)
        {
            while (isActive)
            {
                //itemToUse.ItemAction();
                yield return null;
            }
            TurnOff();
        }

        private void TurnOff()
        {
            StopCoroutine("RunItemAction");
        }

        private void SetupItem(ItemData addItemToUse)
        {
            itemToUse = addItemToUse;
            
        } 
    }
}

