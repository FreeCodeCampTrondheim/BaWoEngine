using System;
using System.Collections.Generic;







public static partial class Personalizer
{
    // gets a list of all potential candidate complex entities
    // that match any of the required category numbers, for then
    // to choose a random candidate
    public static void SetIndicesByCategoryNumbers(
        BaseSimpleEntity beingFilled,
        SimpleEntitySharedData sharedData,
        World w)
    {
        Random randomEngine = new Random();

        for (int i = 0; i < beingFilled.about.Count; i++)
        {
            // negative value in "about" indicates no set index
            if (beingFilled.about[i] < 0)
            {
                var tempFillSpecs = sharedData.aboutFillSpecs[i];
                
                List<int> candidates = w.GetComplexEntitiesByCategory(
                    tempFillSpecs.categoryNumbers,
                    tempFillSpecs.targetType);

                int ranNum = randomEngine.Next(candidates.Count);
                beingFilled.about[i] = candidates[ranNum];
            }
        }
    }
}