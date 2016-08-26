namespace PrioBar.GameInfo
{
    public class GameInfoFactory
    {
        public SpellInfo GetSpellInfo()
        {
            return new SpellInfo();
        }

        public BuffInfo GetBuffInfo()
        {
            return new BuffInfo();
        }
    }
}