using Ninject.Modules;
using STDAL.Interfaces;
using STDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace STBLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
