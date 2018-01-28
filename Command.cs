using System.Collections.Generic;








static class Command
{
    public static List<World> worlds = new List<World>();

    static int nextSimpleEntitySharedDataID = 0;
    public static int GetNewSimpleEntitySharedDataID()
    {
        nextSimpleEntitySharedDataID++;
        return nextSimpleEntitySharedDataID;
    }
}