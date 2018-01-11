using System;
using System.Collections.Generic;






public static partial class Catalogue
{
    // for access to simple character entities by title
    public static Dictionary<string, CharacterSituationTemplate> characterSituations;
    public static Dictionary<string, CharacterOptionTemplate> characterOptions;
    public static Dictionary<string, CharacterForecastTemplate> characterForecasts;

    // for access to simple collective entities by title
    public static Dictionary<string, CollectiveSituationTemplate> collectiveSituations;
    public static Dictionary<string, CollectiveOptionTemplate> collectiveOptions;
    public static Dictionary<string, CollectiveForecastTemplate> collectiveForecasts;

    // for accessing random allowed values
    public static Dictionary<string, List<string>> textList;
    public static Dictionary<string, List<float>> numberList;

    public static void Initialize()
    {
        characterSituations = new Dictionary<string, CharacterSituationTemplate>();
        characterOptions = new Dictionary<string, CharacterOptionTemplate>();
        characterForecasts = new Dictionary<string, CharacterForecastTemplate>();

        textList = new Dictionary<string, List<string>>();
        numberList = new Dictionary<string, List<float>>();
    }
}
