namespace PrioBar.Priority.Requirement
{
    using System.Collections.Generic;

    using PrioBar.GameInfo;

    public abstract class AbilityPrioRequirementBase : IAbilityPrioRequirement
    {
        public abstract bool IsFulFilled(IEnumerable<IGameInfo> info);
    }
}