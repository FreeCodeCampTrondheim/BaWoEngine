using System;
using System.Collections.Generic;







public static partial class Catalogue
{
    static void FundamentalCharacterModule()
    {
        #region Situations
        string indexedTitle;

        indexedTitle = "Active";
        characterSituations.Add(indexedTitle, new CharacterSituationTemplate
        {
            title = indexedTitle,
            description = "This character is able to do things.",
            ShouldTerminate = null,
            AttemptLaunching = null,
            stats =
            {
                boolStats = new List<string>()
                {
                    "Active"
                },
                numericalStatsBase = new Dictionary<string, double>()
                {
                    { "Willpower", 1000.0 }
                }
            }
        });
        #endregion


        #region Options
        // this module adds no options
        #endregion


        #region Forecasts
        // this module adds no forecasts
        #endregion


        #region Enumerations
        // this module adds no enumerations
        #endregion
    }
}