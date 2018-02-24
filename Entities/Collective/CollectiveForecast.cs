








public partial class Collective
{
    public class CollectiveForecast : BaseSimpleEntity, IShareData<CollectiveForecastSharedData>
    {
        public CollectiveForecastSharedData sharedData { get; set; }
    }
}