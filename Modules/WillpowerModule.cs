using System;
using System.Collections.Generic;







public static partial class Catalogue
{
    static void WillpowerModule()
    {
        #region Situations
        string indexedTitle;

        indexedTitle = "Willpower";
        characterSituations.Add(indexedTitle, new CharacterSituationTemplate
        {
            simpleEntityTemplateID = Command.GetNewSimpleEntityTemplateID(),
            title = indexedTitle,
            description = "This character has the will to act.",
            ShouldTerminate = null,
            AttemptLaunching = null,
            stats =
            {
                numericalStatsBase = new Dictionary<string, double>()
                {
                    { "Willpower Constant Modifier", 0.0 }
                },
                numericalStatsModifiers = new Dictionary<string, double>()
                {
                    { "Willpower Percentage Modifier", 1.0 }
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