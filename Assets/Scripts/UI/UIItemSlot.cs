using BrainlessPet.Items;
using BrainlessPet.Scriptables;
using UnityEngine;
using UnityEngine.UI;

namespace BrainlessPet.UI
{
    public class UIItemSlot : MonoBehaviour
    {
        [SerializeField] private ItemEventChannelSO itemSetupEvent;
        [SerializeField] private VoidEventChannelSO itemUsageEvent;
        [SerializeField] Button itemSlotButton;

        private ItemData currentItem;

        private void OnEnable() 
        {
            itemSetupEvent.OnItemRequested += SetupButton;
            itemUsageEvent.OnEventRaised += OnItemUsage;
        }

        private void OnDisable() 
        {
            itemSetupEvent.OnItemRequested -= SetupButton;
            itemUsageEvent.OnEventRaised -= OnItemUsage;
        }

        private void SetupButton(ItemData itemToSetup)
        {
            currentItem = itemToSetup;
            itemSlotButton.image.sprite = currentItem.Icon;
            itemSlotButton.gameObject.SetActive(true);
        }

        private void OnItemUsage() => itemSlotButton.gameObject.SetActive(false);

        public void ButtonPress() => currentItem.ItemTriggerChannel.RaiseEvent();
    }
}

