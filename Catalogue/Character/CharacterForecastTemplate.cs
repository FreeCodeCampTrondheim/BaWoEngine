using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static partial class Catalogue
{
    // A unit for representing something that can happen to the character, 
    // but which is outside of its immediate control - ergo "fate". 
    public class CharacterForecastTemplate : CharacterSimpleEntityTemplate
    {
        // Whether this represents positive fortune (0 or above)
        // for the character, or negative fortune (below 0).
        public int fortune;

        // The base chance that this will happen relative to other forecasts,
        // represented as a percentage value from 0 up to and including 1.
        // Internally within the fate engine, the real chance is methodologically
        // skewed in favour of smaller positive or negative fortunes, due to a
        // need for filling "fortune quotas".
        public float baseChance;
    }
}