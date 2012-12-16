using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCFCMSDomain;
//using EFCFCMSDomain.MapEntities;
using EFCFCMSDomain.Repository;
using Ninject;
using Ninject.Modules;

namespace CMSAdmin.Controllers
{
    public class NinjectControllerFactory :DefaultControllerFactory
    {
      

        private readonly IKernel kernel = new StandardKernel(new CMSNijectModuleBind());

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            if (controllerType == null)
                return null;
            return (IController)kernel.Get(controllerType);
        }


        internal class CMSNijectModuleBind : NinjectModule
        {
            public override void Load()
            {
                Bind<IRepository<Block>>().To<BlockRepository>();
              //  Bind<IRepository<Scheduler>>().To<SchedulerRepository>();
            }
        }

    }
}
