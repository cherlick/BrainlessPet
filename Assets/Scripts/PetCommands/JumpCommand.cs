using UnityEngine;

namespace BrainlessPet.Characters.Pets
{
    public class JumpCommand : PetCommands
    {
        [SerializeField] private Rigidbody2D rb2D;
        private bool didJump;

        protected override void GiveCommand()
        {
            if (!isLevelReady.Value) return;
            
            if (didJump)
            {
                Debug.Log("fall");
                StartFall();
            }
            else if (limitUsage.Value > 0 && !didJump)
            {
                base.GiveCommand();
                Debug.Log("Jump");
                Jump();
            }
        }

        public void Jump()
        {
            Vector2 targetVelocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y + commandType.modifier.Value);
            rb2D.AddForce(targetVelocity, ForceMode2D.Impulse);
            didJump = true;
        }

        public void StartFall()
        {
            Vector2 targetVelocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y *-1);
            rb2D.AddForce(targetVelocity, ForceMode2D.Impulse);
            didJump = false;
        }
    }
}

