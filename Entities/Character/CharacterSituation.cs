








public partial class Character
{
    public class CharacterSituation : BaseSimpleEntity, IShareData<CharacterSituationSharedData>
    {
        public CharacterSituationSharedData sharedData { get; set; }

        // The INITIALIZED statistical data carried
        // by this situation
        public StatGroup stats;
    }
}