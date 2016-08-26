namespace PrioBar.Priority.Requirement
{
    using System;

    using GameInfo;

    public class RequirementFactory
    {

        public IAbilityPrioRequirement Create(RequirementInfo info)
        {
            switch (info.Type)
            {
                case RequirementType.Buff:
                    return new BuffRequirement(info);
                default:
                    throw new Exception("Requirement type not handled " + info.Type);
            }
        }
    }
}
