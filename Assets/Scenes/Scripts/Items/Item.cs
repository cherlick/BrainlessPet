using System.Collections;
using BrainlessPet.Scriptables;
using UnityEngine;

namespace BrainlessPet.Items
{
    public abstract class Item : MonoBehaviour
    {
        [Header("Item General Settings")]
        [SerializeField] protected ItemData data;
        [SerializeField] private SpriteRenderer display;
        [SerializeField] private ItemEventChannelSO itemSetupChannel;
        
        public ItemData ItemType { get => data;}

        private void Awake() 
        {
            display.sprite = data.Icon;
        }

        public void PickedItem()
        {
            transform.localPosition = data.ItemPosition;
            display.sprite = data.InGameSprite;
            itemSetupChannel.RaiseEvent(data);
            display.enabled = false;
        }

        protected void EnableItem()
        {
            display.enabled = true;
            transform.localPosition = data.ItemPosition;
        }
        protected void DisableItem()
        {
            display.enabled = false;
            Destroy(gameObject, 0.1f);
        }

        protected abstract IEnumerator ItemExecute();
    }
}

