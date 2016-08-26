namespace BlizzardApi.Global
{
    using System;

    public partial interface IApi
    {
        /// <summary>
        /// Retrieves the cooldown data of the spell specified.
        /// </summary>
        /// <param name="spellName">The name of the spell.</param>
        /// <returns>The startTime, duration and enabled flag of the duration.</returns>
        Tuple<double, int, int> GetSpellCooldown(string spellName);

        /// <summary>
        /// Retrieves the cooldown data of the spell specified.
        /// </summary>
        /// <param name="spellId">The id of the spell in spellbook or in database.</param>
        /// <returns>The startTime, duration and enabled flag of the duration.</returns>
        Tuple<double, int, int> GetSpellCooldown(int spellId);

        /// <summary>
        /// Gets the spell info for the spell specified.
        /// </summary>
        /// <param name="spellName">The name, rank, icon, castTime, minRange and maxRange of the spell.</param>
        /// <returns></returns>
        Tuple<string, string, string, double, double, double> GetSpellInfo(string spellName);

    }
}