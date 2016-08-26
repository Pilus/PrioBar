namespace PrioBar.GameInfo
{
    public interface IBuffInfo : IGameInfo
    {
        int CountBuff(string buffName);

        double GetExpirationTime(string buffName);
    }
}