using System.Collections.Generic;








public static partial class Personalizer
{
    public static Character.CharacterSituation Personalize(
        Character c, 
        CharacterSituationSharedData sharedData,
        List<int> forwardedIndices = null,
        List<COMPLEX_ENTITY_TYPE> indexTypes = null)
    {
        Character.CharacterSituation situation =
            new Character.CharacterSituation();

        // if "forwardedIndices" is other than null,
        // then the same is assumed for "indexTypes"
        if (forwardedIndices != null) ForwardIndices(situation, situation.sharedData, forwardedIndices, indexTypes);

        

        return situation;
    }
}