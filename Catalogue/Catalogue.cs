using System;
using System.Collections.Generic;






public static partial class Catalogue
{
    // for access to simple character entities by title
    public static Dictionary<string, CharacterSituationSharedData> characterSituations;
    public static Dictionary<string, CharacterOptionSharedData> characterOptions;
    public static Dictionary<string, CharacterForecastSharedData> characterForecasts;

    // for access to simple collective entities by title
    public static Dictionary<string, CollectiveSituationSharedData> collectiveSituations;
    public static Dictionary<string, CollectiveOptionSharedData> collectiveOptions;
    public static Dictionary<string, CollectiveForecastSharedData> collectiveForecasts;

    // for accessing random allowed values
    public static Dictionary<string, List<string>> textList;
    public static Dictionary<string, List<float>> numberList;

    public static List<Designer.CharacterAssemblyPattern> characterAssemblyPatterns;
    public static List<Designer.CollectiveAssemblyPattern> collectiveAssemblyPatterns;
    public static List<Designer.ControllingCharacterAssemblyPattern> controllingCharacterAssemblyPatterns;
    public static List<Designer.MemberCharacterAssemblyPattern> memberCharacterAssemblyPatterns;

    public static void Initialize()
    {
        characterSituations = new Dictionary<string, CharacterSituationSharedData>();
        characterOptions = new Dictionary<string, CharacterOptionSharedData>();
        characterForecasts = new Dictionary<string, CharacterForecastSharedData>();

        textList = new Dictionary<string, List<string>>();
        numberList = new Dictionary<string, List<float>>();

        characterAssemblyPatterns = new List<Designer.CharacterAssemblyPattern>();
        collectiveAssemblyPatterns = new List<Designer.CollectiveAssemblyPattern>();
        controllingCharacterAssemblyPatterns = new List<Designer.ControllingCharacterAssemblyPattern>();
        memberCharacterAssemblyPatterns = new List<Designer.MemberCharacterAssemblyPattern>();
    }
}
