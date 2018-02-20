using System.Collections.Generic;








// Defines shared fields between all simple templates,
// like character situations, -options and -forecasts.
public abstract class SimpleEntitySharedData
{
    // can be used to identify this resource, for instance to check what
    // kind of image, sound or cutscene the developer might want to show/play
    public int id;

    // what the situation/option/forecast is called
    public string title;

    /* 
        This is what the situation/option/forecast is about.
        Note that every occurence of "@" is a placeholder for
        a reference to a complex entity.
    */
    public string description;

    // what type of complex entity each "@" references, with direct mapping from
    // list index to the first-to-last order of "@" occurences in description
    public IndexFillSpecification[] aboutFillSpecs;
}