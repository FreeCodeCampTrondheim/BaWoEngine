using System;
using System.Collections.Generic;
using System.Text;





// where in-game entity classes are defined
namespace E
{
    #region INTERFACES AND BASE CLASSES
    // declares that the entity or module should be updateable
    interface IUpdateAble
    {
        void Update(DateTime d);
    }

    // data and methods that all entities must have
    public class BaseEntity
    {
        public ulong id;
        public string name;
        public bool isAliveOrActive;
    }

    // data and methods that all modules must have
    public class BaseModule
    {
        // figure out necessary variables and methods
    }

    // data and methods for unit data, i.e. single character
    public class DataModule : BaseModule
    {
        // figure out necessary variables and methods
    }

    // data and methods for aggregate unit data, i.e. characters of an organization or location
    public class StatisticalDataModule : BaseModule
    {
        // figure out necessary variables and methods
    }
    #endregion

    #region CHARACTER CLASSES
    // all relationless data about character
    public class Character : BaseEntity
    {
        public Modules.PersonProfile personProfile;

        public Modules.Biology biology;
        public Modules.SocialLife socialLife;

        public Modules.Emotions emotions;
        public Modules.MentalFocus mentalFocus;

        public void Update(DateTime d)
        {
            personProfile.Update(d);
            biology.Update(d);
            socialLife.Update(d);
            emotions.Update(d);
            mentalFocus.Update(d);
        }
    }

    // all data about a situation
    public class Situation : BaseEntity
    {
        public void Update(DateTime d)
        {
            // code here
        }
    }

    // all data about an option
    public class Option
    {
        ulong id;
        string title;
        string description;

        List<string> optionTags;        // identifies what tags a situation must have to be included in this option
    }
    #endregion

    namespace Modules
    {
        #region CHARACTER MODULES
        // all personal information and all methods for their data
        public class PersonProfile : DataModule, IUpdateAble, AI.IConsiderable
        {
            public void Update(DateTime d)
            {
                // code here
            }
        }

        // all biological situations and all methods for their data
        public class Biology : DataModule, IUpdateAble, AI.IConsiderable
        {
            public void Update(DateTime d)
            {
                // code here
            }
        }

        // all social situations and all methods for their data
        public class SocialLife : DataModule, IUpdateAble, AI.IConsiderable
        {
            public void Update(DateTime d)
            {
                // code here
            }
        }

        // all opinions and all methods for their data
        public class Opinions : DataModule, IUpdateAble, AI.IConsiderable
        {
            public void Update(DateTime d)
            {
                // code here
            }
        }

        // all emotions and all methods for their data
        public class Emotions : DataModule, IUpdateAble, AI.IConsiderable
        {
            public void Update(DateTime d)
            {
                // code here
            }
        }

        // all mental focus and all methods for their data
        public class MentalFocus : DataModule, IUpdateAble, AI.IConsiderable
        {
            public void Update(DateTime d)
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
    public class Organization : BaseEntity, IUpdateAble
    {
        public void Update(DateTime d)
        {
            // update modules
        }
    }

    #endregion

    #region LOCATION CLASSES
    // all relationless data about location
    public class Location : BaseEntity, IUpdateAble
    {
        public void Update(DateTime d)
        {
            // update modules
        }
    }

    #endregion
}