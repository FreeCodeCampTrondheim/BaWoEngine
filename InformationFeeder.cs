using System;
using System.Collections.Generic;
using System.Text;





// 
class InformationFeeder
{
    public InformationFeeder(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    // handles user interaction and updating of displayed information about searches and selected search results
    public class Inspector
    {
        void DisplayCharacter(E.Character c);
        void DisplayOrganization(E.Organization o);
        void DisplayLocation(E.Location l);

        void DisplaySearchResults(List<uint> entityResults);
    }

    // handles updating of displayed information about new situations
    public class SituationNews
    {
        Queue<E.Situation> newSituations;

        void DisplayNews();
    }

    // handles user interaction and updating of displayed information about player situations 
    public class SituationResponder
    {

    }

    // handles user interaction and updating of displayed information about player information
    public class PlayerInfo
    {

    }

    // handles updating of displayed information about character dialogue
    public class Hangout
    {

    }
}