using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using EFMVC.CommandProcessor.Command;
using EFMVC.CommandProcessor.Dispatcher;
using EFMVC.Data.Infrastructure;
using EFMVC.Data.Repositories;
using EFMVC.Web.Core.Authentication;
using System.Web.Http;
using EFMVC.Web.Core.Autofac;
namespace EFMVC.Web.API
{
    public static class Bootstrapper
    {
        public static void Run()
        {
           
            SetAutofacWebAPIServices();
        }       
        private static void SetAutofacWebAPIServices()
        {
            var builder = new ContainerBuilder();           
            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerHttpRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerHttpRequest();
            var services = Assembly.Load("EFMVC.Domain");
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(IValidationHandler<>)).InstancePerHttpRequest();
           
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            IContainer container = builder.Build();

            var resolver = new AutofacDependencyResolver(container);

            GlobalConfiguration.Configuration.ServiceResolver.SetResolver(
                t => resolver.GetService(t),
                t => resolver.GetServices(t));               
        }
    }
}
