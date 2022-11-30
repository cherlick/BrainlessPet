using BrainlessPet.Items;
using UnityEngine;
using UnityEngine.Events;

namespace BrainlessPet.Scriptables
{
    [CreateAssetMenu(menuName = "Events/Item Event Channel")]
    public class ItemEventChannelSO : ScriptableObject
    {
        public UnityAction<ItemData> OnItemRequested;

        public void RaiseEvent(ItemData itemToUse)
        {
            if (OnItemRequested != null)
            {
                OnItemRequested.Invoke(itemToUse);
            }
        }
    }
}
