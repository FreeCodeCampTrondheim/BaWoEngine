using System;
using System.Collections.Generic;
using System.Text;





// handles in-game entity templates and creation
class Catalogue
{
    public Catalogue(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    #region TEMPLATE CLASSES
    class SituationTemplates
    {
        List<E.Situation> templates;

        public E.Situation GetRandom()
        {
            // code here
        }

        public E.Situation GetRandom(List<string> desiredTags)
        {
            // code here
        }
    }

    class OptionTemplates
    {
        List<E.Option> templates;

        public E.Option GetRandom()
        {
            // code here
        }

        public E.Option GetRandom(List<string> desiredTags)
        {
            // code here
        }
    }

    #endregion

    #region CHARACTER GENERATION CLASSES
    class CharacterGenerator
    {
        PersonalInformationGenerator personalInformationGenerator = new PersonalInformationGenerator();

        BiologicalHeritageGenerator biologicalHeritageGenerator = new BiologicalHeritageGenerator();
        SocialHeritageGenerator socialHeritageGenerator = new SocialHeritageGenerator();

        SituationManagerGenerator situationManagerGenerator = new SituationManagerGenerator();
        OptionManagerGenerator optionManagerGenerator = new OptionManagerGenerator();

        EmotionGenerator emotionGenerator = new EmotionGenerator();
        MentalFocusGenerator mentalFocusGenerator = new MentalFocusGenerator();

        public E.Character Generate()
        {
            E.Character character = new E.Character();

            character.personalInformation = personalInformationGenerator.Generate();

            character.biologicalHeritage = biologicalHeritageGenerator.Generate();
            character.socialHeritage = socialHeritageGenerator.Generate();

            character.situationManager = situationManagerGenerator.Generate();
            character.optionManager = optionManagerGenerator.Generate();

            character.emotion = emotionGenerator.Generate();
            character.mentalFocus = mentalFocusGenerator.Generate();

            return character;
        }
    }

    class PersonalInformationGenerator
    {
        public E.PersonalInformation Generate();
    }

    class BiologicalHeritageGenerator
    {
        public E.BiologicalHeritage Generate();
    }

    class SocialHeritageGenerator
    {
        public E.SocialHeritage Generate();
    }

    class SituationManagerGenerator
    {
        public E.SituationManager Generate();
    }

    class OptionManagerGenerator
    {
        public E.OptionsManager Generate();
    }

    class EmotionGenerator
    {
        public E.Emotion Generate();
    }

    class MentalFocusGenerator
    {
        public E.MentalFocus Generate();
    }

    #endregion

    #region ORGANIZATION GENERATION CLASSES
    public class OrganizationGenerator
    {
        public E.Organization GenerateOrganization();
    }

    #endregion

    #region LOCATION GENERATION CLASSES
    public class LocationGenerator
    {
        public E.Location GenerateLocation();
    }

    #endregion
}