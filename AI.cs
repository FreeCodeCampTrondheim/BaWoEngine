using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;





// handles all non-player behaviour in the game
static class AI
{
    public static Dictionary<string, uint> combinedOptionValueTags;  // stores combined value for each tag on character
    public static Stack<E.Option> availableOptions;  // stores all options available to character

    public static List<OptionScore> scoreList;  // simple list for processing scores before being added to choiceQueue
    public static Queue<OptionScore> choiceQueue;   // final queue from which choices are made and sorted by willpower cost

    public struct OptionScore
    {
        public E.Option option;

        uint combinedValueTags;
        public uint willpowerCost;
        
        public void Initialize(E.Option o)
        {
            option = o;
            CalcCombinedValueTags();
            CalcWillpowerCost();
        }

        void CalcCombinedValueTags()
        {
            foreach (var valueTag in option.template.valueTags.Keys)
            {
                combinedValueTags += combinedOptionValueTags[valueTag];
            }
        }
        void CalcWillpowerCost()
        {
            willpowerCost = combinedValueTags / option.template.baseCost;
        }
    }
    
    public static void UpdateBehaviour()
    {
        foreach (var item in DataBank.characters)
        {
            E.Character c = item.Value;

            c.UpdateBehaviour();
            BuildScoreList(c);
            ExecuteChoices(c);
        }
    }

    #region COMPUTATION
    static void BuildScoreList(E.Character c)
    {
        for (int i = 0; i < availableOptions.Count; i++)
        {
            OptionScore temp = new OptionScore();
            temp.Initialize(availableOptions.Pop());
            scoreList.Add(temp);
        }
    }
    
    static void BuildChoiceQueue()
    {
        while(scoreList.Count > 0)
        {
            OptionScore currentLowestCost = new OptionScore()
            {
                willpowerCost = uint.MaxValue
            };

            foreach (var item in scoreList)
            {
                if (item.willpowerCost < currentLowestCost.willpowerCost)
                    currentLowestCost = item;
            }

            choiceQueue.Enqueue(currentLowestCost);
            scoreList.Remove(currentLowestCost);
        }
    }

    static void ExecuteChoices(E.Character c)
    {
        choiceQueue.Dequeue().option.Choose(c);
    }
    #endregion
}