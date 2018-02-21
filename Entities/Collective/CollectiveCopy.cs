using System;
using System.Collections.Generic;







public partial class Collective : BaseComplexEntity
{
    // copies all data except controlling- and member characters
    public Collective GetCopy()
    {
        Collective newCollective = new Collective();

        // copies the content of the current array to a new array
        Array.Copy(
            categoryNumbers,
            newCollective.categoryNumbers,
            categoryNumbers.Length);

        newCollective.runSituations = runSituations;
        newCollective.runOptions = runOptions;
        newCollective.runForecasts = runForecasts;

        // uses copy-constructor of collection to make
        // a new collection with same contents
        newCollective.situations =
            new List<CollectiveSituation>(situations);
        newCollective.options =
            new List<CollectiveOption>(options);
        newCollective.forecasts =
            new List<CollectiveForecast>(forecasts);

        newCollective.stats.boolStats =
            new Dictionary<int, BoolStat>(stats.boolStats);
        newCollective.stats.textStats =
            new Dictionary<int, TextStat>(stats.textStats);
        newCollective.stats.baseNumberStats =
            new Dictionary<int, BaseNumberStat>(stats.baseNumberStats);
        newCollective.stats.modifyingNumberStats =
            new Dictionary<int, ModifyingNumberStat>(stats.modifyingNumberStats);

        return newCollective;
    }
}