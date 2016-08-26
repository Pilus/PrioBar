namespace PrioBar.Priority.Predictions
{
    public abstract class AbilityConsequenceBase
    {
        public abstract AbilityConsequenceType Type { get; }

        public string Name { get; set; }
    }
}