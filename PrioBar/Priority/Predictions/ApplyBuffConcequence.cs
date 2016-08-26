namespace PrioBar.Priority.Predictions
{
    public class ApplyBuffConcequence : AbilityConsequenceBase
    {
        public override AbilityConsequenceType Type => AbilityConsequenceType.ApplyBuff;

        public int Count { get; set; }

        public double Duration { get; set; }
    }
}