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

    public static List<Designer.CharacterAssemblyPattern> characterAssemblyPatterns;
    public static List<Designer.CollectiveAssemblyPattern> collectiveAssemblyPatterns;
    public static List<Designer.ControllingCharacterAssemblyPattern> controllingCharacterAssemblyPatterns;
    public static List<Designer.MemberCharacterAssemblyPattern> memberCharacterAssemblyPatterns;

    #region Register Assembly Patterns
    public static int RegisterAssemblyPattern(Designer.CharacterAssemblyPattern pattern)
    {
        if (!characterAssemblyPatterns.Contains(pattern))
        {
            characterAssemblyPatterns.Add(pattern);
            return characterAssemblyPatterns.Count;
        }
        else
        {
            return characterAssemblyPatterns.IndexOf(pattern);
        }
    }

    public static int RegisterAssemblyPattern(Designer.CollectiveAssemblyPattern pattern)
    {
        if (!collectiveAssemblyPatterns.Contains(pattern))
        {
            collectiveAssemblyPatterns.Add(pattern);
            return collectiveAssemblyPatterns.Count;
        }
        else
        {
            return collectiveAssemblyPatterns.IndexOf(pattern);
        }
    }

    public static int RegisterAssemblyPattern(Designer.ControllingCharacterAssemblyPattern pattern)
    {
        if (!controllingCharacterAssemblyPatterns.Contains(pattern))
        {
            controllingCharacterAssemblyPatterns.Add(pattern);
            return controllingCharacterAssemblyPatterns.Count;
        }
        else
        {
            return controllingCharacterAssemblyPatterns.IndexOf(pattern);
        }
    }

    public static int RegisterAssemblyPattern(Designer.MemberCharacterAssemblyPattern pattern)
    {
        if (!memberCharacterAssemblyPatterns.Contains(pattern))
        {
            memberCharacterAssemblyPatterns.Add(pattern);
            return memberCharacterAssemblyPatterns.Count;
        }
        else
        {
            return memberCharacterAssemblyPatterns.IndexOf(pattern);
        }
    }
    #endregion

    public static void Initialize()
    {
        characterSituations = new Dictionary<string, CharacterSituationTemplate>();
        characterOptions = new Dictionary<string, CharacterOptionTemplate>();
        characterForecasts = new Dictionary<string, CharacterForecastTemplate>();

        textList = new Dictionary<string, List<string>>();
        numberList = new Dictionary<string, List<float>>();

        characterAssemblyPatterns = new List<Designer.CharacterAssemblyPattern>();
        collectiveAssemblyPatterns = new List<Designer.CollectiveAssemblyPattern>();
        controllingCharacterAssemblyPatterns = new List<Designer.ControllingCharacterAssemblyPattern>();
        memberCharacterAssemblyPatterns = new List<Designer.MemberCharacterAssemblyPattern>();
    }
}
