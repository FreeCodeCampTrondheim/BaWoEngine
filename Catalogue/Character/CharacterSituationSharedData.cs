using System.Collections.Generic;








// A unit of measure of the STATE of the character, described through statistical data.
public class CharacterSituationSharedData : CharacterSimpleEntitySharedData
{
    // The statistical data that are added to the
    // character with this situation.
    public StatGroup stats;

    // what different types of new things the character
    // might care about with this situation
    public List<CareAbout> careAbout;
}