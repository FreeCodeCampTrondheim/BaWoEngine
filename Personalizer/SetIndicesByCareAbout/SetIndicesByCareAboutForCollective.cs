using System.Collections.Generic;
using System.Linq;







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
        Collective c)
    {
        int numOfFillSpecs = beingFilledSharedData.aboutSpecs.Count;
        for (int i = 0; i < numOfFillSpecs; i++)
        {
            // the specification for how to fill the associated 
            // index with a complex entity id
            IndexSpecification spec = beingFilledSharedData.aboutSpecs[i];

            // negative value in "about" indicates no set index
            if (spec.fillType <= INDEX_FILL_TYPE.CARE_ABOUT_FIRST &&
                beingFilled.about[i] < 0)
            {
                List<CareAbout> temp = new List<CareAbout>();

                for (int j = 0; j < c.controllingCharacters.Count; j++)
                {
                    var character = c.controllingCharacters[j];

                    // all CareAbouts that have any of the specified IDs
                    temp.AddRange(GetRelevantCareAbouts(character, spec));
                }
                
                beingFilled.about[i] = GetHighestScoringComplexEntityID(temp);
            }
        }
    }
}