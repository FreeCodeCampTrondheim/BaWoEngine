﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




// provides collections of strings for outputting in a GUI
namespace DataViewer
{
    public static class Character
    {
        #region Data Views
        public static Dictionary<string, DataView> dataViews
        = new Dictionary<string, DataView>();

        public class DataView
        {
            int FixedPropertyNameLength = -1;

            public List<string> includeSituations = new List<string>();
            public List<string> includeOptions = new List<string>();
            public List<string> includeForecasts = new List<string>();

            public List<string> censoredSituationProperties = new List<string>();
            public List<string> censoredOptionProperties = new List<string>();
            public List<string> censoredForecastProperties = new List<string>();

            public bool censorStats = false;
            public bool censorStatValue = false;
            public bool censorCares = false;
            public bool censorCareValue = false;
        }
        #endregion

        #region Situations
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
                    temp.Append(GetAllCares(situation.template.cares, dw));
                }

                if (!dw.censorStats)
                {
                    temp.Append(GetAllTextStats(situation.template.textStats, dw));
                    temp.Append(GetNumberStats(situation.template.intStats, situation.template.floatStats, dw));
                }

                result.Add(temp.ToString());
            }
            return result;
        }

        public static string GetAllCares(List<Catalogue.BaseTemplate.Care> cares, DataView dw)
        {
            StringBuilder temp = new StringBuilder();

            foreach (var care in cares)
            {
                if (!dw.censoredSituationProperties.Contains(care.tag))
                {
                    temp.Append(GetCare(care, dw));
                    temp.AppendLine();
                }
            }

            return temp.ToString();
        }

        public static string GetCare(Catalogue.BaseTemplate.Care care, DataView dw)
        {
            string careStr = "";
            if (!dw.censorCareValue)
            {
                careStr = care.tag + ": " + care.target +
                "(" + care.emphasis.ToString() + ")";
            }
            else careStr = care.tag + ": " + care.target;

            return careStr;
        }

        public static string GetAllTextStats(List<string> textStats, DataView dw)
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
                        temp.Append(FormatIntStat(stat.Key, stat.Value, dw));
                        temp.AppendLine();
                    }
                }

                foreach (var stat in floatStats)
                {
                    if (!dw.censoredSituationProperties.Contains(stat.Key))
                    {
                        temp.Append(FormatFloatStat(stat.Key, stat.Value, dw));
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

        // Get key-value pair from Dictionary, i.e. GetIntStat()
        public static string FormatIntStat(string stat, int value, DataView dw)
        {
            return stat + ": " + value.ToString();
        }

        // Get key-value pair from Dictionary
        public static string FormatFloatStat(string stat, float value, DataView dw)
        {
            return stat + ": " + value.ToString();
        }
        #endregion

        #region Options
        // returns a list of all options formatted into strings with newline
        // separated property name and -value pairs, subject to predefined censorship
        public static List<string> GetDataViewOptions(DataView dw)
        {
            StringBuilder builder = new StringBuilder();

            return null;
        }
        #endregion

        #region Forecasts
        // returns a list of all forecasts formatted into strings with newline
        // separated property name and -value pairs, subject to predefined censorship
        public static List<string> GetDataViewForecasts(DataView dw)
        {
            StringBuilder builder = new StringBuilder();

            return null;
        }
        #endregion

        // builds a table alignment of data from situations in data view
        public static string[] FormatAsTable(DataView dw, uint numAlongAxis, bool axisIsHorizontal = false)
        {
            // code here

            return null;
        }
    }
}