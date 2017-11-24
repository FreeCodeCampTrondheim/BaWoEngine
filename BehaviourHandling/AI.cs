using System.Collections.Generic;







// handles all non-player behaviour in the game
static class AI
{
    // combines all occurences of each individual 
    // value tag into a series of sums
    public static Dictionary<string, uint> individualValueTagSums;

    public static Stack<Entity.Option> availableOptions;  // stores all options available to character
    public static List<OptionScore> scoreList;       // simple list for processing scores before being added to choiceQueue

    // final queue from which choices are made and 
    // sorted by willpower cost in ascending order
    public static Queue<OptionScore> choiceQueue;

    // stores temporary data about the score of an option
    public struct OptionScore
    {
        public Entity.Option option;     // the represented option

        // the value of the option, based on the
        // combined value of all value tag sums
        uint combinedValueTagSum;

        // the calculated willpower cost to choose this option
        public uint willpowerCost;

        // sets up the struct, acquiring and 
        // assigning all necessary values
        public void Setup(Entity.Option o)
        {
            option = o;
            CalcCombinedValueTags();
            CalcWillpowerCost();
        }

        // use this to calculate the combined
        // value of all value tag sums
        void CalcCombinedValueTags()
        {
            foreach (var valueTag in option.template.valueTags.Keys)
            {
                combinedValueTagSum += individualValueTagSums[valueTag];
            }
        }

        // use this to calculate the willpower cost as 
        // a fraction of the option's base willpower cost
        void CalcWillpowerCost()
        {
            willpowerCost = combinedValueTagSum / option.template.baseCost;
        }
    }
    
    // call this method to perform all AI handling
    public static void UpdateBehaviour()
    {
        foreach (var item in DataBank.characters)
        {
            // reset all AI collections for each Character handled
            individualValueTagSums = new Dictionary<string, uint>();
            availableOptions = new Stack<Entity.Option>();
            scoreList = new List<OptionScore>();
            choiceQueue = new Queue<OptionScore>();

            Entity.Character c = item.Value;

            c.UpdateBehaviour();
            BuildScoreList(c);
            BuildChoiceQueue(c);
            ExecuteChoices(c);
        }
    }

    #region COMPUTATION

    // sets up all OptionScores and adds them to scoreList
    static void BuildScoreList(Entity.Character c)
    {
        for (int i = 0; i < availableOptions.Count; i++)
        {
            OptionScore temp = new OptionScore();
            temp.Setup(availableOptions.Pop());
            scoreList.Add(temp);
        }
    }
    
    // extracts OptionScores until the character is out of willpower,
    // building the choiceQueue with cheapest Options first
    static void BuildChoiceQueue(Entity.Character c)
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

            // check if there is enough willpower left
            if (c.willpowerPoints - currentLowestCost.willpowerCost > 0)
                c.willpowerPoints -= currentLowestCost.willpowerCost;
            else break;

            choiceQueue.Enqueue(currentLowestCost);
            scoreList.Remove(currentLowestCost);
        }
    }

    // apply choices to character
    static void ExecuteChoices(Entity.Character c)
    {
        while(choiceQueue.Count > 0)
            choiceQueue.Dequeue().option.Choose(c);
    }
    #endregion
}