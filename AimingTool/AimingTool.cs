using System;
using System.Collections.Generic;

public static partial class AimingTool
{
    public static void UpdateScoreWithAddedCareAbouts(
        List<CareAbout> careAbouts,
        List<int> careAboutTargets, 
        Character c)
    {
        c.ApplyCareAboutChangesToOptions(careAbouts, careAboutTargets);
        c.UpdateOptionsRanking();
    }

    public static void UpdateScoreWithRemovedCareAbouts(List<CareAbout> careAbouts, Character c)
    {
        throw new NotImplementedException();
    }
}