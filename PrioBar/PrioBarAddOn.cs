namespace PrioBar
{
    using CsLuaFramework;
    using CsLuaFramework.Attributes;

    using BarUi;
    using GameInfo;
    using Priority;
    using Priority.Requirement;

    using Lua;

    using PrioBar.Priority.Predictions;

    [CsLuaAddOn("PrioBar", "PrioBar", 60200)]
    public class PrioBarAddOn : ICsLuaAddOn
    {
        public void Execute()
        {
            var gameInfoFactory = new GameInfoFactory();
            var requirementFactory = new RequirementFactory();
            var predictors = new PredictorBase[] { new BuffPredictor(gameInfoFactory) };
            var priotizer = new AbilityPriotizer(
                (info, priotity) => new PriotizedAbility(requirementFactory, info, priotity), predictors, gameInfoFactory);

            this.SetUpTestData(priotizer);

            var barUi = new Bar((p) => new BarButton(p));

            new Timer(0.1, () =>
                {
                    priotizer.UpdatePriotization();
                    var queue = priotizer.GetQueueObjects();
                    barUi.DisplayQueue(queue);
                });

            Core.print("PrioBar loaded.");
        }

        private void SetUpTestData(AbilityPriotizer priotizer)
        {
            priotizer.Add(new AbilityPrioInfo()
            {
                SpellName = "Fire Blast",
                Requirements = new []{ new RequirementInfo() { Type = RequirementType.Buff, Value1 = "Heating Up"} }
            });
            priotizer.Add(new AbilityPrioInfo()
            {
                SpellName = "Pyroblast",
                Requirements = new[] { new RequirementInfo() { Type = RequirementType.Buff, Value1 = "Hot Streak!" } }
            });
            priotizer.Add(new AbilityPrioInfo()
            {
                SpellName = "Fireball",
                Requirements = new RequirementInfo[] { }
            });
        }
    }
}