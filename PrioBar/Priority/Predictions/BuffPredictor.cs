namespace PrioBar.Priority.Predictions
{
    using System;
    using System.Linq;

    using PrioBar.GameInfo;
    public class BuffPredictor : PredictorBase, IBuffInfo
    {
        private readonly IBuffInfo buffInfo;

        public BuffPredictor(GameInfoFactory gameInfoFactory)
        {
            this.buffInfo = gameInfoFactory.GetBuffInfo();
            this.RelevantConsequences = new[] { AbilityConsequenceType.ApplyBuff, AbilityConsequenceType.ConsumeBuff, };
        }

        private Tuple<int, double> GetCountAndExpirationTime(string buffName)
        {
            var concequencesMatchingName = this.Concequences.Where(c => c.Consequence.Name == buffName).ToArray();
            var count = this.buffInfo.CountBuff(buffName);
            var expirationTime = this.buffInfo.GetExpirationTime(buffName);

            foreach (var concequenceEntry in concequencesMatchingName)
            {
                if (expirationTime < concequenceEntry.TimeStamp)
                {
                    count = 0;
                }

                var applyBuff = concequenceEntry.Consequence as ApplyBuffConcequence;
                var consumeBuff = concequenceEntry.Consequence as ConsumeBuffConcequence;
                if (applyBuff != null)
                {
                    count += applyBuff.Count;
                    expirationTime = concequenceEntry.TimeStamp + applyBuff.Duration;
                }
                else if (consumeBuff != null)
                {
                    count -= consumeBuff.Count;
                }
            }

            return new Tuple<int, double>(count, expirationTime);
        }

        public int CountBuff(string buffName)
        {
            return this.GetCountAndExpirationTime(buffName).Item1;
        }

        public double GetExpirationTime(string buffName)
        {
            return this.GetCountAndExpirationTime(buffName).Item2;
        }
    }
}