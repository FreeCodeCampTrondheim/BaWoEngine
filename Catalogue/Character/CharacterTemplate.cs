using System;
using System.Collections.Generic;

public static partial class Catalogue
{
    // represents a set of situations, options 
    // and forecasts granted by developer/user
    public class CharacterTemplate
    {
        // situations, options and forecasts that are added
        // as a minimum to this character
        List<string> situations;
        List<string> options;
        List<string> forecasts;
    }
}