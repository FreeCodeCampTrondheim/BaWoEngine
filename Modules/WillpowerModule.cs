using System.Collections.Generic;








public static partial class Catalogue
{
    static void WillpowerModule()
    {
        #region Situations
        int indexedTitle;

        indexedTitle = Title.RegisterTitle("Willpower", TITLE_TYPE.SITUATION_TITLE);
        characterSituations.Add(new CharacterSituationSharedData
        {
            simpleEntityTemplateID = Command.GetNewSimpleEntityTemplateID(),
            title = indexedTitle,
            description = "This character has the will to act.",
            ShouldTerminate = null,
            AttemptLaunching = null,
            stats =
            {
                baseNumberStats = new Dictionary<int, double>()
                {
                    {
                        Title.RegisterTitle(
                            "Willpower Constant Modifier", 
                            TITLE_TYPE.BASE_NUMBER_STAT),
                        0.0
                    }
                },
                modifyingNumberStats = new Dictionary<int, double>()
                {
                    {
                        Title.RegisterTitle(
                            "Willpower Percentage Modifier", 
                            TITLE_TYPE.MODIFYING_NUMBER_STAT),
                        1.0
                    }
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