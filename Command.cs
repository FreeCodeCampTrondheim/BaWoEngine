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
        // code here
    }

    public static void SetupModules(
        string characterModules = "\\characterModules\\",
        string organizationModules = "\\organizationModules\\",
        string locationModules = "\\locationModules\\")
    {
        // code here
    }

    public static void SetupData(WorldRecipe wr = null, PlayerRecipe pr = null)
    {
        // code here
    }

    public static void SetupData(WorldRecipe wr = null, PlayerRecipe[] prs = null)
    {
        // code here
    }

    public static void SetMinimumTickRate(float secondsPerTick)
    {
        // code here
    }

    public static void RunSingleManualTick()
    {
        // code here
    }

    public static void Stop()
    {
        // code here
    }

    public static void Start()
    {
        // code here
    }

    public static string GetWorldJSON()
    {
        // code here
        return null;
    }

    public static string[] GetPlayerJSON()
    {
        // code here
        return null;
    }

    public static void SetupGameFromJSON(string world, string player)
    {
        // code here
    }

    public static void SetupGameFromJSON(string world, string[] players)
    {
        // code here
    }
}