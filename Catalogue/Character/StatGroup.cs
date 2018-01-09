using System;
using System.Collections.Generic;
using System.Text;

public static partial class Catalogue
{
    public struct StatGroup
    {
        // existence in list is equated with true, while absence is false
        public List<string> boolStats;

        // integer value is a reference to the index in the list of allowed text values,
        // while any negative integer value tells the personalizer to insert a random value
        public Dictionary<string, int> textStats;

        // final value of a numerical stat is combined base multiplied by combined modifiers
        public Dictionary<string, double> numericalStatsBase;
        public Dictionary<string, double> numericalStatsModifiers;
    }
}