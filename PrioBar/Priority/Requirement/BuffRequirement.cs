namespace PrioBar.Priority.Requirement
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using GameInfo;

    public class BuffRequirement : AbilityPrioRequirementBase
    {
        private readonly string buffName;

        public BuffRequirement(RequirementInfo info)
        {
            this.buffName = (string)info.Value1;
        }

        public override bool IsFulFilled(IEnumerable<IGameInfo> info)
        {
            var buffInfo = info.OfType<IBuffInfo>().Single();
            return buffInfo.CountBuff(this.buffName) > 0;
        }
    }
}