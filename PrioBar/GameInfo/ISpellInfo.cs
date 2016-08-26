namespace PrioBar.GameInfo
{
    public interface ISpellInfo : IGameInfo
    {
        double DurationLeft(string spellName);
        double GetCastTime(string spellName);
        double GetFullCooldown(string spellName);
        string GetSpellIcon(string spellName);
        string GetSpellName(string spellName);
    }
}