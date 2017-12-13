using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




// handles generation of new entities
static class Generator
{
    #region MODULE CLASSES
    static class CharacterModule
    {
        /*
            start likelihood is value from >0.0f to <=1.0f, it represents how likely 
            the situation/option/forecast is to be part of a fully generated character
        */
        public static Dictionary<string, float> startSituations
            = new Dictionary<string, float>();
        public static Dictionary<string, float> startOptions
            = new Dictionary<string, float>();
        public static Dictionary<string, float> startForecasts
            = new Dictionary<string, float>();
    }


    #endregion

    #region CHARACTER GENERATION CLASSES
    static class Character
    {
        public static Entity.Character Generate()
        {
            Entity.Character character = new Entity.Character();

            return character;
        }

        public static Entity.Character GeneratePlayer(Command.PlayerRecipe pr)
        {
            Entity.Character character = new Entity.Character();

            return character;
        }
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
