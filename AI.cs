using System;
using System.Collections.Generic;
using System.Text;





// handles all non-player behaviour in the game
static class AI
{
    public static void UpdateBehaviour()
    {
        foreach (var item in DataBank.characters)
        {
            E.Character c = item.Value;

            PersonalizationEngine.Act(c);
            CreativityEngine.Act(c);
            LuckEngine.Act(c);
            ReasoningEngine.Act(c);
        }
    }

    // declares methods that a module must implement to be available for the AI Engines
    public interface IConsiderable
    {
        // figure out necessary methods
    }

    #region ENGINES
    // figures out how an option should look like for the particular character
    static class PersonalizationEngine
    {
        public static void Act(E.Character c)
        {
            // code here
        }
    }

    // figures out what options a character should have
    static class CreativityEngine
    {
        public static void Act(E.Character c)
        {
            // code here
        }
    }

    // figures out when, how much and upon whom luck-based situations should occur
    static class LuckEngine
    {
        public static void Act(E.Character c)
        {
            // code here
        }
    }

    // figures out what character should do
    static class ReasoningEngine
    {
        public static void Act(E.Character c)
        {
            // code here
        }
    }
    #endregion
}