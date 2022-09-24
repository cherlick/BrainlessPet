using System.Collections;
using UnityEngine;
using BrainlessPet.Actions;

namespace BrainlessPet.Characters.Pets
{
    public class JumpCommand : MonoBehaviour, IActionListener<float>
    {
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private float jumpForce;
        [SerializeField] protected KeyCode inputKey = KeyCode.R;
        [SerializeField] protected int limitUsage;
        private bool didJump;

        protected void Update()
        {
            if (Input.GetKeyUp(inputKey) && limitUsage > 0)
            {
                Jump();
                limitUsage-=1;
            }
            if (Input.GetKeyDown(inputKey) && didJump)
            {
                StartFall();
            }
        }

        public void Jump()
        {
            Vector2 targetVelocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y + jumpForce);
            rb2D.AddForce(targetVelocity, ForceMode2D.Impulse);
            didJump = true;
        }

        public void StartFall()
        {
            Vector2 targetVelocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y *-1);
            rb2D.AddForce(targetVelocity, ForceMode2D.Impulse);
            didJump = false;
        }

        public void ActionRaised(float usage) => limitUsage = (int)usage;
    }
}

