using System.Collections.Generic;








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
    public List<int> subscribedTextEnums;
}

public struct BaseNumberStat
{
    public int id;
    public string title;
    public double value;

    // when detected during generation, will fill random value from enums
    public List<int> subscribedNumberEnums;
}

public struct ModifyingNumberStat
{
    public int id;
    public string title;
    public double value;

    // when detected during generation, will fill random value from enums
    public List<int> subscribedNumberEnums;
}