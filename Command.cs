using System.Collections.Generic;







// use this to steer the automated background world
public static class Command
{
    public class WorldRecipe
    {
        // code here
    }

    public class PlayerRecipe
    {
        List<string> situationsNotGenerated = new List<string>();
        List<string> optionsNotGenerated = new List<string>();
        List<string> forecastsNotGenerated = new List<string>();

        // code here
    }

    public static void SetupModules(
        string characterModules = @"\characterModules\",
        string organizationModules = @"\organizationModules\",
        string locationModules = @"\locationModules\")
    {
        // code here
    }

    public static void SetupData(WorldRecipe wr = null, PlayerRecipe pr = null)
    {
        // code here
    }

    public static void RunTick()
    {
        // code here
    }

    public static string GetWorldJSON()
    {
        // code here
        return null;
    }

    public static string GetPlayerJSON()
    {
        // code here
        return null;
    }

    public static void SetupGameFromJSON(string world, string player)
    {
        // code here
    }
}