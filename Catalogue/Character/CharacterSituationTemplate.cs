using System;
using System.Collections.Generic;
using System.Text;

static partial class Catalogue
{
    // A unit of measure of the STATE of the character, described through statistical data.
    public class CharacterSituationTemplate : CharacterSimpleEntityTemplate
    {
        // The statistical data that are added to the
        // character with this situation.
        StatGroup stats;

        // The data about what the character cares about that is added
        // with this situation. The text is the "care tag"  and represents
        // the source of the care, i.e. "Shares Room", "Is Married", "Employed"
        Dictionary<string, List<CareAbout>> caresAbout;

        // What of the character's motivators are affected by
        // this situation, including the size of extra motivation
        Dictionary<string, int> motivators;
    }
}