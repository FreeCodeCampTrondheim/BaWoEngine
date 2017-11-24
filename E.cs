using System;
using System.Collections.Generic;
using System.Text;





// where in-game entity classes are defined
namespace E
{
    #region INTERFACES AND BASE CLASSES
    // data and methods that all entities must have
    public abstract class BaseEntity
    {
        public ulong id;
        public abstract void UpdateTime(DateTime d);    // ran through DataBank.cs -> Entity
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
        #region TAG COUNTER
        Dictionary<string, uint> tagCounter;

        public bool HasTag(string tag)
        {
            if (tagCounter.ContainsKey(tag) && tagCounter[tag] > 0)
            {
                return true;
            }
            else return false;
        }

        public uint GetTagCount(string tag)
        {
            if (tagCounter.ContainsKey(tag)) return tagCounter[tag];
            else return 0;
        }

        public void AddTag(string tag)
        {
            if (tagCounter.ContainsKey(tag)) tagCounter[tag]++;
            else tagCounter[tag] = 1;
        }

        public void RemoveTag(string tag)
        {
            if (tagCounter.ContainsKey(tag) && tagCounter[tag] > 0) tagCounter[tag]--;
            else tagCounter[tag] = 0;
        }

        public Dictionary<string, uint>.Enumerator GetTagIterator()
        {
            return tagCounter.GetEnumerator();
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
        public C.SituationTemplate template;

        public void Terminated()
        {
            // code here
        }
    }

    // all data and methods for an option
    public class Option
    {
        public ulong id;
        public C.OptionTemplate template;

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