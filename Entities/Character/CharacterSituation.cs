








public partial class Character
{
    public class CharacterSituation : BaseSimpleEntity, IShareData<CharacterSituationSharedData>
    {
        public CharacterSituationSharedData sharedData { get; set; }
    }
}