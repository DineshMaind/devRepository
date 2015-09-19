namespace MvcWebApp.Infrastructure
{
    using MvcWebCore;
    using System.Web.Mvc;

    public class ServiceFactory : IServiceFactory
    {
        private static readonly IServiceFactory instance = new ServiceFactory();

        static ServiceFactory()
        {
        }

        private ServiceFactory()
        {
        }

        public static IServiceFactory Instance { get { return instance; } }

        public IRepository GetDatabaseObject()
        {
            return DependencyResolver.Current.GetService<IRepository>();
        }
    }
}