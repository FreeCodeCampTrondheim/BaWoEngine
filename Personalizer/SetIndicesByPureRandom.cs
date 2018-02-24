using System;








public static partial class Personalizer
{
    // sets about indices to purely random 
    // complex entities of specified type
    public static void SetIndicesByPureRandom(
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
                var targetType = sharedData.aboutSpecs[i].targetType;

                int ranNum;
                switch (targetType)
                {
                    case COMPLEX_ENTITY_TYPE.CHARACTER:
                        ranNum = randomEngine.Next(w.characters.Count);
                        beingFilled.about[i] = ranNum;
                        break;
                    case COMPLEX_ENTITY_TYPE.COLLECTIVE:
                        ranNum = randomEngine.Next(w.collectives.Count);
                        beingFilled.about[i] = ranNum;
                        break;
                    default:
                        throw new Exception("Type neither character nor collective");
                }
            }
        }
    }
}