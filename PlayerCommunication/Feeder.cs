using System;
using System.Collections.Generic;
using System.Text;





// handles passive information feeding to the GUI
static class F
{
    // handles user interaction and updating of displayed information about searches and selected search results
    public static class Inspector
    {
        static void DisplayCharacter(E.Character c) { }
        static void DisplayOrganization(E.Organization o) { }
        static void DisplayLocation(E.Location l) { }

        static void DisplaySearchResults(List<uint> entityResults) { }
    }

    // handles updating of displayed information about new situations
    public static class SituationNews
    {
        static Queue<E.Situation> newSituations;

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