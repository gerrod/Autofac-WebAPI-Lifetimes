#region Using directives

using System;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using DecompileIt.Autofac.Resolvables;

#endregion


namespace DecompileIt.Autofac
{
    public static class IoC
    {
        public static IContainer Container { get; private set; }

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            RegisterToken(builder);
            RegisterResolvables(builder);
            RegisterWebApi(builder);
        }

        private static void RegisterToken(ContainerBuilder builder)
        {
            var tokenRegistration = builder.RegisterType<ScopeToken>();

            // TODO: Try them all!
            // tokenRegistration.SingleInstance();
            // tokenRegistration.InstancePerLifetimeScope();
            // tokenRegistration.InstancePerApiRequest();
            tokenRegistration.InstancePerDependency();
        }

        private static void RegisterResolvables(ContainerBuilder builder)
        {
            builder.RegisterType<SingletonResolvable>().SingleInstance();
            builder.RegisterType<PerLifetimeResolvable>().InstancePerLifetimeScope();
            builder.RegisterType<PerRequestResolvable>().InstancePerApiRequest();
            builder.RegisterType<PerDependencyResolvable>().InstancePerDependency();
            
            builder.RegisterType<ResolvableConsumer>();
        }

        private static void RegisterWebApi(ContainerBuilder builder)
        {
            var assembly = typeof(IoC).Assembly;
            builder.RegisterApiControllers(assembly);

            Container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);            
        }
    }
}