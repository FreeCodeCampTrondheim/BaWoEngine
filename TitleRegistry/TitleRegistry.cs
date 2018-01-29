using System.Collections.Generic;






// Short name for title access and storage class, a.k.a. the title registry.
// This class exists to optimize for the accessing of different 
public static class Title
{
    static List<string> characterSituationTitles =
        new List<string>();
    static List<string> characterOptionTitles =
        new List<string>();
    static List<string> characterForecastTitles =
        new List<string>();

    static List<string> collectiveSituationTitles =
    new List<string>();
    static List<string> collectiveOptionTitles =
        new List<string>();
    static List<string> collectiveForecastTitles =
        new List<string>();

    static List<string> careAboutTitles =
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
    public static int RegisterTitle(string title, TITLE_TYPE typeOfTitle)
    {
        if (title.Length > 0)
        {
            switch (typeOfTitle)
            {
                case TITLE_TYPE.CHARACTER_SITUATION:
                    characterSituationTitles.Add(title);
                    return characterSituationTitles.Count - 1;
                case TITLE_TYPE.CHARACTER_OPTION:
                    characterOptionTitles.Add(title);
                    return characterOptionTitles.Count - 1;
                case TITLE_TYPE.CHARACTER_FORECAST:
                    characterForecastTitles.Add(title);
                    return characterForecastTitles.Count - 1;
                case TITLE_TYPE.COLLECTIVE_SITUATION:
                    collectiveSituationTitles.Add(title);
                    return collectiveSituationTitles.Count - 1;
                case TITLE_TYPE.COLLECTIVE_OPTION:
                    collectiveOptionTitles.Add(title);
                    return collectiveOptionTitles.Count - 1;
                case TITLE_TYPE.COLLECTIVE_FORECAST:
                    collectiveForecastTitles.Add(title);
                    return collectiveForecastTitles.Count - 1;
                case TITLE_TYPE.CARE_ABOUT:
                    careAboutTitles.Add(title);
                    return boolStatTitles.Count - 1;
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
                case TITLE_TYPE.CHARACTER_SITUATION:
                    if (characterSituationTitles.Count > titleNumber)
                        return characterSituationTitles[titleNumber];
                    break;
                case TITLE_TYPE.CHARACTER_OPTION:
                    if (characterOptionTitles.Count > titleNumber)
                        return characterOptionTitles[titleNumber];
                    break;
                case TITLE_TYPE.CHARACTER_FORECAST:
                    if (characterForecastTitles.Count > titleNumber)
                        return characterForecastTitles[titleNumber];
                    break;
                case TITLE_TYPE.COLLECTIVE_SITUATION:
                    if (collectiveSituationTitles.Count > titleNumber)
                        return collectiveSituationTitles[titleNumber];
                    break;
                case TITLE_TYPE.COLLECTIVE_OPTION:
                    if (collectiveOptionTitles.Count > titleNumber)
                        return collectiveOptionTitles[titleNumber];
                    break;
                case TITLE_TYPE.COLLECTIVE_FORECAST:
                    if (collectiveForecastTitles.Count > titleNumber)
                        return collectiveForecastTitles[titleNumber];
                    break;
                case TITLE_TYPE.CARE_ABOUT:
                    if (careAboutTitles.Count > titleNumber)
                        return careAboutTitles[titleNumber];
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
                case TITLE_TYPE.CHARACTER_SITUATION:
                    return characterSituationTitles.IndexOf(title);
                case TITLE_TYPE.CHARACTER_OPTION:
                    return characterOptionTitles.IndexOf(title);
                case TITLE_TYPE.CHARACTER_FORECAST:
                    return characterForecastTitles.IndexOf(title);
                case TITLE_TYPE.COLLECTIVE_SITUATION:
                    return collectiveSituationTitles.IndexOf(title);
                case TITLE_TYPE.COLLECTIVE_OPTION:
                    return collectiveOptionTitles.IndexOf(title);
                case TITLE_TYPE.COLLECTIVE_FORECAST:
                    return collectiveForecastTitles.IndexOf(title);
                case TITLE_TYPE.CARE_ABOUT:
                    return careAboutTitles.IndexOf(title);
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