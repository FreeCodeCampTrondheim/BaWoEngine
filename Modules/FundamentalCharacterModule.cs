using System;
using System.Collections.Generic;







public static partial class Catalogue
{
    static void FundamentalCharacterModule()
    {
        #region Situations
        string indexedTitle;

        indexedTitle = "Living";
        CharacterTemplating.situations.Add(indexedTitle, new CharacterSituationTemplate
        {
            title = indexedTitle,
            description = "This character is lives life.",
            ShouldTerminate = null,
            AttemptLaunching = null,
            stats =
            {
                boolStats = new List<string>()
                {
                    "Living"
                },
                numericalStatsBase = new Dictionary<string, double>()
                {
                    { "Willpower", 1000.0 }
                }
            }
        });

        indexedTitle = "Incapacitated";
        CharacterTemplating.situations.Add(indexedTitle, new CharacterSituationTemplate
        {
            title = indexedTitle,
            description = "This character is unable to live life.",
            ShouldTerminate = delegate (Character c)
            {
                throw new NotImplementedException();
            },
            AttemptLaunching = delegate(Character c)
            {
                throw new NotImplementedException();
            }
        });

        indexedTitle = "Dead";
        CharacterTemplating.situations.Add(indexedTitle, new CharacterSituationTemplate
        {
            title = indexedTitle,
            description = "This person is dead.",
            ShouldTerminate = delegate (Character c)
            {
                throw new NotImplementedException();
            },
            AttemptLaunching = delegate (Character c)
            {
                throw new NotImplementedException();
            }
        });
        #endregion


        #region Options

        #endregion


        #region Forecasts

        #endregion


        #region Enumerations

        #endregion
    }
}