using System.Collections.Generic;








// Defines shared fields between all simple templates,
// like character situations, -options and -forecasts.
public abstract class SimpleEntitySharedData
{
    // title id to what the situation/option/forecast is called
    public int title;

    /* 
        This is what the situation/option/forecast is about.
        Note that every occurence of "@" is a placeholder for
        a reference to a complex entity.
    */
    public string description;

    // the resource id for the simple id, to identify it when the
    // developer wants to display or play associated images, sound etc.
    public int simpleEntitySharedDataID;

    // what type of complex entity each "@" references, with direct mapping from
    // list index to the first-to-last order of "@" occurences in description
    public COMPLEX_ENTITY_TYPE[] aboutTypes;
}