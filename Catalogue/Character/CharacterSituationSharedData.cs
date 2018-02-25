using System.Collections.Generic;








// A unit of measure of the STATE of the character, described through statistical data.
public class CharacterSituationSharedData : CharacterSimpleEntitySharedData
{
    // The PROTOTYPE statistical data carried
    // by this situation
    public StatGroup stats;

    // what different types of new things the character
    // might care about with this situation, which is
    // useful information during personalization
    public List<CareAbout> careAbouts;
}