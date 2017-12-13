using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




// provides collections of strings for outputting in a GUI
public static class Feeder
{
    public static Dictionary<string, DataView> dataViews 
        = new Dictionary<string, DataView>();
    
    public class DataView
    {
        public List<string>  includeSituations = new List<string>();
        public List<string>  includeOptions = new List<string>();
        public List<string>  includeForecasts = new List<string>();

        public List<string>  censoredSituationProperties = new List<string>();
        public List<string>  censoredOptionProperties = new List<string>();
        public List<string>  censoredForecastProperties = new List<string>();

        public bool censorStats = false;
        public bool censorStatValue = false;
        public bool censorCares = false;
        public bool censorCareValue = false;
    }

    // returns a list of all situations formatted into strings with newline
    // separated property name and -value pairs, subject to predefined censorship
    public static List<string> GetDataViewSituations(DataView dw)
    {
        List<string> result = new List<string>();
        StringBuilder temp;
        foreach (string s in dw.includeSituations)
        {
            temp = new StringBuilder();
            Entity.Situation situation = DataBank.players[0].situations[s];

            if (!dw.censorCares)
            {
                temp.Append(GetCares(situation.template.cares, dw));
            }

            if (!dw.censorStats)
            {
                temp.Append(GetTextStats(situation.template.textStats, dw));
                temp.Append(GetNumberStats(situation.template.intStats, situation.template.floatStats, dw));
            }

            result.Add(temp.ToString());
        }
        return result;
    }

    public static string GetCares(List<Catalogue.BaseTemplate.Care> cares, DataView dw)
    {
        StringBuilder temp = new StringBuilder();

        foreach (var care in cares)
        {
            if (!dw.censoredSituationProperties.Contains(care.tag))
            {
                temp.Append(care.ToString(dw.censorCareValue));
                temp.AppendLine();
            }
        }

        return temp.ToString();
    }

    public static string GetTextStats(List<string> textStats, DataView dw)
    {
        StringBuilder temp = new StringBuilder();

        foreach (string stat in textStats)
        {
            if (!dw.censoredSituationProperties.Contains(stat))
            {
                temp.Append(stat);
                temp.AppendLine();
            }
        }
        
        return temp.ToString();
    }

    public static string GetNumberStats(Dictionary<string, int> intStats, Dictionary<string, float> floatStats, DataView dw)
    {
        StringBuilder temp = new StringBuilder();

        if (!dw.censorStatValue)
        {
            foreach (var stat in intStats)
            {
                if (!dw.censoredSituationProperties.Contains(stat.Key))
                {
                    temp.Append(stat.Key + ": " + stat.Value.ToString());
                    temp.AppendLine();
                }
            }

            foreach (var stat in floatStats)
            {
                if (!dw.censoredSituationProperties.Contains(stat.Key))
                {
                    temp.Append(stat.Key + ": " + stat.Value.ToString());
                    temp.AppendLine();
                }
            }
        }
        else
        {
            foreach (var stat in intStats)
            {
                if (!dw.censoredSituationProperties.Contains(stat.Key))
                {
                    temp.Append(stat.Key);
                    temp.AppendLine();
                }
            }

            foreach (var stat in floatStats)
            {
                if (!dw.censoredSituationProperties.Contains(stat.Key))
                {
                    temp.Append(stat.Key);
                    temp.AppendLine();
                }
            }
        }

        return temp.ToString();
    }

    // returns a list of all options formatted into strings with newline
    // separated property name and -value pairs, subject to predefined censorship
    public static List<string> GetDataViewOptions(DataView dw)
    {
        StringBuilder builder = new StringBuilder();

        return null;
    }

    // returns a list of all forecasts formatted into strings with newline
    // separated property name and -value pairs, subject to predefined censorship
    public static List<string> GetDataViewForecasts(DataView dw)
    {
        StringBuilder builder = new StringBuilder();

        return null;
    }

    // builds a table alignment of data from situations in data view
    public static string[] GetSituationTable(DataView dw, uint numAlongAxis, bool axisIsHorizontal = false)
    {
        StringBuilder builder = new StringBuilder();
        
        return null;
    }
}