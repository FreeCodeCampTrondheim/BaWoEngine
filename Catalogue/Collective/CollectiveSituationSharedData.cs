using System;
using System.Collections.Generic;
using System.Text;

public static partial class Catalogue
{
    // A unit of measure of the STATE of the collective, described through statistical data.
    public class CollectiveSituationSharedData : CollectiveSimpleEntitySharedData
    {
        // The statistical data that are added to the
        // collective with this situation.
        public StatGroup stats;
    }
}