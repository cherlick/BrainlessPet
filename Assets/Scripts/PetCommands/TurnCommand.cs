using System.Collections;
using UnityEngine;
using BrainlessPet.Actions;

namespace BrainlessPet.Characters.Pets
{
    public class TurnCommand : MonoBehaviour, IActionListener<float>
    {
        [SerializeField] protected KeyCode inputKey = KeyCode.T;
        [SerializeField] protected int limitUsage;

        protected void Update()
        {
            if (Input.GetKeyUp(inputKey) && limitUsage > 0)
            {
                ChangeDirection();
                limitUsage-=1;
            }
        }
        private void ChangeDirection()
        {
            var direction = transform.localScale.x *-1;
            transform.localScale = new Vector3(direction, 1, 1);
        }

        public void ActionRaised(float usage) => limitUsage = (int)usage;
    }
}

