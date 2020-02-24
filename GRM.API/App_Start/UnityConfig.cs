using GRM.Shared.Classes;
using GRM.Shared.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace GRM.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IManager, FileManager>();
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}