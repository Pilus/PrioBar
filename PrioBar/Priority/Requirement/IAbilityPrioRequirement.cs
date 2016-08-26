namespace PrioBar.Priority.Requirement
{
    using System.Collections.Generic;

    using PrioBar.GameInfo;

    public interface IAbilityPrioRequirement
    {
        bool IsFulFilled(IEnumerable<IGameInfo> info);
    }
}