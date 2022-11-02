namespace BrainlessPet.Characters.Pets
{
    public class PetCommandSpeedModifier : PetCommands
    {
        protected override void GiveCommand()
        {
            if (limitUsage.Value <= 0) return;

            base.GiveCommand();
            variableToModify.Variable.Value = originalValue;
            var current = variableToModify.Value;
            StartCoroutine(ApplyModifier(current + current * commandType.modifier.Value));
        }
    }
}