using System.Collections.Generic;
using Newtonsoft.Json;





// handles in-game entity templates
namespace Catalogue
{
    public static class Character
    {
        #region BASE TEMPLATE
        public abstract class BaseTemplate
        {
            // uniquely identifies template
            string title;

            /*
                REFERENCES IN DESCRIPTION:
                @char0 where "0" is some index in the about
                @org0 - as above but for organizations
                @loc0 - as above but for locations
                i.e. "@char1 hates eating muffins at @org0"
            */
            string description;

            /*
                The following three dictionaries are used to refer to 
                situations/options/forecasts launched upon certain requirements
                met. Each can have an array of forwarded entity references if 
                desired, kind-of like parameters in a constructors, defining 
                the new situation/options/forecasts as derived from this one.
                Any left-out index references are filled in during personalization
                in Generator.cs
            */
            Dictionary<string, LaunchRequirements> launchesSituations;
            Dictionary<string, LaunchRequirements> launchesOptions;
            Dictionary<string, LaunchRequirements> launchesForecasts;
        }

        public struct Care
        {
            // descriptive text for how the character cares,
            // typically includes a verb, i.e. "Enjoyed Dining At",
            // and should be written so that the name of the target
            // can be appended at the end
            public string tag;

            public string target;
            public int emphasis;
        }

        public class LaunchRequirements
        {
            public List<string> textStatRequirements;
            public Dictionary<string, int> intStatRequirements;
            public Dictionary<string, float> floatStatRequirements;

            // maps entity indexes from current "about" in 
            // situation/option/forecast to launched one
            public Dictionary<uint, uint> aboutIndexMap;
        }
        #endregion

        #region TEMPLATE CLASSES

        public class SituationTemplate : BaseTemplate
        {
            // used to make judgement and central in AI.cs, the target 
            // string is filled during personalization in Generator.cs
            public List<Care> cares = new List<Care>();

            /*
                can represent boolean character statistics, the existence
                of the tag equals true, while its absence equals false,
                but counting the number of occurences of the tag can 
                also be useful, though each situation can only grant
                one occurence of the tag so it's a count of sources
            */
            public List<string> textStats = new List<string>();

            // represents integer character statistics
            public Dictionary<string, int> intStats = new Dictionary<string, int>();

            // represents decimal character statistics
            public Dictionary<string, float> floatStats = new Dictionary<string, float>();
        }

        public class OptionTemplate : BaseTemplate
        {
            public uint baseWillpowerCost;

            // used to calculate final willpower cost
            public List<string> relevantCares;
        }

        public class ForecastTemplate : BaseTemplate
        {
            // whether this represents good fortune (more than 0)
            // for the character, or negative fortune (less than 0),
            // and if so, by what degree
            int fortune;

            // how likely this is to play out, represented by
            // positive percentage values of 0.0f to 1.0f
            float chanceOfHappening;
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
}