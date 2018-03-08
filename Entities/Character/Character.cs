using System;
using System.Collections.Generic;







public partial class Character : BaseComplexEntity
{
    public List<CharacterSituation> situations;
    public List<CharacterOption> options;
    public List<CharacterForecast> forecasts;

    public int baseWillpower = 1000;
    
    // Dictionary key is group ID of care about.
    // Note that options can be present in every list
    // that have a matching care about group ID.
    public Dictionary<int, List<CharacterOption>> optionsByCareAbout;

    // Which options should be prioritized
    public List<CharacterOption> optionsRanking;

    public void ApplyCareAboutChangesToOptions(
        List<CareAbout> careAbouts,
        List<int> careAboutTargets)
    {
        var allMatchedOptions = new List<CharacterOption>[careAbouts.Count];

        List<CharacterOption> temp;
        for (int i = 0; i < careAbouts.Count; i++)
        {
            if(optionsByCareAbout.TryGetValue(careAbouts[i].groupID, out temp))
                allMatchedOptions[i] = temp;
            else
                allMatchedOptions[i] = null;
        }

        var processedOptions = new Stack<CharacterOption>();

        int numOf = allMatchedOptions.Length;
        for (int i = 0; i < numOf; i++)
        {
            if (allMatchedOptions[i] != null)
            {
                for (int j = 0; j < allMatchedOptions[i].Count; j++)
                {
                    if (!processedOptions.Contains(allMatchedOptions[i][j]))
                    {
                        processedOptions.Push(allMatchedOptions[i][j]);
                        allMatchedOptions[i][j].AddTargetValues(careAbouts, careAboutTargets);
                    }
                }
            }
        }
    }
    
    public void UpdateOptionsRanking()
    {
        // figures out which should come first (sorting smallest to largest)
        Comparison<CharacterOption> optionRankingComparerer = (optionA, optionB) =>
        {
            return Convert.ToInt32(
                optionA.sharedData.baseWillpowerCost -
                optionB.sharedData.baseWillpowerCost);
        };

        optionsRanking.Sort(optionRankingComparerer);
    }
}