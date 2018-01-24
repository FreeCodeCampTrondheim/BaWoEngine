using System;
using System.Text;
using System.Collections.Generic;

public static partial class Catalogue
{
    // Defines shared fields between all simple templates,
    // like character situations, -options and -forecasts.
    public abstract class SimpleEntityTemplate
    {
        // what the situation/option/forecast is called
        public string title;

        /* 
            This is what the situation/option/forecast is about,
            but do take note that all substrings of the types "@ch5",
            "@co7", "@ch3", "@co4" and "@co2" are references. 
            The "@" indicates that this is the start of a reference.
            The type of reference is indicated by the following 2 letters:

                ch = character
                co = collective

            Number indicates what index you have to look at in a List<int> 
            called "about". Each index contains a number equalling another
            index in some collection containing all of the complex entities
            like character or collective, or simple entities like situation,
            option and forecast.
        */
        public string description;

        // the resource id for the simple id, to identify it when the
        // developer wants to display or play associated images, sound etc.
        public int simpleEntityTemplateID;
    }
}