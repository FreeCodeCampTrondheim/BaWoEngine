using System;
using System.Collections.Generic;

static partial class Catalogue
{
    // Defines shared properties between all character simple templates,
    // like character situations, -options and -forecasts.
    public abstract class CharacterSimpleEntityTemplate
    {
        // what the situation/option/forecast is called
        public string title;

        /* 
            This is what the situation/option/forecast is about,
            but do take note that all substrings of the types "@ch5",
            "@co7", "@si3", "@op4" and "@fo2" are references. The "@" 
            indicates that this is the start of a reference. The type
            of reference is indicated by the following two letters:

                ch = character
                co = collective
                si = situation
                op = option
                fo = forecast

            While the number indicates what index you have to look at
            in a List<uint> called "about". Each index contains a number
            equalling another index in some collection containing all of
            the complex entities like character or collective, or simple
            entities like situation, option and forecast.
        */
        string description;

        #region TERMINATION
        /* 
            Describes the minimum POSITIVE statistical data conditions that have
            to be present in order for termination to occur. For numbers this is
            any value equal or ABOVE, while for text it is the PRESENCE of the text
            stat at the character.
        */
        StatGroup minPosTerminationRequirements;

        /* 
            Describes the minimum NEGATIVE statistical data conditions that have
            to be present in order for termination to occur. For numbers this is
            any value equal or BELOW, while for text it is the ABSENCE of the text
            stat at the character.
        */
        StatGroup minNegTerminationRequirements;

        // whether this situation/option/forecast no longer should be on the character
        public bool ShouldTerminate(Character c)
        {
            return c.stats.ChecksPosRequirements(minPosTerminationRequirements)
                && c.stats.ChecksNegRequirements(minNegTerminationRequirements);
        }
        #endregion

        #region LAUNCHING
        Launchables launchableSituations;
        Launchables launchableOptions;
        Launchables launchableForecasts;

        // checks if any situations, options or forecasts should be launched
        public void AttemptLaunching(Character c)
        {
            Dictionary<string, bool> situations = CheckRequirements(c, launchableSituations);
            Dictionary<string, bool> options = CheckRequirements(c, launchableOptions);
            Dictionary<string, bool> forecasts = CheckRequirements(c, launchableForecasts);

            // launch all SITUATIONS that have passed requirements
            foreach (var item in situations)
            {
                if (item.Value)
                    Generator.GenerateSituation(c, item.Key, launchableSituations.aboutIndexMap[item.Key]);
            }

            // launch all OPTIONS that have passed requirements
            foreach (var item in options)
            {
                if (item.Value)
                    Generator.GenerateOption(c, item.Key, launchableOptions.aboutIndexMap[item.Key]);
            }

            // launch all FORECASTS that have passed requirements
            foreach (var item in forecasts)
            {
                if (item.Value)
                    Generator.GenerateForecast(c, item.Key, launchableForecasts.aboutIndexMap[item.Key]);
            }
        }

        // checks the requirements of launchable situations, options or forecasts
        Dictionary<string, bool> CheckRequirements(Character c, Launchables launchConditions)
        {
            // the title of the situations, options or forecasts to launch
            Dictionary<string, bool> shouldLaunch = new Dictionary<string, bool>();

            // note down in "shouldLaunch" whether POSITIVE requirements are met
            foreach (var req in launchConditions.minPosLaunchConditions)
            {
                if (c.stats.ChecksPosRequirements(req.Value)) shouldLaunch.Add(req.Key, true);
                else shouldLaunch.Add(req.Key, false);
            }

            // note down in "shouldLaunch" whether NEGATIVE requirements are met,
            // and if necesary overwrite any conflicting notes taken in positive requirement check
            foreach (var req in launchConditions.minNegLaunchConditions)
            {
                if (c.stats.ChecksNegRequirements(req.Value))
                {
                    if (!shouldLaunch.ContainsKey(req.Key))
                    {
                        shouldLaunch.Add(req.Key, true);
                    }
                }
                else if (shouldLaunch.ContainsKey(req.Key)) shouldLaunch[req.Key] = false;
            }

            return shouldLaunch;
        }
        #endregion
    }
}