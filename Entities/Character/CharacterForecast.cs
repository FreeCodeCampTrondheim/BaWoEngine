








public partial class Character
{
    public class CharacterForecast : BaseSimpleEntity, IShareData<CharacterForecastSharedData>
    {
        public CharacterForecastSharedData sharedData { get; set; }
    }
}