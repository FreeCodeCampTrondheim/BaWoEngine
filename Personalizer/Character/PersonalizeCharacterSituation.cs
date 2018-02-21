using System.Collections.Generic;








public static partial class Personalizer
{
    public static Character.CharacterSituation Personalize(
        Character c,
        World w,
        List<int> forwardedIndices = null)
    {
        Character.CharacterSituation situation =
            new Character.CharacterSituation();

        // the four stages of personalization
        ForwardIndices(situation, situation.sharedData, forwardedIndices);
        SetIndiciesByCareAbout(situation, situation.sharedData, c);
        SetIndicesByCategoryNumbers(situation, situation.sharedData, w);
        SetIndicesByPureRandom(situation, situation.sharedData, w);

        return situation;
    }
}