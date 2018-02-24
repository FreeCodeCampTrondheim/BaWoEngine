








public partial class Collective
{
    public class CollectiveOption : BaseSimpleEntity, IShareData<CollectiveOptionSharedData>
    {
        public CollectiveOptionSharedData sharedData { get; set; }
    }
}