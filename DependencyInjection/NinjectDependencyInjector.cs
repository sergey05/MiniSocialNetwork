using System;
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
        private static IKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static IDependencyResolver GetNinjectResolver(IKernel kernelWithRegisteredServices = null)
        {
            if(kernelWithRegisteredServices == null)
            {
                Initialize();
                RegisterServices();
                return new NinjectDependencyResolver(_kernel); 
            }
            return new NinjectDependencyResolver(kernelWithRegisteredServices);
        }

        public static void SetMvcResolver(IDependencyResolver resolver = null)
        {
            DependencyResolver.SetResolver(resolver ?? GetNinjectResolver());
        }

        private static void Initialize()
        {
            _kernel = new StandardKernel();
        }

        private static void RegisterServices()
        {
            if (_kernel == null)
            {
                throw new NullReferenceException("IKernel instance are not initialized");
            }
            _kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));//.WithConstructorArgument("unitOfWork",context => context.Kernel.Get<IUnitOfWork>());
            _kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            _kernel.Bind(typeof(IUserService)).To(typeof(UserService));
            _kernel.Bind(typeof(IMessageService)).To(typeof(MessageService));
            _kernel.Bind(typeof(IAdministrationService)).To(typeof(AdministrationService));
            _kernel.Bind<IDbContextFactory<DbContext>>().To<DbContextFactory>();
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
