








public interface IShareData<U> where U : SimpleEntitySharedData
{
    U sharedData
    {
        get;
        set;
    }
}