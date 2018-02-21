using System.Collections.Generic;
using System.Linq;
using System;






public static partial class Personalizer
{
    /* 
        1) get all relevant CareAbouts for each index's
        IndexFillSpecification at each index that is not set
        2) for all non-set indices, get all targeted complex entities
        3) for all non-set indices, assign id of the complex entity with highest score 
    */
    public static void SetIndiciesByCareAbout(
        BaseSimpleEntity beingFilled, 
        SimpleEntitySharedData beingFilledSharedData,
        Character c)
    {
        int numOfFillSpecs = beingFilledSharedData.aboutFillSpecs.Length;
        for (int i = 0; i < numOfFillSpecs; i++)
        {
            // the specification for how to fill the associated 
            // index with a complex entity id
            IndexFillSpecification spec = beingFilledSharedData.aboutFillSpecs[i];

            // negative value in "about" indicates no set index
            if (spec.fillType <= INDEX_FILL_TYPE.CARE_ABOUT_FIRST &&
                beingFilled.about[i] < 0)
            {
                // all CareAbouts that have any of the specified IDs
                var temp = GetRelevantCareAbouts(c, spec);
                
                beingFilled.about[i] = GetHighestScoringComplexEntityID(temp);
            }
        }
    }

    // assembles a list of all CareAbouts relevant to the specification
    static List<CareAbout> GetRelevantCareAbouts(Character c, IndexFillSpecification spec)
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
                var typeAtSituation = c.situations[j].sharedData.aboutFillSpecs[targetIndex].targetType;

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

    // finds and retrieves the complex entity with
    // the highest combined degree of CareAbout
    static int GetHighestScoringComplexEntityID(List<CareAbout> ca)
    {
        // integer is ID of complex entity, double is score sum
        var results = new Dictionary<int, double>();

        // sum up degrees for each complex entity
        for (int i = 0; i < ca.Count; i++)
        {
            if (results.ContainsKey(ca[i].targetAboutIndex))
                results[ca[i].targetAboutIndex] += ca[i].degree;
            else results.Add(ca[i].targetAboutIndex, ca[i].degree);
        }

        // finds largest value, then searches for corresponding index
        double maxVal = results.Values.Max();
        int id = results.FirstOrDefault(pair => 
        {
            return pair.Value == maxVal;
        }).Key;

        return id;
    }
}