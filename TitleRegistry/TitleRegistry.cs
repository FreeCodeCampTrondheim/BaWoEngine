﻿using System.Collections.Generic;






// Short name for title access and storage class, a.k.a. the title registry.
// This class exists to optimize for the accessing of different 
public static class Title
{
    static List<string> situationTitles =
        new List<string>();
    static List<string> optionTitles =
        new List<string>();
    static List<string> forecastTitles =
        new List<string>();

    static List<string> boolStatTitles =
        new List<string>();
    static List<string> textStatTitles =
        new List<string>();
    static List<string> baseNumberStatTitles =
        new List<string>();
    static List<string> modifyingNumberStatTitles =
        new List<string>();

    // returned integer is the "receipt" - the id of the string you stored, use it
    // whenever you can in code, only access title when you need to display it to the user
    public static int RegisterTitle(string title, TITLE_TYPE whatIsTitleFor)
    {
        if (title.Length > 0)
        {
            switch (whatIsTitleFor)
            {
                case TITLE_TYPE.SITUATION:
                    situationTitles.Add(title);
                    return situationTitles.Count - 1;
                case TITLE_TYPE.OPTION:
                    optionTitles.Add(title);
                    return optionTitles.Count - 1;
                case TITLE_TYPE.FORECAST:
                    forecastTitles.Add(title);
                    return forecastTitles.Count - 1;
                case TITLE_TYPE.BOOL_STAT:
                    boolStatTitles.Add(title);
                    return boolStatTitles.Count - 1;
                case TITLE_TYPE.TEXT_STAT:
                    textStatTitles.Add(title);
                    return textStatTitles.Count - 1;
                case TITLE_TYPE.BASE_NUMBER_STAT:
                    baseNumberStatTitles.Add(title);
                    return baseNumberStatTitles.Count - 1;
                case TITLE_TYPE.MODIFYING_NUMBER_STAT:
                    modifyingNumberStatTitles.Add(title);
                    return modifyingNumberStatTitles.Count - 1;
                default:
                    return -1;
            }
        }
        else
        {
            return -1;
        }
    }

    // gives you the title for displaying to the user
    public static string GetTitle(int titleNumber, TITLE_TYPE typeOfTitle)
    {
        if (titleNumber >= 0)
        {
            switch (typeOfTitle)
            {
                case TITLE_TYPE.SITUATION:
                    if (situationTitles.Count > titleNumber)
                        return situationTitles[titleNumber];
                    break;
                case TITLE_TYPE.OPTION:
                    if (optionTitles.Count > titleNumber)
                        return optionTitles[titleNumber];
                    break;
                case TITLE_TYPE.FORECAST:
                    if (forecastTitles.Count > titleNumber)
                        return forecastTitles[titleNumber];
                    break;
                case TITLE_TYPE.BOOL_STAT:
                    if (boolStatTitles.Count > titleNumber)
                        return boolStatTitles[titleNumber];
                    break;
                case TITLE_TYPE.TEXT_STAT:
                    if (textStatTitles.Count > titleNumber)
                        return textStatTitles[titleNumber];
                    break;
                case TITLE_TYPE.BASE_NUMBER_STAT:
                    if (baseNumberStatTitles.Count > titleNumber)
                        return baseNumberStatTitles[titleNumber];
                    break;
                case TITLE_TYPE.MODIFYING_NUMBER_STAT:
                    if (modifyingNumberStatTitles.Count > titleNumber)
                        return modifyingNumberStatTitles[titleNumber];
                    break;
                default:
                    return "Invalid Title Type";
            }
        }
        
        return "Invalid Title Number";
    }

    // gives you the title id for use with engine
    public static int GetTitleID(string title, TITLE_TYPE typeOfTitle)
    {
        // note that default value of List<T>.IndexOf is -1 if not found
        if (title.Length > 0)
        {
            switch (typeOfTitle)
            {
                case TITLE_TYPE.SITUATION:
                    return situationTitles.IndexOf(title);
                case TITLE_TYPE.OPTION:
                    return optionTitles.IndexOf(title);
                case TITLE_TYPE.FORECAST:
                    return forecastTitles.IndexOf(title);
                case TITLE_TYPE.BOOL_STAT:
                    return boolStatTitles.IndexOf(title);
                case TITLE_TYPE.TEXT_STAT:
                    return textStatTitles.IndexOf(title);
                case TITLE_TYPE.BASE_NUMBER_STAT:
                    return baseNumberStatTitles.IndexOf(title);
                case TITLE_TYPE.MODIFYING_NUMBER_STAT:
                    return modifyingNumberStatTitles.IndexOf(title);
                default:
                    return -1;
            }
        }

        return -1;
    }
}