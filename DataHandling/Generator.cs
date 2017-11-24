using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




// handles generation of new entities
static class Generator
{
    #region CHARACTER GENERATION CLASSES
    static class Character
    {
        public static Entity.Character Generate()
        {
            Entity.Character character = new Entity.Character();

            character.personProfile = PersonProfile.Generate();
            character.biology = Biology.Generate();

            character.socialLife = SocialLife.Generate();
            character.opinions = Opinions.Generate();

            character.emotions = Emotions.Generate();
            character.mentalFocus = MentalFocus.Generate();

            return character;
        }
    }

    static class PersonProfile
    {
        public static Entity.Modules.PersonProfile Generate() { return null; }
    }

    static class Biology
    {
        public static Entity.Modules.Biology Generate() { return null; }
    }

    static class SocialLife
    {
        public static Entity.Modules.SocialLife Generate() { return null; }
    }

    static class Opinions
    {
        public static Entity.Modules.Opinions Generate() { return null; }
    }

    static class Emotions
    {
        public static Entity.Modules.Emotions Generate() { return null; }
    }

    static class MentalFocus
    {
        public static Entity.Modules.MentalFocus Generate() { return null; }
    }
    #endregion

    #region ORGANIZATION GENERATION CLASSES
    public static class Organization
    {
        public static Entity.Organization GenerateOrganization() { return null; }
    }

    #endregion

    #region LOCATION GENERATION CLASSES
    public static class Location
    {
        public static Entity.Location GenerateLocation() { return null; }
    }

    #endregion

    #region WORLD GENERATION CLASSES
    public static class World
    {
        public static void Generate() { }
    }

    #endregion
}
