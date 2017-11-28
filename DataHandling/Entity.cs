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
        public ulong id;
        public abstract void UpdateTime(DateTime d);            // ran through DataBank.cs -> Entity
    }

    // data and methods that all modules must have
    public abstract class CharacterModule
    {
        List<Situation> currentSituations;
        List<Option> currentOptions;

        public abstract void UpdateTime(DateTime d);            // ran through DataBank.cs -> Character -> Module
        public abstract void UpdateBehaviour(Character c);      // ran through AI.cs -> Character -> Module
        public abstract void UpdateLuck(Character c);           // ran through Fate.cs -> Character -> Module

        // figure out necessary variables and methods
    }
    #endregion

    #region CHARACTER CLASSES
    // all data about a character
    public class Character : BaseEntity
    {
        public uint willpowerPoints = 0;

        #region CHARACTER STATS
        Dictionary<string, int> characterStats;

        public int GetStatSum(string stat)
        {
            if (characterStats.ContainsKey(stat)) return characterStats[stat];
            else return 0;
        }

        public void AddStat(string stat, int valueFromSituation)
        {
            if (characterStats.ContainsKey(stat))
                characterStats[stat] += valueFromSituation;
            else characterStats[stat] = valueFromSituation;
        }

        public void RemoveStat(string stat, int valueFromSituation)
        {
            if (characterStats.ContainsKey(stat) && characterStats[stat] > 0)
                characterStats[stat] -= valueFromSituation;
        }

        public Dictionary<string, int>.Enumerator GetStatIterator()
        {
            return characterStats.GetEnumerator();
        }
        #endregion

        #region CHARACTER TAG OCCURENCES
        // contains records of all value tags from modules, 
        // indicating the social and physical state of the character,
        // with string=tag and uint=number of occurences
        Dictionary<string, uint> tagsOccurences;

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
        Dictionary<string, uint> valueTagsOccurences;

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

        public Modules.PersonProfile personProfile;
        public Modules.Biology biology;

        public Modules.SocialLife socialLife;
        public Modules.Opinions opinions;

        public Modules.Emotions emotions;
        public Modules.MentalFocus mentalFocus;

        public override void UpdateTime(DateTime d)
        {
            personProfile.UpdateTime(d);
            biology.UpdateTime(d);

            socialLife.UpdateTime(d);
            opinions.UpdateTime(d);

            emotions.UpdateTime(d);
            mentalFocus.UpdateTime(d);
        }

        public void UpdateBehaviour()
        {
            personProfile.UpdateBehaviour(this);
            biology.UpdateBehaviour(this);

            socialLife.UpdateBehaviour(this);
            opinions.UpdateBehaviour(this);

            emotions.UpdateBehaviour(this);
            mentalFocus.UpdateBehaviour(this);
        }

        public void UpdateLuck()
        {
            personProfile.UpdateLuck(this);
            biology.UpdateLuck(this);

            socialLife.UpdateLuck(this);
            opinions.UpdateLuck(this);

            emotions.UpdateLuck(this);
            mentalFocus.UpdateLuck(this);
        }
    }

    // all data and methods for a situation
    public class Situation
    {
        public ulong id;
        public Catalogue.SituationTemplate template;

        public void Terminated()
        {
            // code here
        }
    }

    // all data and methods for an option
    public class Option
    {
        public ulong id;
        public Catalogue.OptionTemplate template;

        public void Choose(Character c)
        {
            // code here
        }
    }
    #endregion

    // modules extending character situations, options, data and how to handle them
    namespace Modules
    {
        #region CORE CHARACTER MODULES
        // all personal information and all methods for their data
        public class PersonProfile : CharacterModule
        {
            public override void UpdateTime(DateTime d)
            {
                // code here
            }

            public override void UpdateBehaviour(Character c)
            {
                // code here
            }

            public override void UpdateLuck(Character c)
            {
                // code here
            }
        }

        // all emotions and all methods for their data
        public class Emotions : CharacterModule
        {
            public override void UpdateTime(DateTime d)
            {
                // code here
            }

            public override void UpdateBehaviour(Character c)
            {
                // code here
            }

            public override void UpdateLuck(Character c)
            {
                // code here
            }
        }

        // all mental focus and all methods for their data
        public class MentalFocus : CharacterModule
        {
            public override void UpdateTime(DateTime d)
            {
                // code here
            }

            public override void UpdateBehaviour(Character c)
            {
                // code here
            }

            public override void UpdateLuck(Character c)
            {
                // code here
            }
        }
        #endregion

        #region EXTENDING CHARACTER MODULES
        // all biological situations and all methods for their data
        public class Biology : CharacterModule
        {
            public override void UpdateTime(DateTime d)
            {
                // code here
            }

            public override void UpdateBehaviour(Character c)
            {
                // code here
            }

            public override void UpdateLuck(Character c)
            {
                // code here
            }
        }

        // all social situations and all methods for their data
        public class SocialLife : CharacterModule
        {
            public override void UpdateTime(DateTime d)
            {
                // code here
            }

            public override void UpdateBehaviour(Character c)
            {
                // code here
            }

            public override void UpdateLuck(Character c)
            {
                // code here
            }
        }

        // all opinions and all methods for their data
        public class Opinions : CharacterModule
        {
            public override void UpdateTime(DateTime d)
            {
                // code here
            }

            public override void UpdateBehaviour(Character c)
            {
                // code here
            }

            public override void UpdateLuck(Character c)
            {
                // code here
            }
        }
        #endregion

        #region ORGANIZATION MODULES
        // modules here
        #endregion

        #region LOCATION MODULES
        // modules here
        #endregion
    }

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