using System;
using System.Collections.Generic;
using System.Text;





// handles in-game entity templates
namespace C
{
    #region TEMPLATE CLASSES
    class BaseSituation
    {
        // code here
    }

    class BaseOption
    {
        // code here
    }
    #endregion
    
    #region CATALOGUES
    public static class PersonProfileCatalogue
    {
        static Dictionary<string, BaseSituation> baseSituations;
        public static void SetupBaseSituation() { }
        public static E.Situation GetSituation() { return null; }

        static Dictionary<string, BaseOption> baseOptions;
        public static void SetupBaseOption() { }
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