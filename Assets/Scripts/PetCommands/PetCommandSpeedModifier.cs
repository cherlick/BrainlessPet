namespace BrainlessPet.Characters.Pets
{
    public class PetCommandSpeedModifier : PetCommands
    {
        protected override void GiveCommand()
        {
            if (limitUsage.Value <= 0 || !isLevelReady.Value) return;

            base.GiveCommand();
            StartCoroutine(ApplyModifier(variableToModify.Value * commandType.modifier.Value));
        }
    }
}