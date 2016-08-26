namespace PrioBar.GameInfo
{
    using BlizzardApi.Global;

    public class SpellInfo : ISpellInfo
    {
        public double DurationLeft(string spellName)
        {
            var cooldown = Global.Api.GetSpellCooldown(spellName);
            var cooldownEndTime = cooldown.Item1 + cooldown.Item2;
            return cooldownEndTime - Lua.Core.time();
        }

        public double GetCastTime(string spellName)
        {
            return Global.Api.GetSpellInfo(spellName).Item4;
        }

        public double GetFullCooldown(string spellName)
        {
            var cooldown = Global.Api.GetSpellCooldown(spellName);
            return cooldown.Item2;
        }

        public string GetSpellIcon(string spellName)
        {
            return Global.Api.GetSpellInfo(spellName).Item3;
        }

        public string GetSpellName(string spellName)
        {
            return Global.Api.GetSpellInfo(spellName).Item1;
        }
    }
}