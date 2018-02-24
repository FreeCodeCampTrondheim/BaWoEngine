using System.Collections.Generic;








public static partial class Personalizer
{
    // personalizes a simple entity of type T, and returns it readily configured
    public static T Personalize<T, U>(
        Collective c,
        World w,
        List<int> forwardedIndices = null)

        // if T = CollectiveSituation, U = CollectiveSituationSharedData,
        // with the same for other simple entities
        where T : BaseSimpleEntity, IShareData<U>, new()
        where U : SimpleEntitySharedData
    {
        // situation/option/forecast to be personalized
        T simpleEntity = new T();

        // the four stages of personalization
        ForwardIndices(simpleEntity, simpleEntity.sharedData, forwardedIndices);
        SetIndiciesByCareAbout(simpleEntity, simpleEntity.sharedData, c);
        SetIndicesByCategoryNumbers(simpleEntity, simpleEntity.sharedData, w);
        SetIndicesByPureRandom(simpleEntity, simpleEntity.sharedData, w);

        return simpleEntity;
    }
}