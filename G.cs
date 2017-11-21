using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




// handles generation of new entities
namespace G
{
    #region CHARACTER GENERATION CLASSES
    static class CharacterGenerator
    {
        public static E.Character Generate()
        {
            E.Character character = new E.Character();

            character.personProfile = PersonProfileGenerator.Generate();

            character.biology = BiologyGenerator.Generate();

            character.socialLife = SocialLifeGenerator.Generate();
            character.opinions = OpinionsGenerator.Generate();

            character.emotions = EmotionsGenerator.Generate();
            character.mentalFocus = MentalFocusGenerator.Generate();

            return character;
        }
    }

    static class PersonProfileGenerator
    {
        public static E.Modules.PersonProfile Generate() { return null; }
    }

    static class BiologyGenerator
    {
        public static E.Modules.Biology Generate() { return null; }
    }

    static class SocialLifeGenerator
    {
        public static E.Modules.SocialLife Generate() { return null; }
    }

    static class OpinionsGenerator
    {
        public static E.Modules.Opinions Generate() { return null; }
    }

    static class EmotionsGenerator
    {
        public static E.Modules.Emotions Generate() { return null; }
    }

    static class MentalFocusGenerator
    {
        public static E.Modules.MentalFocus Generate() { return null; }
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
