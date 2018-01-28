using System.Collections.Generic;








public struct StatGroup
{
    // existence in list is equated with true, while absence is false
    public List<int> boolStats;

    // first integer is text stat, while second is text value
    public Dictionary<int, int> textStats;

    // final value of a numerical stat is combined base multiplied by combined modifiers
    public Dictionary<int, double> baseNumberStats;
    public Dictionary<int, double> modifyingNumberStats;
}