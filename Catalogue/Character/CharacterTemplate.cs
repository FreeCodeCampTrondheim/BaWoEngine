using System;
using System.Collections.Generic;

static partial class Catalogue
{
    // represents a set of modules as well as additional
    // situations, options and forecasts granted by developer
    public class CharacterTemplate
    {
        // indices to modules defining the character template
        List<string> modules;
        
        // indices to extra situation-, option- and forecast templates
        // for expanded definition of the character template
        List<string> extraSituationTemplates;
        List<string> extraOptionTemplates;
        List<string> extraForecastTemplates;
    }
}