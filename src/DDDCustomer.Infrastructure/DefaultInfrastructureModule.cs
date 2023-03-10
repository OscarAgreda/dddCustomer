using System.Collections.Generic;
using System.Reflection;
using Autofac;
using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.Interfaces;
using DDDCustomer.Infrastructure.Data;
using dDDCustomerLib.SharedKernel.Interfaces;
using MediatR;
using Module = Autofac.Module;

namespace DDDCustomer.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly List<Assembly> _assemblies = new();
        private readonly bool _isDevelopment;

        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(Customer));
            _assemblies.Add(coreAssembly);
            var infrastructureAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }

            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CachedRepository<>))
                .As(typeof(IReadRepository<>))
                .InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            builder.RegisterType<EmailSender>().As<IEmailSender>()
                .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
        }
    }
}