








// A unit representing a source of care directed at some entity. 
// The title of the CareAbout represents its source at an abstract level. 
// i.e. "Shares Room", "Is Married", "Employed" etc.
public struct CareAbout
{
    // the id used to identify related CareAbouts
    // with same title and purpose
    public int groupID;

    // the title of the CareAbout
    public string title;

    // the index to look up in the about 
    // of the simple entity
    public int targetAboutIndex;

    // represents the size of the care, with positive for love and negative for hate
    public double degree;
}