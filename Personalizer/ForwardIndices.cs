








public static partial class Personalizer
{
    public static void ForwardIndices(
        BaseSimpleEntity simpleEntity,
        SimpleEntitySharedData sharedData,
        int[] indicesToForward)
    {
        int len = indicesToForward.Length;
        for (int i = 0; i < len; i++)
        {
            // negative value in "about" indicates no set index
            if (sharedData.aboutFillSpecs[i].fillType == INDEX_FILL_TYPE.INDEX_FORWARDING_FIRST && 
                indicesToForward[i] < 0)
            {
                simpleEntity.about[i] = indicesToForward[i];
            }
        }
    }
}