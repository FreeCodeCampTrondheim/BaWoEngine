using System;
using System.Collections.Generic;
using System.Text;






public partial class Character : BaseComplexEntity
{
    public List<CharacterSituation> situations;
    public List<CharacterOption> options;
    public List<CharacterForecast> forecasts;

    public const int BASE_WILLPOWER = 1000;
}