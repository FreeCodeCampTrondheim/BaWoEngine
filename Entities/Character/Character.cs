using System.Collections.Generic;








public partial class Character : BaseComplexEntity
{
    public List<CharacterSituation> situations;
    public List<CharacterOption> options;
    public List<CharacterForecast> forecasts;

    public const int BASE_WILLPOWER = 1000;
    
    public Dictionary<int, List<CareAbout>> careAboutsPerCharacter;
    public Dictionary<int, List<CareAbout>> careAboutsPerCollective;

    public Dictionary<int, List<int>> charactersPerCareAbout;
    public Dictionary<int, List<int>> collectivesPerCareAbout;
}