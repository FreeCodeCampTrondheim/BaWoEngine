








public partial class Collective
{
    public class CollectiveSituation : BaseSimpleEntity, IShareData<CollectiveSituationSharedData>
    {
        public CollectiveSituationSharedData sharedData { get; set;
        
        // The INITIALIZED statistical data carried
        // by this situation
        public StatGroup stats;
    }
}