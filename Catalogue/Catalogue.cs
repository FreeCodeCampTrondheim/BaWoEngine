using System;
using System.Collections.Generic;







public static partial class Catalogue
{
    // for access to simple character entities by title
    public static List<CharacterSituationSharedData> characterSituations;
    public static List<CharacterOptionSharedData> characterOptions;
    public static List<CharacterForecastSharedData> characterForecasts;

    // for access to simple collective entities by title
    public static List<CollectiveSituationSharedData> collectiveSituations;
    public static List<CollectiveOptionSharedData> collectiveOptions;
    public static List<CollectiveForecastSharedData> collectiveForecasts;

    // for accessing random allowed values
    static List<string[]> textEnums;
    static List<double[]> numberEnums;

    public static int AddTextEnums(string[] newTextAlternatives, int existingEnumIndex = -1)
    {
        if (existingEnumIndex < 0)
        {
            textEnums.Add(newTextAlternatives);
            return textEnums.Count - 1;
        }

        // combine existing array with new array
        else
        {
            int sizeExisting = textEnums[existingEnumIndex].Length;
            int sizeNew = newTextAlternatives.Length;
            int combinedSize = sizeExisting + sizeNew;

            string[] temp = new string[combinedSize];
            Array.Copy(textEnums[existingEnumIndex], temp, sizeExisting);
            Array.Copy(newTextAlternatives, 0, temp, sizeExisting, sizeNew);

            textEnums[existingEnumIndex] = temp;
            return existingEnumIndex;
        }
    }

    public static int AddNumberEnums(double[] newNumberAlternatives, int existingEnumIndex = -1)
    {
        if (existingEnumIndex < 0)
        {
            numberEnums.Add(newNumberAlternatives);
            return numberEnums.Count - 1;
        }

        // combine existing array with new array
        else
        {
            int sizeExisting = textEnums[existingEnumIndex].Length;
            int sizeNew = newNumberAlternatives.Length;
            int combinedSize = sizeExisting + sizeNew;

            string[] temp = new string[combinedSize];
            Array.Copy(textEnums[existingEnumIndex], temp, sizeExisting);
            Array.Copy(newNumberAlternatives, 0, temp, sizeExisting, sizeNew);

            textEnums[existingEnumIndex] = temp;
            return existingEnumIndex;
        }
    }

    // for accessing different patterns for use in generation
    public static List<Designer.CharacterAssemblyPattern> characterAssemblyPatterns;
    public static List<Designer.CollectiveAssemblyPattern> collectiveAssemblyPatterns;
    public static List<Designer.ParticipationAssemblyPattern> controllingCharacterAssemblyPatterns;
    public static List<Designer.ParticipationAssemblyPattern> memberCharacterAssemblyPatterns;

    public static void Initialize()
    {
        characterSituations = new List<CharacterSituationSharedData>();
        characterOptions = new List<CharacterOptionSharedData>();
        characterForecasts = new List<CharacterForecastSharedData>();

        textEnums = new List<string[]>();
        numberEnums = new List<double[]>();

        characterAssemblyPatterns = new List<Designer.CharacterAssemblyPattern>();
        collectiveAssemblyPatterns = new List<Designer.CollectiveAssemblyPattern>();
        controllingCharacterAssemblyPatterns = new List<Designer.ParticipationAssemblyPattern>();
        memberCharacterAssemblyPatterns = new List<Designer.ParticipationAssemblyPattern>();
    }
}
