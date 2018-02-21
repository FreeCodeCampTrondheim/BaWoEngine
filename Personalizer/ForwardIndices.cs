using System.Collections.Generic;








public static partial class Personalizer
{
    public static void ForwardIndices(
        BaseSimpleEntity beingFilled,
        SimpleEntitySharedData sharedData,
        List<int> indicesToForward)
    {
        for (int i = 0; i < indicesToForward.Count; i++)
        {
            // negative value in "about" indicates no set index
            if (sharedData.aboutFillSpecs[i].fillType == INDEX_FILL_TYPE.INDEX_FORWARDING_FIRST &&
                beingFilled.about[i] < 0)
            {
                beingFilled.about[i] = indicesToForward[i];
            }
        }
    }
}