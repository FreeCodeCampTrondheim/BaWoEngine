using System.Collections.Generic;








public partial class Collective : BaseComplexEntity
{
    public List<CollectiveSituation> situations;
    public List<CollectiveOption> options;
    public List<CollectiveForecast> forecasts;

    public List<int> controllingCharacters;
    public List<int> memberCharacters;
}