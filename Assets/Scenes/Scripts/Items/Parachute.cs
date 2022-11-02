using System.Collections;
using BrainlessPet.Scriptables;
using UnityEngine;

namespace BrainlessPet.Items
{
    public class Parachute : Item
    {
        [Header("Parachute Settings")]
        [SerializeField] private BoolVariable isCharacterGrounded;
        [SerializeField] private FloatVariable yVelocity;
        [SerializeField] private BoolVariable isYVelocityChanged;
        [SerializeField] private float maxFallYVelocity;
        private float  fallVelocityDecreseTime = 60f;

        private void OnEnable() 
        {
            if (data.ItemTriggerChannel != null)
            {
                data.ItemTriggerChannel.OnEventRaised += UseItem;
            }
        }

        private void OnDisable() 
        {
            data.ItemTriggerChannel.OnEventRaised -= UseItem;
        }

        public void UseItem()
        {
            EnableItem();
            StartCoroutine("ItemExecute");
        }

        protected override IEnumerator ItemExecute()
        {
            while (!isCharacterGrounded.Value)
            {
                yield return new WaitForSeconds(0.01f);
                if (yVelocity.Value < maxFallYVelocity)
                {
                    yVelocity.Value += Time.deltaTime * fallVelocityDecreseTime;
                    isYVelocityChanged.Value = true;
                }
                else
                {
                    isYVelocityChanged.Value = false;
                }

            }
            isYVelocityChanged.Value = false;
            yield return new WaitForSeconds(0.01f);
            DisableItem();
            
        }
    }
}