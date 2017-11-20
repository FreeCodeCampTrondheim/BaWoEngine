using System;
using System.Collections.Generic;
using System.Text;





// handles in-game entity templates and creation
static class Catalogue
{
    #region TEMPLATE CLASSES
    class SituationTemplates
    {
        List<E.Situation> templates;

        public static E.Situation GetRandom() { return null; }

        public static E.Situation GetRandom(List<string> desiredTags) { return null; }
    }

    class OptionTemplates
    {
        List<E.Option> templates;

        public E.Option GetRandom() { return null; }

        public E.Option GetRandom(List<string> desiredTags) { return null; }
    }

    #endregion

    #region CHARACTER GENERATION CLASSES
    class CharacterGenerator
    {
        public E.Character Generate()
        {
            E.Character character = new E.Character();

            character.personalInformation = PersonalInformationGenerator.Generate();

            character.biologicalHeritage = BiologicalHeritageGenerator.Generate();
            character.socialHeritage = SocialHeritageGenerator.Generate();

            character.situationManager = SituationManagerGenerator.Generate();
            character.optionManager = OptionManagerGenerator.Generate();

            character.emotion = EmotionGenerator.Generate();
            character.mentalFocus = MentalFocusGenerator.Generate();

            return character;
        }
    }

    static class PersonalInformationGenerator
    {
        public static E.PersonalInformation Generate() { return null; }
    }

    static class BiologicalHeritageGenerator
    {
        public static E.BiologicalHeritage Generate() { return null; }
    }

    static class SocialHeritageGenerator
    {
        public static E.SocialHeritage Generate() { return null; }
    }

    static class SituationManagerGenerator
    {
        public static E.SituationManager Generate() { return null; }
    }

    static class OptionManagerGenerator
    {
        public static E.OptionsManager Generate() { return null; }
    }

    static class EmotionGenerator
    {
        public static E.Emotion Generate() { return null; }
    }

    static class MentalFocusGenerator
    {
        public static E.MentalFocus Generate() { return null; }
    }

    #endregion

    #region ORGANIZATION GENERATION CLASSES
    public static class OrganizationGenerator
    {
        public static E.Organization GenerateOrganization() { return null; }
    }

    #endregion

    #region LOCATION GENERATION CLASSES
    public static class LocationGenerator
    {
        public static E.Location GenerateLocation() { return null; }
    }

    #endregion
}