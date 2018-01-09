using System;
using System.Text;
using System.Collections.Generic;

public static partial class Catalogue
{
    // Defines shared fields between all simple templates,
    // like character situations, -options and -forecasts.
    public abstract class SimpleEntityTemplate
    {
        // what the situation/option/forecast is called
        public string title;

        /* 
            This is what the situation/option/forecast is about,
            but do take note that all substrings of the types "@ch5",
            "@co7", "@ch3", "@co4" and "@co2" are references. 
            The "@" indicates that this is the start of a reference.
            The type of reference is indicated by the following 2 letters:

                ch = character
                co = collective

            Number indicates what index you have to look at in a List<uint> 
            called "about". Each index contains a number equalling another
            index in some collection containing all of the complex entities
            like character or collective, or simple entities like situation,
            option and forecast.
        */
        public string description;

        // combines "about" with description to supply description 
        // relevant for current situation/option/forecast
        public string GetDescription(int worldID)
        {
            // where the "@" symbols start
            string[] startPoints = description.Split('@');

            if (startPoints.Length != 0)
            {
                // replace the @+type+index patterns with title/name of entity
                for (int i = 0; i < startPoints.Length; i++)
                {
                    // remove the back to only keep type+index pattern
                    string temp = startPoints[i].Split(' ')[0];
                    
                    if (temp.Length == 2)
                    {
                        // turn text into numerical equivalent, then into index from the "about" list
                        int entityIndex = about[int.Parse(temp.Substring(2))];

                        // access character
                        StatGroup stats;
                        if (temp.Substring(0, 2) == "ch") stats = Command.worlds[worldID].characters[entityIndex].stats;
                        else if (temp.Substring(0, 2) == "co") stats = Command.worlds[worldID].collectives[entityIndex].stats;
                        else continue;
                        
                        string name = "";
                        for (int j = 0; j < stats.numericalStatsBase["numberOfNames"]; j++)
                        {
                            // concatenate all available name variables
                            if (stats.textStats.ContainsKey("name" + j))
                            {
                                int listNr = stats.textStats["name" + j];
                                name += CharacterTemplating.textList["name" + j][listNr] + " ";
                            }
                        }

                        // replace pattern with name of entity
                        if (name.Length == 0) name = "-- missing name -- ";
                        startPoints[i] = startPoints[i].Replace(temp, name);
                    }
                }

                return String.Join("", startPoints);
            }

            else return description;
        }

        // contains indices for mapping references in "description"
        // to world entities like characters and collectives
        public List<int> about;
    }
}