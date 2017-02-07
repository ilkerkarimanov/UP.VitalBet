namespace UP.VitalBet.Infrastructure.Feed.Abstract
{
    public interface IDataSurrogate<T>
    {
         T GetDeserializedObject(int parentId = 0);
    }
}
