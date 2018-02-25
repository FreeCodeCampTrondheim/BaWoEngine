using System.Collections.Generic;








partial class Designer
{
    static int Generate(
        World w,
        Character c,
        Queue<CharacterAssemblyPattern> characterPatterns)
    {
        while (characterPatterns.Count > 0)
        {
            var pattern = characterPatterns.Dequeue();

            c.categoryNumbers.AddRange(pattern.categoryNumbers);
            pattern.ExecuteAdditionalSetup(c);

            var situationSharedData = pattern.PickSituationSharedData(c);
            while (situationSharedData.Count > 0)
            {
                var temp = situationSharedData.Dequeue();
                var personalized = Personalizer.Personalize
                    <Character.CharacterSituation, 
                    CharacterSituationSharedData>
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
                    <Character.CharacterOption,
                    CharacterOptionSharedData>
                    (c, w);

                c.options.Add(personalized);
            }

            var forecastSharedData = pattern.PickForecastSharedData(c);
            while (forecastSharedData.Count > 0)
            {
                var temp = forecastSharedData.Dequeue();
                var personalized = Personalizer.Personalize
                    <Character.CharacterForecast,
                    CharacterForecastSharedData>
                    (c, w);

                c.forecasts.Add(personalized);
            }
        }

        w.characters.Add(c);
        return w.characters.Count -1;
    }
}