namespace BlizzardApi.Global
{
    using System;

    using BlizzardApi.MiscEnums;

    public partial interface IApi
    {
        /// <summary>
        /// Retrieves info about a certain buff on a certain unit. This is essentially an alias of UnitAura with the "HELPFUL" filter. 
        /// </summary>
        /// <param name="unit">The unit to query information for </param>
        /// <param name="index">The index of the buff to retrieve information for. Indices start at 1 and go up indefinitely until there are no more buffs on target. </param>
        /// <returns>The name, rank, icon, count, debuffType, duration, expirationTime, unitCaster</returns>
        Tuple<string, string, string, int, string, double, double, UnitId> UnitBuff(UnitId unit, int index);

        /// <summary>
        /// Retrieves info about a certain buff on a certain unit. This is essentially an alias of UnitAura with the "HELPFUL" filter. 
        /// </summary>
        /// <param name="unit">The unit to query information for </param>
        /// <param name="spellName">The name of the buff.</param>
        /// <returns>The name, rank, icon, count, debuffType, duration, expirationTime, unitCaster</returns>
        Tuple<string, string, string, int, string, double, double, UnitId> UnitBuff(UnitId unit, string buffName);
    }
}