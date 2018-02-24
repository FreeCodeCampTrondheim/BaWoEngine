








public partial class Character
{
    public class CharacterOption : BaseSimpleEntity, IShareData<CharacterOptionSharedData>
    {
        public CharacterOptionSharedData sharedData { get; set; }
    }
}