using System.Collections;
using UnityEngine;
using BrainlessPet.Actions;

namespace BrainlessPet.Characters.Pets
{
    public abstract class PetCommands : MonoBehaviour, IActionListener<float>
    {
        [SerializeField, Range(0f, 10f)] protected float duration;
        [SerializeField, Range(0f, 1.5f)] protected float modifier = 0.1f;
        [SerializeField] protected KeyCode inputKey = KeyCode.R;
        [SerializeField] protected int limitUsage;
        protected float currentValue;

        private WaitForSeconds waitingTime;
        protected ICommandable iComandable;

        protected virtual private void Start() 
        {
            waitingTime = new WaitForSeconds(duration);
            iComandable = GetComponent<ICommandable>();
        }

        protected virtual void Update()
        {
            if (Input.GetKeyUp(inputKey) && limitUsage > 0)
            {
                GiveCommand();
                limitUsage-=1;
            }
        }

        protected abstract void GiveCommand();

        protected virtual IEnumerator ApplyModifier(float modifiedValue)
        {
            iComandable.CurrentModifierValue = modifiedValue;
            yield return waitingTime;
            iComandable.ResetCommand();
        }

        public void ActionRaised(float usage) => limitUsage = (int)usage;

    }
}

