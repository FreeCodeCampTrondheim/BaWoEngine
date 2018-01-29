








// A unit representing a source of care directed at some entity. 
// The title of the CareAbout represents its source at an abstract level. 
// i.e. "Shares Room", "Is Married", "Employed" etc. This title is
// specified by the associated integer this value is indexed by.
public class CareAbout
{
    // the index to look up at the world
    public int targetID;

    // whether the complex entity should be looked
    // up in character- or collective registry
    public COMPLEX_ENTITY_TYPE targetType;

    // represents the size of the care, with positive for love and negative for hate
    public double emphasis;
}