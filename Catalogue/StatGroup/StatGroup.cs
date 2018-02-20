using System.Collections.Generic;








public struct StatGroup
{
    public Dictionary<int, BoolStat> boolStats;
    public Dictionary<int, TextStat> textStats;  // based on text enum

    // final value of a numerical stat is combined base multiplied by combined modifiers
    public Dictionary<int, BaseNumberStat> baseNumberStats;
    public Dictionary<int, ModifyingNumberStat> modifyingNumberStats;
}