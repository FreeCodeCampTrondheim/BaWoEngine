using System;
using System.Collections.Generic;
using System.Text;





// where classes for in-game entities are defined
namespace E
{
    public class BaseEntity
    {
        public ulong id;
        public string name;
        public bool isAliveOrActive;

        public virtual void Update(DateTime d) { }
    }

    #region CHARACTER CLASSES
    // all relationless data about character
    public class Character : BaseEntity
    {
        public PersonalInformation personalInformation;

        public BiologicalHeritage biologicalHeritage;
        public SocialHeritage socialHeritage;

        public SituationManager situationManager;
        public OptionsManager optionManager;

        public Emotion emotion;
        public MentalFocus mentalFocus;

        public void Update(DateTime d)
        {
            personalInformation.Update(d);
            situationManager.Update(d);
            optionManager.Update(d);
            emotion.Update(d);
            mentalFocus.Update(d);
        }
    }

    // formal data about the character
    public class PersonalInformation
    {
        public void Update(DateTime d)
        {
            // code here
        }
    }

    // constant base stats and modifiers for character based on biological heritage
    public class BiologicalHeritage { }

    // constant base stats and modifiers for character based on social heritage
    public class SocialHeritage { }

    // all situations and all methods for their data
    public class SituationManager
    {
        public void Update(DateTime d)
        {
            // code here
        }

        List<Situation> currentSituations;
        List<Situation> latestSituations;   // used for smaller iterations
    }

    // all data about a situation
    public class Situation : BaseEntity
    {
        string description;             // all hash tags with numbers are replaced by the corresponding entity reference from list
        public void GetDescription()
        {
            string result = description;
            for (int num = 0; num < entityReferences.Count; num++)
            {
                result.Replace("#" + num, DataBank.entities[entityReferences[num]].name);
            }
        }

        public void Update(DateTime d)
        {
            // code here
        }

        List<ulong> entityReferences;

        List<string> optionTags;        // identifies what tags an option must have to use this situation
        List<string> situationTags;     // identifies what type of situation this is
    }

    // all options and all methods for their data
    public class OptionsManager
    {
        public void Update(DateTime d)
        {
            // code here
        }

        List<Option> availableOptions;
    }

    // all data about an option
    public class Option
    {
        ulong id;
        string title;
        string description;

        List<string> optionTags;        // identifies what tags a situation must have to be included in this option
    }

    // all emotions and all methods for their data
    public class Emotion
    {
        public void Update(DateTime d)
        {
            // code here
        }
    }

    // all mental focus and all methods for their data
    public class MentalFocus
    {
        public void Update(DateTime d)
        {
            // code here
        }
    }
    
    #endregion

    #region ORGANIZATION CLASSES
    // all relationless data about organization
    public class Organization : BaseEntity
    {

    }

    #endregion

    #region LOCATION CLASSES
    // all relationless data about location
    public class Location : BaseEntity { }

    #endregion
}