using System;
using System.Collections.Generic;
using System.Text;





// handles the response to GUI interaction by the player
static class R
{
    public static class SearchEngine
    {
        const uint NUM_STORED_SEARCHES = 5;

        static object[] lastSearches = new object[NUM_STORED_SEARCHES];    // stores last chosen searches

        // finds all characters, organizations and locations,
        // sorts them by type (characters, organizations, then locations),
        // followed by name alphabetically, followed by age descending
        // (except locations which don't have age), followed by id ascending 
        public static List<object>[] Search(string searchTxt) { return null; }

        // finds all characters from string
        static List<E.Character> FindCharacters() { return null; }

        // finds all organizations from string
        static List<E.Organization> FindOrganizations() { return null; }

        // finds all locations from string
        static List<E.Location> FindLocations() { return null; }
    }
}
