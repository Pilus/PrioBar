namespace PrioBar.Priority
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PrioBar.GameInfo;
    using PrioBar.Priority.Predictions;

    public class AbilityPriotizer
    {
        private const double GlobalCooldown = 0.3;

        private readonly List<PriotizedAbility> abilities = new List<PriotizedAbility>();

        private readonly ISpellInfo spellInfo;

        private readonly Func<AbilityPrioInfo, int, PriotizedAbility> priotizedAbilityFactory;

        private readonly PredictorBase[] predictors;

        private QueueObject[] queueObjects = new QueueObject[] { };

        public AbilityPriotizer(Func<AbilityPrioInfo, int, PriotizedAbility> priotizedAbilityFactory, PredictorBase[] predictors, GameInfoFactory gameInfoFactory)
        {
            this.priotizedAbilityFactory = priotizedAbilityFactory;
            this.predictors = predictors;
            this.spellInfo = gameInfoFactory.GetSpellInfo();
        }

        public void Add(AbilityPrioInfo ability)
        {
            this.abilities.Add(this.priotizedAbilityFactory(ability, this.abilities.Count + 1));
        }

        public void UpdatePriotization()
        {
            var priotizedAbilities = new List<PriotizedAbility>();

            var concequences = new List<AbilityConcequenceEntry>();

            var i = 0;
            var time = Lua.Core.time();

            while (i < 10)
            {
                var nextTime = time + GlobalCooldown;
                foreach (var predictorBase in this.predictors)
                {
                    predictorBase.SetConcequences(nextTime, concequences.ToArray());
                }

                var ability = this.abilities.FirstOrDefault(a => a.AreRequirementsFulfilled(this.predictors));

                if (ability != null)
                {
                    priotizedAbilities.Add(ability);
                }
                i++;
            }

            this.queueObjects = priotizedAbilities.Select(
                a => new QueueObject() { Icon = this.spellInfo.GetSpellIcon(a.GetSpellName()), Name = a.GetSpellName()})
                .ToArray();
        }

        public QueueObject[] GetQueueObjects()
        {
            return this.queueObjects;
        }
    }
}