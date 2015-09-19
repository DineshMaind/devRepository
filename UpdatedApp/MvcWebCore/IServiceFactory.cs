namespace MvcWebCore
{
    public interface IServiceFactory
    {
        IRepository GetDatabaseObject();
    }
}