using System.Collections.Generic;








public struct StatGroup
{
    public Dictionary<int, BoolStat> boolStats;
    public Dictionary<int, TextStat> textStats;  // based on text enum

    // final value of a numerical stat is combined base multiplied by combined modifiers
    public Dictionary<int, BaseNumberStat> baseNumberStats;
    public Dictionary<int, ModifyingNumberStat> modifyingNumberStats;
}

public struct BoolStat
{
    public int id;
    public string title;
    public bool value;
}

public struct TextStat
{
    public int id;
    public string title;
    public int value;      // only looked up as text enum

    // when detected during generation, will fill random value from enums
    public int[] subscribedTextEnums;
}

public struct BaseNumberStat
{
    public int id;
    public string title;
    public double value;

    // when detected during generation, will fill random value from enums
    public int[] subscribedNumberEnums;
}

public struct ModifyingNumberStat
{
    public int id;
    public string title;
    public double value;

    // when detected during generation, will fill random value from enums
    public int[] subscribedNumberEnums;
}