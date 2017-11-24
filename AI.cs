using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;





// handles all non-player behaviour in the game
static class AI
{
    public static Dictionary<string, uint> optionTagValue;     // stores combined value for each tag on character
    public static List<E.Option> availableOptions;             // stores all options available to character

    public static List<OptionScore> unprocessedScores;         // simple list for processing scores before being added to choiceQueue
    public static Queue<OptionScore> choiceQueue;              // final queue from which choices are made and sorted by willpower cost

    public struct OptionScore
    {
        uint willpowerCost;
        uint combinedTagValue;
        E.Option option;

        public void CalcWillpowerCost()
        {
            willpowerCost = combinedTagValue / option.template.baseCost;
        }
    }
    
    public static void UpdateBehaviour()
    {
        foreach (var item in DataBank.characters)
        {
            E.Character c = item.Value;

            ConsiderationEngine.Act(c);
            ReasoningEngine.Act(c);
        }
    }

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