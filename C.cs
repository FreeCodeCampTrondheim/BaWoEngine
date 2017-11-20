using System;
using System.Collections.Generic;
using System.Text;





// handles in-game entity templates
namespace C
{
    #region TEMPLATE CLASSES
    public class SituationTemplate
    {
        // code here
    }

    public class OptionTemplate
    {
        // code here
    }
    #endregion

    #region CATALOGUES
    public static class PersonProfileCatalogue
    {
        static Dictionary<string, SituationTemplate> situationTemplates;
        public static void SetupSituationTemplates() { }
        public static E.Situation GetSituation() { return null; }

        static Dictionary<string, OptionTemplate> optionTemplates;
        public static void SetupOptionTemplates() { }
        public static E.Option GetOption() { return null; }

        // code here
    }

    public static class BiologyCatalogue
    {
        // code here
    }

    public static class SocialLifeCatalogue
    {
        // code here
    }

    public static class EmotionsCatalogue
    {
        // code here
    }

    public static class MentalFocusCatalogue
    {
        // code here
    }
    #endregion
}