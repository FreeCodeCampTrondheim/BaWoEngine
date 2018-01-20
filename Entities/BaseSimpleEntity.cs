using System;
using System.Collections.Generic;
using System.Text;


public abstract class BaseSimpleEntity
{
    // which entity is responsible for launching this
    // situation/option/forecast, the target being the 
    // entity where this simple entity is listed
    public int sourceEntityID;

    // whether the source is a collective instead of a character
    public bool sourceIsCollective = false;

    // combines "about" with description to supply description 
    // relevant for current situation/option/forecast
    public string GetDescription(int worldID, Catalogue.SimpleEntityTemplate template)
    {
        // where the "@" symbols start
        string[] startPoints = template.description.Split('@');

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
                    Catalogue.StatGroup stats;
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
                            name += Catalogue.textList["name" + j][listNr] + " ";
                        }
                    }

                    // replace pattern with name of entity
                    if (name.Length == 0) name = "-- missing name -- ";
                    startPoints[i] = startPoints[i].Replace(temp, name);
                }
            }

            return String.Join("", startPoints);
        }

        else return template.description;
    }

    // contains references to world entities like characters 
    // and collectives to be combined with "description"
    public int[] about;
}