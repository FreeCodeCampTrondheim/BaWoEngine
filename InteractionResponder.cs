using System;
using System.Collections.Generic;
using System.Text;





// 
class InteractionResponder
{
    public InteractionResponder(DataBank INIT_dBank) { dBank = INIT_dBank; }

    DataBank dBank;

    public class SearchEngine
    {
        const uint NUM_STORED_SEARCHES = 5;

        object[] lastSearches = new object[NUM_STORED_SEARCHES];    // stores last chosen searches

        // finds all characters, organizations and locations,
        // sorts them by type (characters, organizations, then locations),
        // followed by name alphabetically, followed by age descending
        // (except locations which don't have age), followed by id ascending 
        public List<object>[] Search(string searchTxt);

        List<E.Character> FindCharacters();         // finds all characters from string

        List<E.Organization> FindOrganizations();   // finds all organizations from string

        List<E.Location> FindLocations();           // finds all locations from string
    }
}