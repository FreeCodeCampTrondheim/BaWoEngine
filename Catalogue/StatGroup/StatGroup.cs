using System.Collections.Generic;








public class StatGroup : ISubscribeCatalogue
{
    public Dictionary<int, BoolStat> boolStats;

    // based on text enum
    public Dictionary<int, TextStat> textStats;

    // final value of a numerical stat is combined base multiplied by combined modifiers
    public Dictionary<int, BaseNumberStat> baseNumberStats;
    public Dictionary<int, ModifyingNumberStat> modifyingNumberStats;

    public StatGroup GetCopy()
    {
        StatGroup newStatGroup = new StatGroup();

        foreach (var item in boolStats)
        {
            newStatGroup.boolStats.Add(item.Key, item.Value.GetCopy());
        }

        foreach (var item in textStats)
        {
            newStatGroup.textStats.Add(item.Key, item.Value.GetCopy());
        }

        foreach (var item in baseNumberStats)
        {
            newStatGroup.baseNumberStats.Add(item.Key, item.Value.GetCopy());
        }

        foreach (var item in modifyingNumberStats)
        {
            newStatGroup.modifyingNumberStats.Add(item.Key, item.Value.GetCopy());
        }

        return newStatGroup;
    }

    public void InitializeFromSubscription()
    {
        foreach (var item in textStats)
        {
            item.Value.InitializeFromSubscription();
        }

        foreach (var item in baseNumberStats)
        {
            item.Value.InitializeFromSubscription();
        }

        foreach (var item in modifyingNumberStats)
        {
            item.Value.InitializeFromSubscription();
        }
    }
}