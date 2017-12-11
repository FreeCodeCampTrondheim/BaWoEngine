using System.Collections.Generic;
using Newtonsoft.Json;





// handles in-game entity templates
public static class Catalogue
{
    

    #region TEMPLATE CLASSES
    public abstract class BaseTemplate
    {
        uint id;
    }

    public class SituationTemplate : BaseTemplate
    {
        string title;

        /*
            REFERENCES IN DESCRIPTION:
            @char123 where "123" is some number references a character in the DataBank
            @org123 where "123" is some number references an organization in the DataBank
            @loc123 where "123" is some number references a location in the DataBank
        */
        string description;
        
        List<Dictionary<string, Dictionary<string, int>>> considerations
            = new List<Dictionary<string, Dictionary<string, int>>>();

        List<string>                textStats = new List<string>();
        Dictionary<string, uint>    integerStats = new Dictionary<string, uint>();
        Dictionary<string, float>   floatStats = new Dictionary<string, float>();

        /*
        #### Can launch at any tick
        Object arrays with specified key-value pairs:
        1. launchesSituations[] -> situation string ->
          * textStatRequirements[] ->
            * tag string
          * integerStatRequirements[]
            * tag string -> size int
          * floatStatRequirements[]
            * tag string -> size float
          * entityIndexMap[] -> sourceIndex int, targetIndex int
          * used to refer to situations launched upon certain conditions met,
            each launched situation can have an array of forwarded entity
            references if desired, kind-of like parameters in a constructors,
            defining the new situation as derived from the perished one,
            however any left-out index references are still filled in during
            personalization in Generator.cs
        2. launchesOptions[] -> option string ->
          * textStatRequirements[] ->
            * tag string
          * integerStatRequirements[]
            * tag string -> size int
          * floatStatRequirements[]
            * tag string -> size float
          * entityIndexMap[] -> sourceIndex int, targetIndex int
          * used same as above but for options
        3. launchesForecasts[] -> forecast string ->
          * textStatRequirements[] ->
            * tag string
          * integerStatRequirements[]
            * tag string -> size int
          * floatStatRequirements[]
            * tag string -> size float
          * entityIndexMap[] -> sourceIndex int, targetIndex int
          * used same as above but for forecasts

        ### Data and functionality not defined in JSON
        1. about[]
          * used to make a situation be about one or entities
        */
    }

    public class OptionTemplate : BaseTemplate
    {
        // code here        
    }

    public class ForecastTemplate : BaseTemplate
    {
        // code here
    }
    #endregion

    #region CATALOGUES
    public static Dictionary<string, SituationTemplate> situationsTemplates
        = new Dictionary<string, SituationTemplate>();

    public static Dictionary<string, OptionTemplate> optionTemplates
        = new Dictionary<string, OptionTemplate>();

    public static Dictionary<string, ForecastTemplate> forecastTemplates
        = new Dictionary<string, ForecastTemplate>();
    #endregion
}

/*  NOTES:
    Remember to store all valueTag values here, 
    so they only need to be stored once, and can
    be fetched directly from the Catalogue using
    the tag as a value
*/ 