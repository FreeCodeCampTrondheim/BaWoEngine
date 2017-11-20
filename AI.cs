using System;
using System.Collections.Generic;
using System.Text;





// handles all non-player behaviour in the game
static class AI
{
    public static void UpdateBehaviour()
    {
        PersonalizationEngine.Act();
        CreativityEngine.Act();
        LuckEngine.Act();
        ReasoningEngine.Act();
    }

    // figures out how an option should look like for the particular character
    static class PersonalizationEngine
    {
        public static void Act()
        {
            foreach (var c in DataBank.characters)
            {
                // run functions
            }
        }

        static List<E.Option> Personalize(E.Character c) { return null; }

        // compounds a list of all possible personalized variants of an option for the character
        static List<E.Option> PersonalizeOption(E.Character c, E.Option o) { return null; }

        static void BaseOnSituations() { }     // personalizes the option based on the character's situations
        static void BaseOnStats() { }          // personalizes the option based on the character's stats
        static void BaseOnRelations() { }      // personalizes the option based on the character's relationships
    }

    // figures out what options a character should have
    static class CreativityEngine
    {
        public static void Act()
        {
            foreach (var c in DataBank.characters)
            {
                // run functions
            }
        }

        // processes data about character and sets list of options in Data Bank
        static List<E.Option> SetCharacterOptions(E.Character c) { return null; }

        // from the situations the character is subjected to
        static List<E.Option> GetFromCharacterSituations() { return null; }

        // from things characters, organizations and locations they have relations with
        static List<E.Option> GetFromCharacterConsiderations() { return null; }

        // randomly selected from option catalogue, number of options depend on character creativity
        static List<E.Option> GetFromCharacterInspiration() { return null; }
    }

    // figures out when, how much and upon whom luck-based situations should occur
    static class LuckEngine
    {
        const uint MAX_LUCK_RATE = 100;
        const uint MIN_LUCK_RATE = 10;

        const uint MAX_LUCK_PER_CHARACTER = 20;
        const uint MIN_LUCK_PER_CHARACTER = 10;

        // list with multiple instances of each character id
        static Queue<ulong> characterLuck;

        public static void Act()
        {
            foreach (var c in DataBank.characters)
            {
                // run functions
            }
        }

        static void SpreadLuck()
        {
            // if characterLuck is not empty, then inflict luck 
            // anywhere between MIN_LUCK_RATE and MAX_LUCK_RATE times
            // on characters with id of dequeued integer

            // else, repopulate characterLuck for every character in-game
        }

        // repopulates characterLuck for every character, with
        // between MIN_LUCK_PER_CHARACTER and MAX_LUCK_PER_CHARACTER
        // number of occurences
        static void RegenerateLuck() { }

        // compiles a list of available situations and
        // adds exactly one of them to target character
        static void InflictLuck(ulong characterID) { }

        // varies the luck based on the character's situations,
        // the character may already have situations that make
        // available other luck-based situations
        static void BaseOnSituations(E.Character c) { }

        // varies the luck based on the character's stats,
        // the character may have stats that make available
        // luck-based situations in target character
        static void BaseOnStats(E.Character c) { }

        // varies the luck based on the character's relationships,
        // the related entities may have situations that make
        // available luck-based situations in target character
        static void BaseOnRelations(E.Character c) { }
    }

    // figures out what character should do
    static class ReasoningEngine
    {
        public static void Act()
        {
            foreach (var c in DataBank.characters)
            {
                // run functions
            }
        }

        // acquires first choices, then applies them to the character iteratively
        static void MakeAIChoices(E.Character c)
        {
            // code here
        }

        // processes data about character and returns chosen options
        static List<E.Option> GetChoices(E.Character c) { return null; }

        // calculates score for option based on character emotions
        static void CalcEmotionScore() { }

        // calculates score for option based on character mental focus
        static void CalcMentalFocusScore() { }

        static List<E.Option> availableOptions;
        static Dictionary<int, float> optionScore;
    }
}