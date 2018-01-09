using System;
using System.Collections.Generic;






public static partial class Catalogue
{
    // CHARACTER specific templates and -allowed values
    public static class CharacterTemplating
    {
        // for access to simple entities by title
        public static Dictionary<string, CharacterSituationTemplate>   situations;
        public static Dictionary<string, CharacterOptionTemplate>      options;
        public static Dictionary<string, CharacterForecastTemplate>    forecasts;

        // for accessing random allowed values
        public static Dictionary<string, List<string>>   textList;
        public static Dictionary<string, List<float>>    numberList;

        public static void Initialize()
        {
            situations = new Dictionary<string, CharacterSituationTemplate>();
            options = new Dictionary<string, CharacterOptionTemplate>();
            forecasts = new Dictionary<string, CharacterForecastTemplate>();

            textList = new Dictionary<string, List<string>>();
            numberList = new Dictionary<string, List<float>>();
        }
    }
    
    // COLLECTIVE specific templates and -allowed values
    public static class CollectiveTemplating
    {
        /// for access to simple entities by title
        public static Dictionary<string, CollectiveSituationTemplate> situations;
        public static Dictionary<string, CollectiveOptionTemplate> options;
        public static Dictionary<string, CollectiveForecastTemplate> forecasts;

        // for accessing random allowed values
        public static Dictionary<string, List<string>> textList;
        public static Dictionary<string, List<float>> numberList;

        public static void Initialize()
        {
            situations = new Dictionary<string, CollectiveSituationTemplate>();
            options = new Dictionary<string, CollectiveOptionTemplate>();
            forecasts = new Dictionary<string, CollectiveForecastTemplate>();

            textList = new Dictionary<string, List<string>>();
            numberList = new Dictionary<string, List<float>>();
        }
    }
}
