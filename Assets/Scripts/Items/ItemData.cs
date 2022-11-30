using BrainlessPet.Scriptables;
using UnityEngine;

namespace BrainlessPet.Items
{
    [CreateAssetMenu(menuName = "Items/New Data")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private Sprite inGameSprite;
        [TextArea] private string shortDescription;
        [SerializeField] private VoidEventChannelSO itemTriggerChannel;
        [SerializeField] private Vector2 itemPosition;

        public Sprite Icon => icon;
        public Sprite InGameSprite => inGameSprite;
        public VoidEventChannelSO ItemTriggerChannel => itemTriggerChannel;

        public Vector2 ItemPosition => itemPosition;
    }
}

