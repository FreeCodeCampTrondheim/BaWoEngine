using System;
using System.Collections.Generic;
using System.Text;





// where in-game entity classes are defined
namespace E
{
    #region INTERFACES AND BASE CLASSES
    // declares that the entity or module should be updateable
    interface IUpdateable
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

    // data and methods for unit data module, i.e. single character
    public class DataModule : BaseModule
    {
        // figure out necessary variables and methods
    }

    // data and methods for aggregate unit data module, i.e. characters of an organization or location
    public class StatisticalDataModule : BaseModule
    {
        // figure out necessary variables and methods
    }
    #endregion

    #region CHARACTER CLASSES
    // all data about a character
    public class Character : BaseEntity, IUpdateable
    {
        public Modules.PersonProfile personProfile;
        public Modules.Biology biology;

        public Modules.SocialLife socialLife;
        public Modules.Opinions opinions;

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
    public class Situation : BaseEntity, IUpdateable
    {
        public C.SituationTemplate template;

        public void Update(DateTime d)
        {
            // code here
        }
    }

    // all data about an option
    public class Option : BaseEntity, IUpdateable
    {
        public C.OptionTemplate template;

        public void Update(DateTime d)
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
        public class PersonProfile : DataModule, IUpdateable
        {
            AI.Considerator considerator = new AI.Considerator();

            public void Update(DateTime d)
            {
                // code here
            }
        }

        // all emotions and all methods for their data
        public class Emotions : DataModule, IUpdateable, AI.IReasoner
        {
            public void Update(DateTime d)
            {
                // code here
            }

            public float Reason(E.Option o) { return 0; }
        }

        // all mental focus and all methods for their data
        public class MentalFocus : DataModule, IUpdateable, AI.IReasoner
        {
            public void Update(DateTime d)
            {
                // code here
            }

            public float Reason(E.Option o) { return 0; }
        }
        #endregion

        #region EXTENDING CHARACTER MODULES
        // all biological situations and all methods for their data
        public class Biology : DataModule, IUpdateable
        {
            AI.Considerator considerator = new AI.Considerator();

            public void Update(DateTime d)
            {
                // code here
            }
        }

        // all social situations and all methods for their data
        public class SocialLife : DataModule, IUpdateable
        {
            AI.Considerator considerator = new AI.Considerator();

            public void Update(DateTime d)
            {
                // code here
            }
        }

        // all opinions and all methods for their data
        public class Opinions : DataModule, IUpdateable
        {
            AI.Considerator considerator = new AI.Considerator();

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
    public class Organization : BaseEntity, IUpdateable
    {
        public void Update(DateTime d)
        {
            // update modules
        }
    }

    #endregion

    #region LOCATION CLASSES
    // all relationless data about location
    public class Location : BaseEntity, IUpdateable
    {
        public void Update(DateTime d)
        {
            // update modules
        }
    }

    #endregion
}