using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




// handles generation of new entities
namespace Generator
{
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
}