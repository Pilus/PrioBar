namespace PrioBar.Priority.Predictions
{
    using System.Linq;

    using PrioBar.GameInfo;

    public class PredictorBase : IGameInfo
    {
        protected AbilityConcequenceEntry[] Concequences;

        protected AbilityConsequenceType[] RelevantConsequences;

        protected double Timestamp;

        public void SetConcequences(double timeStamp, AbilityConcequenceEntry[] concequences)
        {
            this.Timestamp = timeStamp;
            this.Concequences = concequences.Where(c => this.RelevantConsequences.Contains(c.Consequence.Type)).ToArray();
        }
    }
}