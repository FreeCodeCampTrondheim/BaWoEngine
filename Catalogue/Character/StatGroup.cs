using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static partial class Catalogue
{
    public struct StatGroup
    {
        public List<string> boolStats;
        public Dictionary<string, string> textStats;
        public Dictionary<string, int>    intStats;
        public Dictionary<string, float>  floatStats;

        #region Requirement Checks
        public bool ChecksPosRequirements(StatGroup requirements)
        {
            // checks that all bool stats that SHOULD be present are present,
            // which is an evaluation to true
            foreach (var item in requirements.boolStats)
            {
                if (!boolStats.Contains(item)) return false;
            }

            // checks if text stats that SHOULD have an associated text,
            // DO NOT HAVE that associated text
            foreach (var item in requirements.textStats)
            {
                if (textStats.ContainsKey(item.Key)
                    && (item.Value != textStats[item.Key]))
                    return false;
            }

            // checks if any integer stats are TOO LOW
            foreach (var item in requirements.intStats)
            {
                if (intStats.ContainsKey(item.Key)
                    && !(item.Value >= intStats[item.Key]))
                    return false;
            }

            // checks if any float stats are TOO LOW
            foreach (var item in requirements.floatStats)
            {
                if (floatStats.ContainsKey(item.Key)
                    && !(item.Value >= floatStats[item.Key]))
                    return false;
            }

            return true;
        }

        public bool ChecksNegRequirements(StatGroup requirements)
        {
            // checks that all bool stats that SHOULD NOT be present are absent,
            // which is an evaluation to false
            foreach (var item in requirements.boolStats)
            {
                if (boolStats.Contains(item)) return false;
            }

            // checks if text stats that SHOULD NOT have an associated text,
            // HAVE that associated text
            foreach (var item in requirements.textStats)
            {
                if (textStats.ContainsKey(item.Key)
                    && (item.Value == textStats[item.Key]))
                    return false;
            }

            // checks if any integer stats are TOO HIGH
            foreach (var item in requirements.intStats)
            {
                if (intStats.ContainsKey(item.Key)
                    && !(item.Value <= intStats[item.Key]))
                    return false;
            }

            // checks if any float stats are TOO HIGH
            foreach (var item in requirements.floatStats)
            {
                if (floatStats.ContainsKey(item.Key)
                    && !(item.Value <= floatStats[item.Key]))
                    return false;
            }

            return true;
        }
        #endregion
    }
}