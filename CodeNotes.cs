using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    ARCHITECTURAL DESCRIPTION:
    
    Game Manager
    - instantiates central objects
    - controls speed and ticks of the game
    - runs UpdateBehaviour on AI, and UpdateData on Data Bank

    AI Engines
    - define and create a set of options for each tick of the game 
    - chooses an option at a time, but makes a variable amount of 
      choices after each other

    Entities
    - define non-relational data about in-game entities

    Data Bank
    - define relational data
    - stores all data and gives easy access to it, 
      either directly or for iteration
    
    Player
    - defines all possible responses to user actions, like retrieving data and applying choices
    - defines all automated tasks done for the user
    - includes searching, various information feeds, character creation, user choices and so forth
*/


class InfoDisplay
{
    public InfoDisplay(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    // handles user interaction and updating of displayed information about searches and selected search results
    public class Inspector
    {
        void DisplayCharacter(E.Character c);
        void DisplayOrganization(E.Organization o);
        void DisplayLocation(E.Location l);

        void DisplaySearchResults(List<uint> entityResults);
    }

    // handles updating of displayed information about new situations
    public class SituationNews
    {
        Queue<E.Situation> newSituations;

        void DisplayNews();
    }

    // handles user interaction and updating of displayed information about player situations 
    public class SituationResponder
    {

    }

    // handles user interaction and updating of displayed information about player information
    public class PlayerInfo
    {

    }

    // handles updating of displayed information about character dialogue
    public class Hangout
    {

    }
}

class PlayerInteraction
{
    public PlayerInteraction(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    public class SearchEngine
    {
        const uint NUM_STORED_SEARCHES = 5;

        object[] lastSearches = new object[NUM_STORED_SEARCHES];    // stores last chosen searches

        // finds all characters, organizations and locations,
        // sorts them by type (characters, organizations, then locations),
        // followed by name alphabetically, followed by age descending
        // (except locations which don't have age), followed by id ascending 
        public List<object>[] Search(string searchTxt);

        List<E.Character> FindCharacters();         // finds all characters from string

        List<E.Organization> FindOrganizations();   // finds all organizations from string

        List<E.Location> FindLocations();           // finds all locations from string
    }
}

// where classes for in-game entities are defined
class E
{
    public E(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    public class BaseEntity
    {
        public ulong id;
        public string name;
        public bool isAliveOrActive;

        public abstract void Update();
    }


    #region CHARACTER CLASSES
    // all relationless data about character
    public class Character : BaseEntity { }

    public class BiologicalHeritage { }    // constant base stats and modifiers for character based on biological heritage
    public class SocialHeritage { }        // constant base stats and modifiers for character based on social heritage

    public class Emotion { }       // all emotions and all methods for their data
    public class MentalFocus { }   // all mental focus and all methods for their data

    public class SituationManager  // all situations and all methods for their data
    {
        List<Situation> currentSituations;
        List<Situation> latestSituations;   // used for smaller iterations
    }

    public class Situation             // all data about a situation
    {
        ulong id;
        string title;
        string description;

        List<string> optionTags;        // identifies what tags an option must have to use this situation
        List<string> situationTags;     // identifies what type of situation this is
    }

    public class OptionsManager    // all options and all methods for their data
    {
        List<Option> availableOptions;
    }

    public class Option                // all data about an option
    {
        ulong id;
        string title;
        string description;

        List<string> optionTags;        // identifies what tags a situation must to be included in this option
    }
    #endregion

    #region ORGANIZATION CLASSES
    public class Organization : BaseEntity { }      // all relationless data about organization

    #endregion

    #region ORGANIZATION CLASSES
    public class Location : BaseEntity { }          // all relationless data about location

    #endregion
}

// where classes for in-game entities are templated and created
class Catalogue
{
    public Catalogue(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    List<E.Situation> situationTemplates;
    List<E.Option> optionTemplates;


    public class CharacterGenerator
    {
        List<string> firstNames;
        List<string> surnames;
        
        public E.Character GenerateCharacter();
    }
    public class OrganizationGenerator { }
    public class LocationGenerator { }
}

class DataBank
{
    public void UpdateData(DateTime d)
    {
        foreach (E.Character c in characters)
        {
            // c.Update(d);
        }

        foreach (E.Organization o in organizations)
        {
            // o.Update(d);
        }

        foreach (E.Location l in locations)
        {
            // l.Update(d);
        }
    }

    public ulong globalID = 0;

    #region ENTITY RELATIONSHIPS
    float GetChar2CharOpinion(uint fromChar, uint toChar);    // gets one character's opinion of another

    float GetChar2OrgOpinion(uint fromChar, uint toOrg);      // gets one character's opinion of an organization
    float GetOrg2CharOpinion(uint fromOrg, uint toChar);      // gets one organization's opinion of a character

    uint GetChar2OrgInvestment(uint fromChar, uint toOrg);     // gets number of stocks owned in an organization
    #endregion

    #region ATTRIBUTES OF ENTITIES

    float GetCharLuck(int fromChar);

    List<E.Option> GetCharOptions(int fromChar);
    List<E.Situation> GetCharSituations(int fromChar);
    
    #endregion

    #region CENTRAL ENTITIES
    // key1 = id of character, value = all relationless data about character
    public Dictionary<ulong, E.Character>      characters;

    // key1 = id of organization, value = all relationless data about organization
    public Dictionary<ulong, E.Organization>   organizations;

    // key1 = id of location, value = all relationless data about location
    public Dictionary<ulong, E.Location>       locations;
    #endregion
}

class AI
{
    public AI(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    ReasoningEngine         reasoningEngine = new ReasoningEngine();
    CreativityEngine        creativityEngine = new CreativityEngine();
    PersonalizationEngine   personalizationEngine = new PersonalizationEngine();
    LuckEngine              luckEngine = new LuckEngine();

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

/*
        Situations need to have an origin
            - can be:
                - character (also includes specification of which)
                - organization (also includes specification of which)
                - luck
                - mystery

        Situations need to have descriptors/tags that categorizes them

        Options need to add and subtract other options???

        Options need personalization method that adjusts variables for specific characters or organizations

        Options to be separated into
            - character options, what options characters have, they choose based on:
                - mental focus targets and their focus degree
                - emotions and their weights
                - how much they like or dislike the targets of the situations
            - organization options, what options organizations have, they choose based on:
                - how many of the owning characters are willing to support the option
            - nature options, what options nature has, it chooses based on:
                - base likelihood weight
                - aggragate likelihood weight from pairing "aggregation tags" of option with "aggregatable tags" of situations


        Characters need list of emotions and emotional weight/value

        Characters need list of mental focus targets
            - can be:
                    - characters
                    - organizations
                    - locations
                    - options
                    - situations
            - mental focus towards a target is aggregated for every situation with that target as an origin

        Characters need heritage that modifies base statistics
            - when players create their character, they have a max amount
              of points they can use to add advantage through these,
              the available amount depends on difficulty setting,
              and adding disadvantage gives back extra points
            - comes with two types:
                - biological
                - social
    */
