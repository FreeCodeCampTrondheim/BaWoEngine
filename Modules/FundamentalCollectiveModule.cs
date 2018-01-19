using System;
using System.Collections.Generic;







static partial class Catalogue
{
    static void FundamentalCollectiveModule()
    {
        #region Situations
        string indexedTitle;

        indexedTitle = "Active";
        collectiveSituations.Add(indexedTitle, new CollectiveSituationTemplate
        {
            title = indexedTitle,
            description = "This collective is able to do things.",
            ShouldTerminate = null,
            AttemptLaunching = null,
            stats =
            {
                boolStats = new List<string>()
                {
                    "Active"
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