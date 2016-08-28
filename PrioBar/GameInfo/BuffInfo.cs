namespace PrioBar.GameInfo
{
    using BlizzardApi.Global;
    using BlizzardApi.MiscEnums;

    public class BuffInfo : IBuffInfo
    {
        public int CountBuff(string buffName)
        {
            var buffInfo = Global.Api.UnitBuff(UnitId.player, buffName);
            var count = buffInfo?.Item4;
            return count ?? 0;
        }

        public double GetExpirationTime(string buffName)
        {
            var buffInfo = Global.Api.UnitBuff(UnitId.player, buffName);
            return buffInfo.Item7;
        }
    }
}