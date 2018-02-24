using System.Collections.Generic;
using System.Linq;







public static partial class Personalizer
{
    // assembles a list of all CareAbouts relevant to the specification
    static List<CareAbout> GetRelevantCareAbouts(Character c, IndexSpecification spec)
    {
        // all CareAbouts with any of the specified IDs
        var relevantCareAbouts = new List<CareAbout>();

        for (int j = 0; j < c.situations.Count; j++)
        {
            // the CareAbouts for this specific situation
            var careAboutsAtSituation = c.situations[j].sharedData.careAbouts;

            // check all the CareAbouts of the situation
            for (int k = 0; k < careAboutsAtSituation.Count; k++)
            {
                int targetIndex = careAboutsAtSituation[k].targetAboutIndex;
                
                // gets the target type at the current situation for the specified index 
                var typeAtSituation = c.situations[j].sharedData.aboutSpecs[targetIndex].targetType;

                // is the type from the situation the same as the one I'm looking for?
                if (spec.targetType == typeAtSituation)
                {
                    // is this one of the CareAbouts we're looking for?
                    if (spec.careAboutGroupIDs.Contains(careAboutsAtSituation[k].groupID))
                        relevantCareAbouts.Add(careAboutsAtSituation[k]);
                }
            }
        }

        return relevantCareAbouts;
    }
}