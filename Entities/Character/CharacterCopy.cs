using System;
using System.Collections.Generic;







public partial class Character : BaseComplexEntity
{
    // copies all data
    public Character GetCopy()
    {
        Character newCharacter = new Character();
        
        // copies the content of the current array to a new array
        Array.Copy(
            categoryNumbers, 
            newCharacter.categoryNumbers, 
            categoryNumbers.Length);

        newCharacter.runSituations = runSituations;
        newCharacter.runOptions = runOptions;
        newCharacter.runForecasts = runForecasts;

        // uses copy-constructor of collection to make
        // a new collection with same contents
        newCharacter.situations = 
            new List<CharacterSituation>(situations);
        newCharacter.options =
            new List<CharacterOption>(options);
        newCharacter.forecasts =
            new List<CharacterForecast>(forecasts);

        newCharacter.stats.boolStats = 
            new Dictionary<int, BoolStat>(stats.boolStats);
        newCharacter.stats.textStats = 
            new Dictionary<int, TextStat>(stats.textStats);
        newCharacter.stats.baseNumberStats =
            new Dictionary<int, BaseNumberStat>(stats.baseNumberStats);
        newCharacter.stats.modifyingNumberStats =
            new Dictionary<int, ModifyingNumberStat>(stats.modifyingNumberStats);

        return newCharacter;
    }
}