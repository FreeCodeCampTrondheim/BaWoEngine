using System;
using System.Collections.Generic;
using System.Text;





// handles storage and access of data throughout game
static class DataBank
{
    public static void UpdateData(DateTime d)
    {
        foreach (var p in players)
        {
            p.UpdateTime(d);
        }

        foreach (var c in characters)
        {
            c.UpdateTime(d);
        }

        foreach (var o in organizations)
        {
            o.UpdateTime(d);
        }

        foreach (var l in locations)
        {
            l.UpdateTime(d);
        }
    }

    public static uint globalEntityID = 0;

    #region CENTRAL ENTITIES
    // index = id of players, value = all relationless data about player
    public static List<Entity.Character> players = new List<Entity.Character>();

    // index = id of character, value = all relationless data about character
    public static List<Entity.Character> characters = new List<Entity.Character>();

    // index = id of organization, value = all relationless data about organization
    public static List<Entity.Organization> organizations = new List<Entity.Organization>();

    // index = id of location, value = all relationless data about location
    public static List<Entity.Location> locations = new List<Entity.Location>();
    #endregion
}