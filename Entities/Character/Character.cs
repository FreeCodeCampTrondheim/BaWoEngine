using System.Collections.Generic;








public partial class Character : BaseComplexEntity
{
    public List<CharacterSituation> situations;
    public List<CharacterOption> options;
    public List<CharacterForecast> forecasts;

    public const int BASE_WILLPOWER = 1000;

    // The data about what the character cares about. The integer 
    // is the "care title" and represents the source of the care, 
    // i.e. "Shares Room", "Is Married", "Employed"
    public Dictionary<int, List<CareAbout>> caresAbout;
}