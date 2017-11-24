using System;
using System.Collections.Generic;
using System.Text;





// handles passive information feeding to the GUI
static class Feeder
{
    // handles user interaction and updating of displayed information about searches and selected search results
    public static class Inspector
    {
        static void DisplayCharacter(Entity.Character c) { }
        static void DisplayOrganization(Entity.Organization o) { }
        static void DisplayLocation(Entity.Location l) { }

        static void DisplaySearchResults(List<uint> entityResults) { }
    }

    // handles updating of displayed information about new situations
    public static class SituationNews
    {
        static Queue<Entity.Situation> newSituations;

        static void DisplayNews() { }
    }

    // handles user interaction and updating of displayed information about player situations 
    public static class SituationResponder
    {

    }

    // handles user interaction and updating of displayed information about player information
    public static class PlayerInfo
    {

    }

    // handles updating of displayed information about character dialogue
    public static class Hangout
    {

    }
}