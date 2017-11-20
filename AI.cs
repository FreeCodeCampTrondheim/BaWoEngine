using System;
using System.Collections.Generic;
using System.Text;





// handles all non-player behaviour in the game
class AI
{
    public AI(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    ReasoningEngine reasoningEngine = new ReasoningEngine();
    CreativityEngine creativityEngine = new CreativityEngine();
    PersonalizationEngine personalizationEngine = new PersonalizationEngine();
    LuckEngine luckEngine = new LuckEngine();

    public void UpdateBehaviour()
    {
        personalizationEngine.Act();
        creativityEngine.Act();
        luckEngine.Act();
        reasoningEngine.Act();
    }

    public class AIEngine
    {
        public abstract void Act();
    }

    // figures out how an option should look like for the particular character
    class PersonalizationEngine : AIEngine
    {
        public void Act()
        {
            foreach (E.Character c in dBank.characters)
            {
                // run functions
            }
        }

        List<E.Option> Personalize(E.Character c)
        {

        }

        // compounds a list of all possible personalized variants of an option for the character
        List<E.Option> PersonalizeOption(E.Character c, E.Option o)
        {

        }

        void BaseOnSituations() { }     // personalizes the option based on the character's situations
        void BaseOnStats() { }          // personalizes the option based on the character's stats
        void BaseOnRelations() { }      // personalizes the option based on the character's relationships
    }

    // figures out what options a character should have
    class CreativityEngine : AIEngine
    {
        public void Act()
        {
            foreach (E.Character c in dBank.characters)
            {
                // run functions
            }
        }

        List<E.Option> SetCharacterOptions(E.Character c)   // processes data about character and sets list of options in Data Bank
        {

        }

        List<E.Option> GetFromCharacterSituations();       // from the situations the character is subjected to
        List<E.Option> GetFromCharacterConsiderations();   // from things characters, organizations and locations they have relations with
        List<E.Option> GetFromCharacterInspiration();      // randomly selected from option catalogue, number of options depend on character creativity
    }

    // figures out when, how much and upon whom luck-based situations should occur
    class LuckEngine : AIEngine
    {
        const uint MAX_LUCK_RATE = 100;
        const uint MIN_LUCK_RATE = 10;

        const uint MAX_LUCK_PER_CHARACTER = 20;
        const uint MIN_LUCK_PER_CHARACTER = 10;

        // list with multiple instances of each character id
        Queue<ulong> characterLuck;

        public void Act()
        {
            foreach (E.Character c in dBank.characters)
            {
                // run functions
            }
        }

        void SpreadLuck()
        {
            // if characterLuck is not empty, then inflict luck 
            // anywhere between MIN_LUCK_RATE and MAX_LUCK_RATE times
            // on characters with id of dequeued integer

            // else, repopulate characterLuck for every character in-game
        }

        // repopulates characterLuck for every character, with
        // between MIN_LUCK_PER_CHARACTER and MAX_LUCK_PER_CHARACTER
        // number of occurences
        void RegenerateLuck();

        // compiles a list of available situations and
        // adds exactly one of them to target character
        void InflictLuck(ulong characterID);

        // varies the luck based on the character's situations,
        // the character may already have situations that make
        // available other luck-based situations
        void BaseOnSituations(E.Character c);

        // varies the luck based on the character's stats,
        // the character may have stats that make available
        // luck-based situations in target character
        void BaseOnStats(E.Character c);

        // varies the luck based on the character's relationships,
        // the related entities may have situations that make
        // available luck-based situations in target character
        void BaseOnRelations(E.Character c);
    }

    // figures out what character should do
    class ReasoningEngine : AIEngine
    {
        public void Act()
        {
            foreach (E.Character c in dBank.characters)
            {
                // run functions
            }
        }

        void MakeAIChoices(E.Character c)   // acquires first choices, then applies them to the character iteratively
        {

        }

        List<E.Option> GetChoices(E.Character c)   // processes data about character and returns chosen options
        {

        }

        void CalcEmotionScore() { }            // calculates score for option based on character emotions
        void CalcMentalFocusScore() { }        // calculates score for option based on character mental focus

        List<E.Option> availableOptions;
        Dictionary<int, float> optionScore;
    }
}