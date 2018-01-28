








// A unit for representing something that the collective can choose to do,
// granted that the characters who steer the collective support the option.
public class CollectiveOptionSharedData : CollectiveSimpleEntitySharedData
{
    // the two character options used to represent the collective option
    // at individual controlling characters, and which is used to measure
    // consensus among characters controlling the collective
    public CharacterOptionSharedData approvalOption;
    public CharacterOptionSharedData rejectionOption;
}