using System.Collections.Generic;








partial class Designer
{
    static int Generate(
        World w,
        Collective c,
        Queue<CollectiveAssemblyPattern> collectivePatterns,
        Queue<ParticipationAssemblyPattern> controllingCharacterPatterns,
        Queue<ParticipationAssemblyPattern> memberCharacterPatterns)
    {
        while (collectivePatterns.Count > 0)
        {
            var pattern = collectivePatterns.Dequeue();

            c.categoryNumbers.AddRange(pattern.categoryNumbers);
            pattern.ExecuteAdditionalSetup(c);

            var situationSharedData = pattern.PickSituationSharedData(c);
            while (situationSharedData.Count > 0)
            {
                var temp = situationSharedData.Dequeue();
                var personalized = Personalizer.Personalize
                    <Collective.CollectiveSituation,
                    CollectiveSituationSharedData>
                    (c, w);

                personalized.stats = personalized.sharedData.stats.GetCopy();
                personalized.stats.InitializeFromSubscription();

                c.situations.Add(personalized);
            }

            var optionSharedData = pattern.PickOptionSharedData(c);
            while (optionSharedData.Count > 0)
            {
                var temp = optionSharedData.Dequeue();
                var personalized = Personalizer.Personalize
                    <Collective.CollectiveOption,
                    CollectiveOptionSharedData>
                    (c, w);

                c.options.Add(personalized);
            }

            var forecastSharedData = pattern.PickForecastSharedData(c);
            while (forecastSharedData.Count > 0)
            {
                var temp = forecastSharedData.Dequeue();
                var personalized = Personalizer.Personalize
                    <Collective.CollectiveForecast,
                    CollectiveForecastSharedData>
                    (c, w);

                c.forecasts.Add(personalized);
            }
        }

        /*
            Complete all assembly patterns 
        */

        w.collectives.Add(c);
        return w.collectives.Count - 1;
    }
}