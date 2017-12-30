using System;
using System.Collections.Generic;

static partial class Catalogue
{
    // describes the conditions that need to be in place for simple entities
    // to be launched, i.e. situations, options and forecasts
    public struct Launchables
    {
        /* 
            StatGroup describes the minimum POSITIVE statistical data conditions 
            that have to be present in order for launch to occur. For numbers this
            is any value equal or ABOVE,  while for text it is the PRESENCE of the
            text stat at the character.
        */
        public Dictionary<string, StatGroup> minPosLaunchConditions;

        /* 
            StatGroup describes the minimum NEGATIVE statistical data conditions
            that have to be present in order for launch to occur. For numbers this
            is any value equal or BELOW, while for text it is the ABSENCE of the
            text stat at the character.
        */
        public Dictionary<string, StatGroup> minNegLaunchConditions;

        // describes how- and what indices from the "about" in the
        // current situation, option or forecast are forwarded to next,
        // thereby creating continuity and logical consistency
        public Dictionary<string, List<uint>> aboutIndexMap;
    }
}