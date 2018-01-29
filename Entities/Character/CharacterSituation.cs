using System.Collections.Generic;








public partial class Character
{
    public class CharacterSituation : BaseSimpleEntity
    {
        public CharacterSituationSharedData sharedData;

        public Dictionary<int, CareAbout> caresAbout;
    }
}