using System.Collections.Generic;








// A unit for representing something that the character can choose to do,
// granted that the character has the willpower to do so.
public class CharacterOptionSharedData : CharacterSimpleEntitySharedData
{
    // The base cost of willpower needed to choose this option.
    // The higher the cost the less likely the character is to choose it.
    public double baseWillpowerCost;

    // Which CareAbouts should be taken into account when calculating the final
    // cost of willpower needed to choose this option. Integer is ids.
    public List<int> relevantCareAbouts;
}