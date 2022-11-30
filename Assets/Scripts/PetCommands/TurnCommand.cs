using UnityEngine;

namespace BrainlessPet.Characters.Pets
{
    public class TurnCommand : PetCommands
    {
        protected override void GiveCommand()
        {
            if (limitUsage.Value <= 0 || !isLevelReady.Value) return;
            
            base.GiveCommand();
            ChangeDirection();
        }
        private void ChangeDirection()
        {
            var direction = transform.localScale.x *-1;
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }
}

