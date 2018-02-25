using System;
using System.Collections.Generic;







public interface ISubscribeCatalogue
{
    void InitializeFromSubscription();
}

public interface ICopyable<T>
{
    T GetCopy();
}

public class BoolStat : ICopyable<BoolStat>
{
    public int groupID;
    public string title;
    public int data;    // 0 or less = false, 1 or more = true

    public BoolStat GetCopy()
    {
        var newStat = new BoolStat();
        newStat.groupID = groupID;
        newStat.title = title;
        newStat.data = data;

        return newStat;
    }
}

public class TextStat : ICopyable<TextStat>, ISubscribeCatalogue
{
    public int groupID;
    public string title;
    public int data;      // only looked up as text enum

    // when detected during generation, will set random data from enums
    public List<int> subscribedEnums;

    public TextStat GetCopy()
    {
        var newStat = new TextStat();
        newStat.groupID = groupID;
        newStat.title = title;
        newStat.data = data;
        newStat.subscribedEnums.AddRange(subscribedEnums);

        return newStat;
    }

    public void InitializeFromSubscription()
    {
        Random random = new Random();

        int ranNum = random.Next(subscribedEnums.Count - 1);

        int enumInList = subscribedEnums[ranNum];
        data = random.Next(Catalogue.textEnums[enumInList].Count);
    }
}

public class BaseNumberStat : ICopyable<BaseNumberStat>, ISubscribeCatalogue
{
    public int groupID;
    public string title;
    public int data;

    // when detected during generation, will set random data from enums
    public List<int> subscribedEnums;

    public BaseNumberStat GetCopy()
    {
        var newStat = new BaseNumberStat();
        newStat.groupID = groupID;
        newStat.title = title;
        newStat.data = data;
        newStat.subscribedEnums.AddRange(subscribedEnums);

        return newStat;
    }

    public void InitializeFromSubscription()
    {
        Random random = new Random();

        int ranNum = random.Next(subscribedEnums.Count - 1);

        int enumInList = subscribedEnums[ranNum];
        data = random.Next(Catalogue.numberEnums[enumInList].Count);
    }
}

public class ModifyingNumberStat : ICopyable<ModifyingNumberStat>, ISubscribeCatalogue
{
    public int groupID;
    public string title;
    public int data;

    // when detected during generation, will set random data from enums
    public List<int> subscribedEnums;

    public ModifyingNumberStat GetCopy()
    {
        var newStat = new ModifyingNumberStat();
        newStat.groupID = groupID;
        newStat.title = title;
        newStat.data = data;
        newStat.subscribedEnums.AddRange(subscribedEnums);

        return newStat;
    }

    public void InitializeFromSubscription()
    {
        Random random = new Random();

        int ranNum = random.Next(subscribedEnums.Count - 1);

        int enumInList = subscribedEnums[ranNum];
        data = random.Next(Catalogue.numberEnums[enumInList].Count);
    }
}