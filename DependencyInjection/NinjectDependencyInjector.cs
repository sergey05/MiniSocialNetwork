using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using DataAccess;
using EFContextLayer;
using Ninject;
using Services;

namespace DependencyInjection
{
    public static class NinjectDependencyInjector
    {
        private static IKernel RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));//.WithConstructorArgument("unitOfWork",context => context.Kernel.Get<IUnitOfWork>());
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IDbContextFactory<DbContext>>().To<DbContextFactory>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            return kernel;
        }

        public static IDependencyResolver GetNinjectResolver(IKernel kernelWithRegisteredServices=null)
        {
            return kernelWithRegisteredServices == null ? new NinjectDependencyResolver(RegisterServices(new StandardKernel())) : new NinjectDependencyResolver(kernelWithRegisteredServices);
        }

        public static void SetMvcResolver()
        {
            DependencyResolver.SetResolver(GetNinjectResolver());
        }
    }
}
