using System.Collections.Generic;








public static partial class Personalizer
{
    public static void ForwardIndices(
        BaseSimpleEntity simpleEntity,
        List<int> indicesToForward,
        List<COMPLEX_ENTITY_TYPE> indexTypes)
    {
        for (int i = 0; i < indicesToForward.Count; i++)
        {
            if(indexTypes[i] != COMPLEX_ENTITY_TYPE.NONE)
            {
                simpleEntity.aboutTypes[i] = indexTypes[i];
                simpleEntity.about[i] = indicesToForward[i];
            }   
        }
    }
}