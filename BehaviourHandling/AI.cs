using System.Collections.Generic;







// handles all non-player behaviour in the game
public static class AI
{
    // currently computed character
    static Entity.Character c;

    // simple list for processing scores before being added to choiceQueue
    static List<OptionScore> scoreList;

    // final queue from which choices are made and 
    // sorted by willpower cost in ascending order
    static Queue<OptionScore> choiceQueue;

    // stores temporary data about the score of an option
    struct OptionScore
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
                combinedValueTagSum += c.GetValueTagSum(valueTag);
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
            scoreList = new List<OptionScore>();
            choiceQueue = new Queue<OptionScore>();

            c = item.Value;
            
            BuildScoreList();
            BuildChoiceQueue();
            ExecuteChoices();
        }
    }

    #region COMPUTATION
    // sets up all OptionScores and adds them to scoreList
    static void BuildScoreList()
    {
        for (int i = 0; i < c.options.Count; i++)
        {
            OptionScore temp = new OptionScore();
            temp.Setup(c.options[i]);
            scoreList.Add(temp);
        }
    }
    
    // extracts OptionScores until the character is out of willpower,
    // building the choiceQueue with cheapest Options first
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

            // check if there is enough willpower left
            if (c.willpowerPoints - currentLowestCost.willpowerCost > 0)
                c.willpowerPoints -= currentLowestCost.willpowerCost;
            else break;

            choiceQueue.Enqueue(currentLowestCost);
            scoreList.Remove(currentLowestCost);
        }
    }

    // apply choices to character
    static void ExecuteChoices()
    {
        while(choiceQueue.Count > 0)
            choiceQueue.Dequeue().option.Choose(c);
    }
    #endregion
}