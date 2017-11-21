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

            ConsiderationEngine.Act(c);
            CreativityEngine.Act(c);
            LuckEngine.Act(c);
            ReasoningEngine.Act(c);
        }
    }

    #region INTELLIGENCE UNITS
    // generates new options for character based on module data
    public class Considerator
    {
        List<E.Situation> recentSituationChanges;

        // consider new options using recent changes in situations
        public void Consider() { }
    }

    // measures option scores based on module data
    public interface IReasoner
    {
        // measure score of single option based on module data
        float Reason(E.Option o);
    }
    #endregion

    #region ENGINES
    // figures out what new options should be on the table for the character
    static class ConsiderationEngine
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