using System;
using System.Collections.Generic;
using System.Text;





// where in-game entity classes are defined
namespace Entity
{
    #region INTERFACES AND BASE CLASSES
    // data and methods that all entities must have
    public abstract class BaseEntity
    {
        // ran through DataBank.cs -> Entity
        public abstract void UpdateTime(DateTime d);
    }

    interface IDescribeable
    {
        string GetDescription();
    }
    #endregion

    #region CHARACTER CLASSES
    // all data about a character
    public class Character : BaseEntity
    {
        public uint willpowerPoints = 0;
        public Dictionary<string, Situation> situations;
        public Dictionary<string, Option> options;
        public Dictionary<string, Forecast> forecasts;

        #region CHARACTER INTEGER STATS
        Dictionary<string, int> characterIntStats =
            new Dictionary<string, int>();

        public int GetIntStatSum(string stat)
        {
            // negative stat sums are ignored upon retrieval because they
            // have no meaning, however they are stored so that adding and
            // subtracting on collection is never messed up
            if (characterIntStats.ContainsKey(stat) && characterIntStats[stat] > 0) return characterIntStats[stat];
            else return 0;
        }

        public void AddIntStat(string stat, int valueFromSituation)
        {
            if (characterIntStats.ContainsKey(stat))
                characterIntStats[stat] += valueFromSituation;
            else characterIntStats[stat] = valueFromSituation;
        }

        public void RemoveIntStat(string stat, int valueFromSituation)
        {
            if (characterIntStats.ContainsKey(stat) && characterIntStats[stat] > 0)
                characterIntStats[stat] -= valueFromSituation;
        }

        public Dictionary<string, int>.Enumerator GetIntStatIterator()
        {
            return characterIntStats.GetEnumerator();
        }
        #endregion

        #region CHARACTER FLOAT STATS
        Dictionary<string, float> characterFloatStats =
            new Dictionary<string, float>();

        public float GetFloatStatSum(string stat)
        {
            // negative stat sums are ignored upon retrieval because they
            // have no meaning, however they are stored so that adding and
            // subtracting on collection is never messed up
            if (characterFloatStats.ContainsKey(stat) && characterFloatStats[stat] > 0) return characterFloatStats[stat];
            else return 0;
        }

        public void AddFloatStat(string stat, float valueFromSituation)
        {
            if (characterFloatStats.ContainsKey(stat))
                characterFloatStats[stat] += valueFromSituation;
            else characterFloatStats[stat] = valueFromSituation;
        }

        public void RemoveFloatStat(string stat, float valueFromSituation)
        {
            if (characterFloatStats.ContainsKey(stat) && characterFloatStats[stat] > 0)
                characterFloatStats[stat] -= valueFromSituation;
        }

        public Dictionary<string, float>.Enumerator GetFloatStatIterator()
        {
            return characterFloatStats.GetEnumerator();
        }
        #endregion

        #region CHARACTER TAG OCCURENCES
        // contains records of all value tags from modules, 
        // indicating the social and physical state of the character,
        // with string=tag and uint=number of occurences
        Dictionary<string, uint> tagsOccurences =
            new Dictionary<string, uint>();

        public bool HasTag(string tag)
        {
            if (tagsOccurences.ContainsKey(tag) && tagsOccurences[tag] > 0) return true;
            else return false;
        }

        public uint GetTagCount(string tag)
        {
            if (tagsOccurences.ContainsKey(tag)) return tagsOccurences[tag];
            else return 0;
        }

        public void AddTag(string tag)
        {
            if (tagsOccurences.ContainsKey(tag)) tagsOccurences[tag]++;
            else tagsOccurences[tag] = 1;
        }

        public void RemoveTag(string tag)
        {
            if (tagsOccurences.ContainsKey(tag) && tagsOccurences[tag] > 0) tagsOccurences[tag]--;
            else tagsOccurences[tag] = 0;
        }

        public Dictionary<string, uint>.Enumerator GetTagIterator()
        {
            return tagsOccurences.GetEnumerator();
        }
        #endregion

        #region CHARACTER VALUE TAG OCCURENCES
        // contains records of all value tags from modules,
        // indicating the mental state of the character,
        // with string=tag and uint=combined value of tags
        Dictionary<string, uint> valueTagsOccurences =
            new Dictionary<string, uint>();

        public bool HasValueTag(string valueTag)
        {
            if (valueTagsOccurences.ContainsKey(valueTag) && valueTagsOccurences[valueTag] > 0) return true;
            else return false;
        }

        public uint GetValueTagSum(string valueTag)
        {
            if (valueTagsOccurences.ContainsKey(valueTag)) return valueTagsOccurences[valueTag];
            else return 0;
        }

        public void AddValueTag(string valueTag, uint valueFromSituation)
        {
            if (valueTagsOccurences.ContainsKey(valueTag))
                valueTagsOccurences[valueTag] += valueFromSituation;
            else valueTagsOccurences[valueTag] = valueFromSituation;
        }

        public void RemoveValueTag(string valueTag, uint valueFromSituation)
        {
            if (valueTagsOccurences.ContainsKey(valueTag) && valueTagsOccurences[valueTag] > 0)
                valueTagsOccurences[valueTag] -= valueFromSituation;
        }

        public Dictionary<string, uint>.Enumerator GetValueTagIterator()
        {
            return valueTagsOccurences.GetEnumerator();
        }
        #endregion

        public override void UpdateTime(DateTime d)
        {
            // delete expired countdown situations,
            // add time to stopwatch situations
        }
    }

    // all data and methods for a situation
    public class Situation : IDescribeable
    {
        public uint id;
        public Catalogue.SituationTemplate template;

        public string GetDescription()
        {
            // code here

            return null;
        }

        public void Terminated()
        {
            // code here
        }

        public override string ToString()
        {
            // code here

            return null;
        }
    }

    // all data and methods for an option
    public class Option : IDescribeable
    {
        public uint id;
        public Catalogue.OptionTemplate template;

        public string GetDescription()
        {
            // code here

            return null;
        }

        public void Choose(Character c)
        {
            // code here
        }
    }

    // all data and methods for an option
    public class Forecast : IDescribeable
    {
        public uint id;
        public Catalogue.ForecastTemplate template;

        public string GetDescription()
        {
            // code here

            return null;
        }

        public void PlayOut(Character c)
        {
            // code here
        }
    }
    #endregion

    #region ORGANIZATION CLASSES
    // all relationless data about organization
    public class Organization : BaseEntity
    {
        public override void UpdateTime(DateTime d)
        {
            // update modules
        }
    }
    #endregion

    #region LOCATION CLASSES
    // all relationless data about location
    public class Location : BaseEntity
    {
        public override void UpdateTime(DateTime d)
        {
            // update modules
        }
    }
    #endregion
}