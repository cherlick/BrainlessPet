using UnityEngine;
using BrainlessPet.Scriptables;
using TMPro;
using UnityEngine.UI;
using System.Collections;

namespace BrainlessPet.UI
{
    public class UIPetCommand : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI uiUsage;
        private VoidEventChannelSO OnCommandTriggerChannel;
        private FloatEventChannelSO OnCommandUsageChannel;
        private FloatVariable currentUsage;
        private readonly float delayForUpdate = 0.01f;

        private void OnDisable() 
        {
            OnCommandUsageChannel.OnEventRaised-= UpdateUsage;
        }
        public void OnButtonPress()
        {
            if (OnCommandTriggerChannel != null)
            {
                OnCommandTriggerChannel.RaiseEvent();
                UpdateUsage();
            }   
        }
         public void OnButtonRealease()
        {
            if (OnCommandTriggerChannel != null)
            {
                OnCommandTriggerChannel.RaiseEvent();
            }   
        }

        public void SetupUIButton(Sprite icon, VoidEventChannelSO triggerChannel, FloatEventChannelSO usageChannel, FloatVariable usageReference)
        {
            image.sprite = icon;
            
            OnCommandTriggerChannel = triggerChannel;
            OnCommandUsageChannel = usageChannel;
            
            if (OnCommandUsageChannel != null)
            {
                OnCommandUsageChannel.OnEventRaised += UpdateUsage;
            }

            currentUsage = usageReference;
        }

        private IEnumerator UpdateDelay()
        {
            yield return new WaitForSeconds(delayForUpdate);
            UpdateUsage();
        }

        public void UpdateUsage(float usage) => uiUsage.text = usage.ToString();
        public void UpdateUsage() => uiUsage.text = currentUsage.Value.ToString();
        public void UpdateUsageWithDelay() => StartCoroutine("UpdateDelay");
    }
}

