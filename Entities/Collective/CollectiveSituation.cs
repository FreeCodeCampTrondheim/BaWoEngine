








public partial class Collective
{
    public class CollectiveSituation : BaseSimpleEntity, IShareData<CollectiveSituationSharedData>
    {
        public CollectiveSituationSharedData sharedData { get; set; }
    }
}