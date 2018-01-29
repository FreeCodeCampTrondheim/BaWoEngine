using System.Collections.Generic;








// A unit of measure of the STATE of the character, described through statistical data.
public class CharacterSituationSharedData : CharacterSimpleEntitySharedData
{
    // The statistical data that are added to the
    // character with this situation.
    public StatGroup stats;

    public Dictionary<int, CareAboutSharedData> careAboutSharedData;
}