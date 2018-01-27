using System.Collections.Generic;








public static partial class Catalogue
{
    // A unit of measure of the STATE of the character, described through statistical data.
    public class CharacterSituationSharedData : CharacterSimpleEntitySharedData
    {
        // The statistical data that are added to the
        // character with this situation.
        public StatGroup stats;

        // The data about what the character cares about that is added
        // with this situation. The text is the "care tag"  and represents
        // the source of the care, i.e. "Shares Room", "Is Married", "Employed"
        public Dictionary<int, List<CareAbout>> caresAbout;

        // What of the character's motivators are affected by
        // this situation, including the size of extra motivation
        public Dictionary<int, int> motivators;
    }
}