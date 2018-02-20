using System;
using System.Collections.Generic;







public static partial class Catalogue
{
    #region Character Simple Entities Shared Data
    // for access to simple character entities by id
    public static List<CharacterSituationSharedData> characterSituations;
    public static List<CharacterOptionSharedData> characterOptions;
    public static List<CharacterForecastSharedData> characterForecasts;
    #endregion

    #region Collective Simple Entities Shared Data
    // for access to simple collective entities by id
    public static List<CollectiveSituationSharedData> collectiveSituations;
    public static List<CollectiveOptionSharedData> collectiveOptions;
    public static List<CollectiveForecastSharedData> collectiveForecasts;
    #endregion

    public static List<CareAbout> careAbouts;

    #region Stat Types
    public static List<string> boolStatIDs;
    public static List<string> textStatIDs;
    public static List<string> baseNumberStatIDs;
    public static List<string> modifyingNumberStatIDs;
    #endregion

    #region Text- and Number Enums
    // for accessing random allowed values
    public static List<string[]> textEnums;
    public static List<double[]> numberEnums;
    #endregion

    #region Assembly Patterns
    // for accessing different patterns for use in generation
    public static List<Designer.CharacterAssemblyPattern> characterAssemblyPatterns;
    public static List<Designer.CollectiveAssemblyPattern> collectiveAssemblyPatterns;
    public static List<Designer.ParticipationAssemblyPattern> controllingCharacterAssemblyPatterns;
    public static List<Designer.ParticipationAssemblyPattern> memberCharacterAssemblyPatterns;
    #endregion

    #region Registration Methods
    // returns -1 if registration failed,
    // else it returns the new resources' id
    public static int RegisterNewSharedDataResource(SimpleEntitySharedData newResource)
    {
        Type check = newResource.GetType();

        if (newResource != null)
        {
            if (check == typeof(CharacterSituationSharedData))
            {
                var r = (CharacterSituationSharedData)newResource;
                characterSituations.Add(r);
                return characterSituations.Count - 1;
            }
            else if (check == typeof(CharacterOptionSharedData))
            {
                var r = (CharacterOptionSharedData)newResource;
                characterOptions.Add(r);
                return characterOptions.Count - 1;
            }
            else if (check == typeof(CharacterForecastSharedData))
            {
                var r = (CharacterForecastSharedData)newResource;
                characterForecasts.Add(r);
                return characterForecasts.Count - 1;
            }
            else if (check == typeof(CollectiveSituationSharedData))
            {
                var r = (CollectiveSituationSharedData)newResource;
                collectiveSituations.Add(r);
                return collectiveSituations.Count - 1;
            }
            else if (check == typeof(CollectiveOptionSharedData))
            {
                var r = (CollectiveOptionSharedData)newResource;
                collectiveOptions.Add(r);
                return collectiveOptions.Count - 1;
            }
            else if (check == typeof(CollectiveForecastSharedData))
            {
                var r = (CollectiveForecastSharedData)newResource;
                collectiveForecasts.Add(r);
                return collectiveForecasts.Count - 1;
            }

            return -1;
        }

        return -1;
    }

    // returns -1 if registration failed,
    // else it returns the new resources' id
    public static int RegisterNewCareAbout(CareAbout newCareAbout)
    {
        careAbouts.Add(newCareAbout);
        return careAbouts.Count - 1;
    }

    // returns -1 if registration failed,
    // else it returns the new resources' id
    public static int RegisterNewStatResource(string title, STAT_RESOURCE typeOfResource)
    {
        if (title != null && title.Length > 0)
        {
            switch (typeOfResource)
            {
                case STAT_RESOURCE.BOOL_STAT:
                    if (boolStatIDs.Contains(title)) return -1;
                    else boolStatIDs.Add(title);
                    return boolStatIDs.Count - 1;
                case STAT_RESOURCE.TEXT_STAT:
                    if (textStatIDs.Contains(title)) return -1;
                    else textStatIDs.Add(title);
                    return textStatIDs.Count - 1;
                case STAT_RESOURCE.BASE_NUMBER_STAT:
                    if (baseNumberStatIDs.Contains(title)) return -1;
                    else baseNumberStatIDs.Add(title);
                    return baseNumberStatIDs.Count - 1;
                case STAT_RESOURCE.MODIFYING_NUMBER_STAT:
                    if (modifyingNumberStatIDs.Contains(title)) return -1;
                    else modifyingNumberStatIDs.Add(title);
                    return modifyingNumberStatIDs.Count - 1;
                default: return -1;
            }
        }

        return -1;
    }

    // returns -1 if registration failed,
    // else it returns the new resources' id
    public static int RegisterNewTextEnums(string[] newTextAlternatives, int existingEnumIndex = -1)
    {
        if (newTextAlternatives == null || newTextAlternatives.Length < 1)
            return -1;

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

    // returns -1 if registration failed,
    // else it returns the new resources' id
    public static int RegisterNewNumberEnums(double[] newNumberAlternatives, int existingEnumIndex = -1)
    {
        if (newNumberAlternatives == null || newNumberAlternatives.Length < 1)
            return -1;

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
    #endregion

    public static void Initialize()
    {
        characterSituations = new List<CharacterSituationSharedData>();
        characterOptions = new List<CharacterOptionSharedData>();
        characterForecasts = new List<CharacterForecastSharedData>();

        collectiveSituations = new List<CollectiveSituationSharedData>();
        collectiveOptions = new List<CollectiveOptionSharedData>();
        collectiveForecasts = new List<CollectiveForecastSharedData>();

        careAboutTypes = new List<CareAbout>();

        boolStatIDs = new List<string>();
        textStatIDs = new List<string>();
        baseNumberStatIDs = new List<string>();
        modifyingNumberStatIDs = new List<string>();

        textEnums = new List<string[]>();
        numberEnums = new List<double[]>();

        characterAssemblyPatterns = new List<Designer.CharacterAssemblyPattern>();
        collectiveAssemblyPatterns = new List<Designer.CollectiveAssemblyPattern>();
        controllingCharacterAssemblyPatterns = new List<Designer.ParticipationAssemblyPattern>();
        memberCharacterAssemblyPatterns = new List<Designer.ParticipationAssemblyPattern>();
    }
}