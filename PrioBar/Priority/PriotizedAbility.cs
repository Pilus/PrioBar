namespace PrioBar.Priority
{
    using System.Collections.Generic;
    using System.Linq;

    using GameInfo;
    using Requirement;

    public class PriotizedAbility
    {
        private readonly int priority;

        private readonly AbilityPrioInfo info;

        private readonly IAbilityPrioRequirement[] requirements;

        public PriotizedAbility(RequirementFactory requirementFactory, AbilityPrioInfo info, int priority)
        {
            this.info = info;
            this.priority = priority;
            this.requirements = info.Requirements.Select(requirementFactory.Create).ToArray();
        }

        public int GetPriority()
        {
            return this.priority;
        }

        public string GetSpellName()
        {
            return info.SpellName;
        }

        public bool AreRequirementsFulfilled(IEnumerable<IGameInfo> info)
        {
            return this.requirements.All(req => req.IsFulFilled(info));
        }
    }
}