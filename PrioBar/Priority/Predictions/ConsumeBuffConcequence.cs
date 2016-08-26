namespace PrioBar.Priority.Predictions
{
    public class ConsumeBuffConcequence : AbilityConsequenceBase
    {
        public override AbilityConsequenceType Type => AbilityConsequenceType.ConsumeBuff;

        public int Count { get; set; }
    }
}