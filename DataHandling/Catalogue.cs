using System.Collections.Generic;






// handles in-game entity templates
public static class Catalogue
{
    #region TEMPLATE CLASSES
    public class SituationTemplate
    {
        public List<string> tags;
        public Dictionary<string, uint> valueTags;

        // code here
    }

    public class OptionTemplate
    {
        public string moduleType;

        public uint baseCost;
        public List<string> typeTags;
        public Dictionary<string, uint> valueTags;

        // more code here
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