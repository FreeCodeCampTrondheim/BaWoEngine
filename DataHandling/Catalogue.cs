using System.Collections.Generic;






// handles in-game entity templates
public static class Catalogue
{
    #region TEMPLATE CLASSES
    public class SituationTemplate
    {
        public List<string> tags;
        public Dictionary<string, uint> valueTags;
    }

    public class OptionTemplate
    {
        public string moduleType;

        public uint baseCost;
        public List<string> typeTags;
        public Dictionary<string, uint> valueTags;
    }

    public class ForecastTemplate
    {
        public string moduleType;

        public uint probabilityWeight;
        public List<string> typeTags;
        public Dictionary<string, uint> valueTags;
    }
    #endregion

    #region CATALOGUES
    public static class PersonProfile
    {
        static Dictionary<string, SituationTemplate> situationTemplates;
        public static void SetupSituationTemplates() { }

        static Dictionary<string, OptionTemplate> optionTemplates;
        public static void SetupOptionTemplates() { }

        // more code here
    }

    public static class Biology
    {
        // code here
    }

    public static class SocialLife
    {
        // code here
    }

    public static class Opinions
    {
        // code here
    }

    public static class Emotions
    {
        // code here
    }

    public static class MentalFocus
    {
        // code here
    }
    #endregion
}

/*  NOTES:
    Remember to store all valueTag values here, 
    so they only need to be stored once, and can
    be fetched directly from the Catalogue using
    the tag as a value
*/ 